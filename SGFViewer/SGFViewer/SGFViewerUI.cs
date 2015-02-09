// *****************************************************************************************************
// SGFViewer - GUI for SGFParser, allows user to visually play through a go game loaded from an sgf file
//
// Written by Jonathan Melcher
// Last updated Feb 08, 2015
// *****************************************************************************************************

#region using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SGFParser;

#endregion

namespace SGFViewer
{
    // **************************************************************************************************
    // SGFViewerUI Form partial class - contains methods and handlers for loading an sgf file and storing
    // the parsed information, as well as methods and handlers for visually traversing through the parsed
    // tree.  Uses the GoLogic class to determine when stones are captured and SGFParser for parsing.
    // **************************************************************************************************
    public partial class SGFViewerUI : Form
    {
        #region non-static properties

        // List of boardStates that have been accessed by cursor
        // Used for going backwards through gametree
        private List<GoLogic.state[,]> boardStates = new List<GoLogic.state[,]> { };

        // Used for drawing stones onto panel goBoardUI
        private Graphics stoneOverlay;

        // Current loaded gameTree, comes from SGFParser
        private SGFParser.TreeSGF gameTree = null;

        private NodeSGF cursor = null;      // Cursor for traversing gametree
        private int branchNumber = 1;       // Current branch number for accessing cursor's children
        private int branchLimit = 1;        // Current cursor's number of children
        private int blackScore = 0;         // Black score for updating UI
        private int whiteScore = 0;         // White score for updating UI
        private bool tryToCapture = true;   // Whether game logic will capture stones
        private bool test = false;          // For used when testing

        #endregion
        #region constructor

        public SGFViewerUI()
        {
            InitializeComponent();
            boardStates.Clear();
            boardStates.Add(new GoLogic.state[19, 19]);
            stoneOverlay = goBoardUI.CreateGraphics();      // Initialize graphics on panel goBoardUI - need to Dispose() on exit!
        }

        #endregion
        #region event-handlers

        // Iterates through the last known state[,] boardstate, drawing stones where applicable
        private void goBoardUI_Paint(object sender, PaintEventArgs e)
        {
            Color colour;
            GoLogic.state[,] game = boardStates.Last();

            for (int j = 0; j < game.GetLength(1); j++)
                for (int i = 0; i < game.GetLength(0); i++)
                {
                    // No stone to draw
                    if (game[i, j] == GoLogic.state.None)
                        continue;

                    colour = game[i, j] == GoLogic.state.Black ? Color.Black : Color.White;

                    // (3,3) is the topleft of the stone sitting in game[0,0]
                    // 28 is the pixelWidth/Height of the stones based on the current (constant) scale of the game
                    // This could be generalized based on a scale to allow user window sizing
                    using (SolidBrush brush = new SolidBrush(colour))
                        stoneOverlay.FillEllipse(brush, 3 + 28 * i, 3 + 28 * j, 28, 28);
                }
        }

        // Disposing of the Graphic resource on application exit
        private void SGFViewerUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            stoneOverlay.Dispose();
        }

