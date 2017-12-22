using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessCon.Game;

namespace ChessCon.Pieces {
    public class Bishop : Piece {
        public Bishop(string name, Color color, bool directionUp) : this(name, 0, 0, color, directionUp) {

        }
        public Bishop(string name, int x, int y, Color color, bool directionUp) : base(name, x, y, color, directionUp) {
        }

        private List<Position> Movement(Func<int,int,bool> comparer) {
            var positions = new List<Position>();
            int i = PosX, j = PosY, k = j;
            while (i >= 0 && (j >= 0 || k < Board.SizeY)) {
                if (comparer.Invoke(i,j)) {
                    positions.Add(new Position(i, j));
                    j--;
                }
                if (comparer.Invoke(i, k)) {
                    positions.Add(new Position(i, k));
                    k--;
                }
                i--;
            }
            //while (i >= 0 && j < Board.SizeY) {
            //    if (!Board.IsEmpty(i, j))
            //        break;
            //    positions.Add(new Position(i, j));
            //    i--;
            //    j--;
            //}
            i = PosX; j = PosY; k = j;
            while (i < Board.SizeX && (j >= 0 || k < Board.SizeY)) {
                if (comparer.Invoke(i, j)) {
                    positions.Add(new Position(i, j));
                    j--;
                }
                if (comparer.Invoke(i, k)) {
                    positions.Add(new Position(i, k));
                    k--;
                }
                i--;
            }
            return positions;
            //while (i < Board.SizeX && j < Board.SizeY) {
            //    if (!Board.IsEmpty(i, j))
            //        break;
            //    positions.Add(new Position(i, j));
            //    i--;
            //    j--;
            //}
        }

        public override List<Position> CanMove() {
            return Movement((i, j) => Board.IsEmpty(i, j));
        }
        public override List<Position> CanKill() {
            return Movement((i, j) => this.IsOpponent(Board.GetPiece(i, j)));
        }
    }
}
