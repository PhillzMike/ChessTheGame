using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessCon.Game;
using System.Drawing;

namespace ChessCon.Pieces {
    public class Knight : Piece {
        public Knight(String name, Color color, bool directionUp):this(name,0,0,color, directionUp) {

        }
        public Knight(string name, int x, int y, Color color, bool directionUp):base(name,x,y,color,directionUp){

        }
        private List<Position> Movement(Func<int,int,bool> comparer) {
            var positions = new List<Position>();
            for (int i = -2; i <= 2; i++) {
                for (int j = -2; j <= 2; j++) {
                    if (comparer.Invoke(i,j))
                        positions.Add(new Position(PosX + i, PosY + j));
                }
            }
            return positions;
        }
        public override List<Position> CanMove() {
            return Movement((i,j) => Math.Abs(i * j) == 2 && Board.IsEmpty(PosX + i, PosY + j));
        }
        public override List<Position> CanKill() {
            return Movement((i,j) => Math.Abs(i * j) == 2 && this.IsOpponent(Board.GetPiece(PosX + i, PosY + j)));
        }
    }
}