        // Allows user to search computer for an sgf file to load
        private void browseFilesUI_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                string fileToOpen = FD.FileName;
                sourceFileUI.Text = fileToOpen.Replace("\\\\", "\\");
            }
        }

        // Loading a user-selected file and running SGFParser on it
        private void loadFileUI_Click(object sender, EventArgs e)
        {
            string ext = "";

            // Check if non-empty and that extension is sgf (must have at least .sgf at end)
            try
            {
                ext = Path.GetExtension(sourceFileUI.Text);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message));
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}.  Application will exit.", ex.Message));
                Application.Exit();
            }

            // Filepath gives us a valid sgf file - must load it into SGFParser and return tree
            if (ext == ".sgf")
            {
                if (!File.Exists(sourceFileUI.Text))
                    MessageBox.Show("File does not exist");
                else
                {
                    try
                    {
                        SGFParser.ParserSGF prsr = new SGFParser.ParserSGF(sourceFileUI.Text);
                        gameTree = prsr.ParseFile(
                            prsr.Raw, prsr.GameProperties, prsr.MovementProperties, prsr.PlacementProperties);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Application.Exit();
                    }

                    // Resetting all branch IDs in tree
                    gameTree.ResetTheIDS("M");

                    // Adding initial empty board - can be generalized for different sizes
                    // but requires a lot of work vis a vis UI integration (logic is OK)
                    boardStates.Clear();
                    boardStates.Add(new GoLogic.state[19, 19]);
                    
                    // Setting cursor to root
                    cursor = gameTree.Root;
                    
                    currentMoveUI.Text = "0";
                    UpdateGameProperties();
                    moveCursorUI();
                }
            }
        }

        // Selecting a higher branch to move to
        private void branchUpUI_Click(object sender, EventArgs e)
        {
            if (branchNumber > 1)
            {
                branchNumber--;
                toBranchUI.Text = branchNumber.ToString();
            }   
        }

        // Selecting a lower branch to move to
        private void branchDownUI_Click(object sender, EventArgs e)
        {
            if (branchNumber < branchLimit)
            {
                branchNumber++;
                toBranchUI.Text = branchNumber.ToString();
            }
        }

        // Moving cursor to a further position in the gametree as specified by user
        private void nextUI_Click(object sender, EventArgs e)
        {
            // Game is not loaded or cursor has nowhere to go to
            if (cursor == null || cursor.Children.Count == 0)
                return;

            // Move cursor to a child based on selected branchNumber
            cursor = cursor.Children[cursor.Children.Count - branchNumber];

            // Clone current boardState for editing
            GoLogic.state[,] newState = (GoLogic.state[,])boardStates.Last().Clone();

            // Cursor is at a placement node - add/remove stones to/from board and check for inconsistencies
            if (!cursor.Data.IsMove)
                nextMoveIsPlacement(ref newState);

            // Cursor is at a move node - add stone to board and check for captures
            else
                nextMoveIsMovement(ref newState);

            boardStates.Add(newState);
            currentMoveUI.Text = (int.Parse(currentMoveUI.Text) + 1).ToString();
            moveCursorUI();
        }

        // Moving cursor to a previous position in the gametree
        private void previousUI_Click(object sender, EventArgs e)
        {
            // There is no game loaded or cursor is currently at root
            if (cursor == null || cursor == gameTree.Root)
                return;

            // Move cursor back a node and remove last known boardState, updating UI
            cursor = cursor.Parent;
            boardStates.RemoveAt(boardStates.Count - 1);
            currentMoveUI.Text = (int.Parse(currentMoveUI.Text) - 1).ToString();
            moveCursorUI();
        }

        #endregion
        #region nextUI_Click subroutines

        // Subroutine for nextUI_Click: node that cursor moves to is a placement node
        private void nextMoveIsPlacement(ref GoLogic.state[,] newState)
        {
            GoLogic.state stoneColour = GoLogic.state.None;

            if (cursor.Data.Moves.Count != 0 && !cursor.Data.ToClear)
                stoneColour = cursor.Data.Moves[0].Item1 ? GoLogic.state.Black : GoLogic.state.White;

            foreach (Tuple<bool, int, int, int> placement in cursor.Data.Moves)
            {
                // Make placement on cloned boardstate
                newState[placement.Item2, placement.Item3] = stoneColour;

                // Check for inconsistencies if viewer is still capturing stones
                if (tryToCapture)
                {
                    if (stoneColour == GoLogic.state.None)
                        continue;

                    GoLogic logic = new GoLogic(newState, blackScore, whiteScore);
                    Tuple<GoLogic.state, int, int> move = Tuple.Create(stoneColour, placement.Item2, placement.Item3);
                    List<Tuple<GoLogic.state, int, int>> possibleCaptures = logic.GetAdjacentOpponentMoves(move);

                    foreach (Tuple<GoLogic.state, int, int> pCs in possibleCaptures)
                        if (logic.GetLiberties(pCs) == 0)
                        {
                            MessageBox.Show("Illegal board position, some features (capturing stones) may not work anymore.");
                            tryToCapture = false;
                        }
                }
            }
        }

        // Subroutine for nextUI_Click: node that cursor moves to is a movement node
        private void nextMoveIsMovement(ref GoLogic.state[,] newState)
        {
            GoLogic.state stoneColour = GoLogic.state.None;
            stoneColour = cursor.Data.Moves[0].Item1 ? GoLogic.state.Black : GoLogic.state.White;

            Tuple<GoLogic.state, int, int> move =
                Tuple.Create(stoneColour, cursor.Data.Moves[0].Item2, cursor.Data.Moves[0].Item3);

            // check for pass
            if (cursor.Data.Moves[0].Item2 == -1 || cursor.Data.Moves[0].Item3 == -1)
            {
                // Pass method here
                return;
            }

            // Make move on cloned boardstate
            newState[move.Item2, move.Item3] = stoneColour;

            // If viewer is still capturing stones
            if (tryToCapture)
            {
                GoLogic logic = new GoLogic(newState, blackScore, whiteScore);
                HashSet<Tuple<GoLogic.state, int, int>> prisoners = new HashSet<Tuple<GoLogic.state, int, int>>();

                foreach (Tuple<GoLogic.state, int, int> pCs in logic.GetAdjacentOpponentMoves(move))
                    if (logic.GetLiberties(pCs) == 0)
                        foreach (Tuple<GoLogic.state, int, int> prisoner in logic.GetGroup(pCs))
                            prisoners.Add(prisoner);

                logic.ClearGroup(prisoners, true, ref blackScore, ref whiteScore);

                if (logic.GetLiberties(move) == 0)
                    logic.ClearGroup(logic.GetGroup(move), true, ref blackScore, ref whiteScore);

                newState = logic.BoardState;
            }
        }

        #endregion
        #region helper functions

        // Updating Game Properties on the UI using the root of the gameTree
        private void UpdateGameProperties()
        {
            string value;

            if (gameTree != null)
            {
                gameTree.Root.Data.GameProperties.TryGetValue("GN", out value);
                gameLabelUI.Text = value;
                gameTree.Root.Data.GameProperties.TryGetValue("RE", out value);
                resultLabelUI.Text = value;
                gameTree.Root.Data.GameProperties.TryGetValue("PB", out value);
                blackNameLabelUI.Text = value;
                gameTree.Root.Data.GameProperties.TryGetValue("BR", out value);
                blackRankLabelUI.Text = value;
                gameTree.Root.Data.GameProperties.TryGetValue("PW", out value);
                whiteNameLabelUI.Text = value;
                gameTree.Root.Data.GameProperties.TryGetValue("WR", out value);
                whiteRankLabelUI.Text = value;
            }
        }

        // Updating commentsUI ListBox based on current cursor
        private void UpdateComments()
        {
            if (cursor == null)
                return;

            commentsUI.Items.Clear();
            foreach (string s in cursor.Data.Comments)
                commentsUI.Items.Add(s);
        }

        // Updating UI to reflect cursor being set or moved to another node in the game tree
        private void moveCursorUI()
        {
            branchNumber = 1;
            toBranchUI.Text = branchNumber.ToString();
            branchLabelUI.Text = cursor.ID;
            branchLimit = cursor.Children.Count;
            UpdateComments();
            goBoardUI.Invalidate();
        }

        #endregion
    }
}