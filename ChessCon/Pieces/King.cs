using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessCon.Game;

namespace ChessCon.Pieces {
    public class King : Piece {
        public King(string name, Color color, bool directionUp) : base(name, 0, 0, color, directionUp) {
        }
        public King(string name, int x, int y, Color color, bool directionUp) : base(name, x, y, color, directionUp) {
        }

        private List<Position> MovementWhenMoved(Func<int,int,bool> comparer) {
            var positions = new List<Position>();
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    if (comparer.Invoke(this.PosX + i, this.PosY+ j))
                        positions.Add(new Position(this.PosX + i, this.PosY + j));
                }
            }
            return positions;
        }
        public override List<Position> CanMove() {
            var positions = MovementWhenMoved((i, j) => Board.IsEmpty(i, j));
            //TODO : Castle
            if(!this.HasMoved) {
                if(Board.IsEmpty(PosX-2,PosY) && Board.IsEmpty(PosX - 1, PosY)) {

                }
            }
            return positions;
        }
        public override List<Position> CanKill() {
            return MovementWhenMoved((i, j) => this.IsOpponent(Board.GetPiece(i, j)));
        }
    }
}
