using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessCon.Game;

namespace ChessCon.Pieces {
    public class Rook : Piece {
        public Rook(string name, Color color, bool directionUp) : this(name, 0, 0, color, directionUp) {

        }

        public Rook(string name, int x, int y, Color color, bool directionUp) : base(name, x, y, color, directionUp) {

        }
        private List<Position> Movement(Func<int,int,bool> comparer) {
            var positions = new List<Position>();
            for (int i = this.PosY + 1; i < Board.SizeY; i++) {
                if (comparer.Invoke(this.PosX, i))
                    break;
                positions.Add(new Position(this.PosX, i));
            }
            for (int i = this.PosX + 1; i < Board.SizeX; i++) {
                if (comparer.Invoke(i, this.PosY))
                    break;
                positions.Add(new Position(i, this.PosY));
            }
            for (int i = this.PosY - 1; i >= 0; i--) {
                if (comparer.Invoke(this.PosX, i))
                    break;
                positions.Add(new Position(this.PosX, i));
            }
            for (int i = this.PosX - 1; i >= 0; i--) {
                if (comparer.Invoke(i, this.PosY))
                    break;
                positions.Add(new Position(i, this.PosY));
            }
            return positions;
        }
        public override List<Position> CanMove() {
            return Movement((i, j) => !Board.IsEmpty(i, j));
        }
        public override List<Position> CanKill() {
            //var positions = new List<Position>();
            //for (int i = this.PosY + 1; i < Board.SizeY; i++) {
            //    if (this.IsOpponent(Board.GetPiece(this.PosX,i)))
            //        break;
            //    positions.Add(new Position(this.PosX, i));
            //}
            //for (int i = this.PosX + 1; i < Board.SizeX; i++) {
            //    if (!Board.IsEmpty(i, this.PosY))
            //        break;
            //    positions.Add(new Position(i, this.PosY));
            //}
            //for (int i = this.PosY - 1; i >= 0; i--) {
            //    if (!Board.IsEmpty(this.PosX, i))
            //        break;
            //    positions.Add(new Position(this.PosX, i));
            //}
            //for (int i = this.PosX - 1; i >= 0; i--) {
            //    if (!Board.IsEmpty(i, this.PosY))
            //        break;
            //    positions.Add(new Position(i, this.PosY));
            //}
            return Movement((i, j) => this.IsOpponent(Board.GetPiece(i, j)));
        }
    }
}
