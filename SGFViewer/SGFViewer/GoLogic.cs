// ********************************************************************************
// GoLogic - Logic for dealing with the basic game logic for a go board of any size
//
// Written by Jonathan Melcher
// Last updated Feb 08, 2015
// ********************************************************************************

#region using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace SGFViewer
{
    // ********************************************************************************
    // GoLogic class - contains methods for finding groups, amount of liberties, score,
    // and updating the board state of a Go board of any size.  Different rulesets are
    // not implemented yet.
    // ********************************************************************************
    public class GoLogic
    {
        #region static fields

        public enum state : byte { None, Black, White };

        #endregion
        #region non-static fields

        private state[,] goBoard;
        private int width;
        private int height;
        private int blackScore;
        private int whiteScore;

        #endregion
        #region constructor

        // Initializes logic with a set gamestate, and scores for black and white
        public GoLogic(state[,] gameState, int blackScore, int whiteScore)
        {
            goBoard = gameState;
            width = goBoard.GetLength(0);
            height = goBoard.GetLength(1);
            this.blackScore = blackScore;
            this.whiteScore = whiteScore;
        }

        #endregion
        #region properties

        public state[,] BoardState
        {
            get { return goBoard; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public int BScore
        {
            get { return blackScore; }
        }

        public int WScore
        {
            get { return whiteScore; }
        }

        #endregion
        #region methods for updating boardstate and score

        // Removing a stone from the board with the option of updating score
        public void ClearStone(Tuple<state, int, int> stone, bool toScore, ref int black, ref int white)
        {
            BoardState[stone.Item2, stone.Item3] = state.None;

            if (toScore)
                switch (stone.Item1)
                {
                    case state.Black:
                        white++;
                        break;
                    case state.White:
                        black++;
                        break;
                }
        }

        // Removing a group of stones from the board with the option of updating score (overloaded)
        public void ClearGroup(List<Tuple<state, int, int>> group, bool toScore, ref int black, ref int white)
        {
            foreach (Tuple<state, int, int> member in group)
                ClearStone(member, toScore, ref black, ref white);
        }

        // Removing a group of stones from the board with the option of updating score (overloaded)
        public void ClearGroup(HashSet<Tuple<state, int, int>> group, bool toScore, ref int black, ref int white)
        {
            foreach (Tuple<state, int, int> member in group)
                ClearStone(member, toScore, ref black, ref white);
        }

        #endregion
        #region methods for retrieving information on stones

        // Finding all the connected stones from a single member using breadth-first search
        // Connected stones are either vertical or horizontal on the board
        public List<Tuple<state, int, int>> GetGroup(Tuple<state, int, int> groupMember)
        {
            List<Tuple<state, int, int>> group = new List<Tuple<state, int, int>>();
            Stack<Tuple<state, int, int>> stack = new Stack<Tuple<state, int, int>>();
            stack.Push(groupMember);

            while (stack.Count != 0)
            {
                Tuple<state, int, int> currentMember = stack.Pop();
                group.Add(currentMember);

                for (int i = currentMember.Item2 - 1; i < currentMember.Item2 + 2; i += 2)
                {
                    if (i >= 0 && i < width)
                    {
                        if (group.Contains(Tuple.Create(goBoard[i, currentMember.Item3], i, currentMember.Item3)))
                            continue;
                        else if (goBoard[i, currentMember.Item3] == currentMember.Item1)
                            stack.Push(Tuple.Create(currentMember.Item1, i, currentMember.Item3));
                    }
                }
                for (int j = currentMember.Item3 - 1; j < currentMember.Item3 + 2; j += 2)
                {
                    if (j >= 0 && j < height)
                    {
                        if (group.Contains(Tuple.Create(goBoard[currentMember.Item2, j], currentMember.Item2, j)))
                            continue;
                        else if (goBoard[currentMember.Item2, j] == currentMember.Item1)
                            stack.Push(Tuple.Create(currentMember.Item1, currentMember.Item2, j));
                    }
                }
            }
            return group;
        }

        // Finding all the opponent stones that are directly adjacent to a specified move
        public List<Tuple<state, int, int>> GetAdjacentOpponentMoves(Tuple<state, int, int> move)
        {
            List<Tuple<state, int, int>> adjOpp = new List<Tuple<state, int, int>>();
            state oppositeOfMove = move.Item1 == state.Black ? state.White : state.Black;
            for (int i = move.Item2 - 1; i < move.Item2 + 2; i += 2)
                if (i >= 0 && i < width && goBoard[i, move.Item3] == oppositeOfMove)
                    adjOpp.Add(Tuple.Create(oppositeOfMove, i, move.Item3));

            for (int j = move.Item3 - 1; j < move.Item3 + 2; j += 2)
                if (j >= 0 && j < height && goBoard[move.Item2, j] == oppositeOfMove)
                    adjOpp.Add(Tuple.Create(oppositeOfMove, move.Item2, j));

            return adjOpp;
        }

        // Tallying the number of liberties of a group based on a single member
        public int GetLiberties(Tuple<state, int, int> coordinate)
        {
            int sum = 0;

            List<Tuple<state, int, int>> group = GetGroup(coordinate);

            foreach (Tuple<state, int, int> groupMember in group)
            {
                for (int i = groupMember.Item2 - 1; i < groupMember.Item2 + 2; i += 2)
                    if (i >= 0 && i < width && goBoard[i, groupMember.Item3] == state.None)
                        sum++;

                for (int j = groupMember.Item3 - 1; j < groupMember.Item3 + 2; j += 2)
                    if (j >= 0 && j < height && goBoard[groupMember.Item2, j] == state.None)
                        sum++;
            }
            return sum;
        }

        #endregion
    }
}
