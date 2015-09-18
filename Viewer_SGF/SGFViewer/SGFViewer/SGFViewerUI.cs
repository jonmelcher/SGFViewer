// *****************************************************************************************************
// SGFViewer - GUI for SGFParser, allows user to visually play through a go game loaded from an sgf file
//
// Written by Jonathan Melcher
// Last updated Feb 08, 2015
// *****************************************************************************************************

#region using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Parser_SGF;
using Go;

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

        private Graphics stoneOverlay;                  // Used for drawing stones onto panel goBoardUI
        private Go.GoEngine engine = null;                 // Engine containing tree and gamestates
        private bool loaded = false;

        #endregion
        #region constructor

        public SGFViewerUI()
        {
            InitializeComponent();
            stoneOverlay = goBoardUI.CreateGraphics();  // Initialize graphics on panel goBoardUI - need to Dispose() on exit!
        }

        #endregion
        #region event-handlers

        // Iterates through the last known state[,] boardstate, drawing stones where applicable
        private void goBoardUI_Paint(object sender, PaintEventArgs e)
        {
            if (loaded)
            {
                Color colour;
                GoStone[,] currentState = engine.CurrentState;

                for (int j = 0; j < currentState.GetLength(0); ++j)
                    for (int i = 0; i < currentState.GetLength(1); ++i)
                    {
                        // No stone to draw
                        if (currentState[j, i].Colour == GoColour.None)
                            continue;

                        colour = currentState[j, i].Colour == GoColour.Black ? Color.Black : Color.White;

                        // (3,3) is the topleft of the stone sitting in game[0,0]
                        // 28 is the pixelWidth/Height of the stones based on the current (constant) scale of the game
                        // This could be generalized based on a scale to allow user window sizing
                        using (SolidBrush brush = new SolidBrush(colour))
                            stoneOverlay.FillEllipse(brush, 3 + 28 * i, 3 + 28 * j, 28, 28);
                    }
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
            // Check if non-empty and that extension is sgf (must have at least .sgf at end)
            try
            {
                string ext = Path.GetExtension(sourceFileUI.Text);
                if (ext == ".sgf")
                {
                    if (!File.Exists(sourceFileUI.Text))
                        MessageBox.Show("File does not exist");
                    else
                    {
                        engine = new Go.GoEngine(sourceFileUI.Text);
                        loaded = true;
                        UpdateGameProperties();
                        commentsUI.Items.Clear();
                        currentMoveUI.Text = engine.CurrentMove.ToString();
                        moveCursorUI();
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message));
                loaded = false;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message));
                loaded = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}.  Application will exit.", ex.Message));
                Application.Exit();
            }
        }

        // Selecting a higher branch to move to
        private void branchUpUI_Click(object sender, EventArgs e)
        {
            if (engine.BranchNumber > 1)
            {
                --engine.BranchNumber;
                toBranchUI.Text = engine.BranchNumber.ToString();
            }   
        }

        // Selecting a lower branch to move to
        private void branchDownUI_Click(object sender, EventArgs e)
        {
            if (engine.BranchNumber < engine.Cursor.Children.Count)
            {
                ++engine.BranchNumber;
                toBranchUI.Text = engine.BranchNumber.ToString();
            }
        }

        // Moving cursor to a further position in the gametree as specified by user
        private void nextUI_Click(object sender, EventArgs e)
        {
            if (loaded)
            {
                engine.NextMove();
                currentMoveUI.Text = engine.CurrentMove.ToString();
                moveCursorUI();
            }
        }

        // Moving cursor to a previous position in the gametree
        private void previousUI_Click(object sender, EventArgs e)
        {
            if (loaded)
            {
                engine.PreviousMove();
                currentMoveUI.Text = engine.CurrentMove.ToString();
                moveCursorUI();
            }
        }

        // Moving cursor to the root of the gameTree
        private void beginningUI_Click(object sender, EventArgs e)
        {
            if (loaded)
            {
                engine.FirstMove();
                commentsUI.Items.Clear();
                currentMoveUI.Text = engine.CurrentMove.ToString();
                moveCursorUI();
            }
        }

        // Moving cursor to the end of the branch
        private void branchEndUI_Click(object sender, EventArgs e)
        {
            if (loaded)
            {
                while (engine.Cursor.Children.Count != 0)
                    engine.NextMove();

                currentMoveUI.Text = engine.CurrentMove.ToString();
                moveCursorUI();
            }
        }

        // Moving cursor to most recent main branch move
        private void gotoMainBranchUI_Click(object sender, EventArgs e)
        {
            if (loaded)
            {
                while (engine.Cursor.ID != Go.TreeSGF.rootID)
                    engine.PreviousMove();

                currentMoveUI.Text = engine.CurrentMove.ToString();
                moveCursorUI();
            }
        }

        #endregion
        #region helper functions

        // Updating Game Properties on the UI using the root of the gameTree
        private void UpdateGameProperties()
        {
            string value;
            if (loaded)
            {
                engine.Game.Root.RootProperties.TryGetValue("GN", out value);
                gameLabelUI.Text = value;
                engine.Game.Root.RootProperties.TryGetValue("RE", out value);
                resultLabelUI.Text = value;
                engine.Game.Root.RootProperties.TryGetValue("PB", out value);
                blackNameLabelUI.Text = value;
                engine.Game.Root.RootProperties.TryGetValue("BR", out value);
                blackRankLabelUI.Text = value;
                engine.Game.Root.RootProperties.TryGetValue("PW", out value);
                whiteNameLabelUI.Text = value;
                engine.Game.Root.RootProperties.TryGetValue("WR", out value);
                whiteRankLabelUI.Text = value;
            }
        }

        // Updating commentsUI ListBox based on current cursor
        private void UpdateComments()
        {
            if (engine.Cursor.Comment != "")
            {
                commentsUI.Items.Clear();
                commentsUI.Items.Add(engine.Cursor.Comment);
            }
        }

        // Updating UI to reflect cursor being set or moved to another node in the game tree
        private void moveCursorUI()
        {
            if (loaded)
            {
                toBranchUI.Text = engine.BranchNumber.ToString();
                branchLabelUI.Text = engine.Cursor.ID;
                UpdateComments();
                goBoardUI.Invalidate();
            }
        }

        #endregion
    }
}