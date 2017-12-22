using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessCon.Game;

namespace ChessCon.Pieces {
    public class Queen : Piece {
        public Queen(string name, Color color, bool directionUp) : base(name, 0, 0, color, directionUp) {
        }
        public Queen(string name, int x, int y, Color color, bool directionUp) : base(name, x, y, color, directionUp) {
        }

        public List<Position> Movement(Func<int,int,bool> comparer) {
            var positions = new List<Position>();
            int i, j, k;
            for (i = this.PosY + 1; i < Board.SizeY; i++) {
                if (comparer.Invoke(this.PosX, i))
                    positions.Add(new Position(this.PosX, i));
                else
                    break;
            }
            for (i = this.PosX + 1; i < Board.SizeX; i++) {
                if (comparer.Invoke(i, this.PosY))
                    positions.Add(new Position(i, this.PosY));
                else
                    break;
            }
            for (i = this.PosY - 1; i >= 0; i--) {
                if (comparer.Invoke(this.PosX, i))
                    positions.Add(new Position(this.PosX, i));
                else
                    break;
            }
            for (i = this.PosX - 1; i >= 0; i--) {
                if (comparer.Invoke(i, this.PosY))
                    positions.Add(new Position(i, this.PosY));
                else
                    break;
            }

            i = PosX; j = PosY; k = j;
            while (i >= 0 && (j >= 0 || k < Board.SizeY)) {
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
        }
        public override List<Position> CanMove() {
            return Movement((i,j) => Board.IsEmpty(i,j));
        }
        public override List<Position> CanKill() {
            return Movement((i, j) => this.IsOpponent(Board.GetPiece(i, j)));
        }
    }
}
