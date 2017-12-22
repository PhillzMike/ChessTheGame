using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessCon.Game;
using System.Drawing;

namespace ChessCon.Pieces {
    public class Pawn : Piece {
        public Pawn(String name, Color color, bool directionUp):this(name,0,0,color, directionUp) {

        }
        public Pawn(string name, int x, int y, Color color, bool directionUp):base(name,x,y,color,directionUp){

        }
        public override List<Position> CanMove() {
            var positions = new List<Position>();
            if (!this.directionUp && Board.IsEmpty(this.PosX,this.PosY + 1)) {
                positions.Add(new Position(this.PosX, this.PosY + 1));
                if (!this.hasMoved && Board.IsEmpty(this.PosX, this.PosY + 2))
                    positions.Add(new Position(this.PosX, this.PosY + 2));
            } else if (this.directionUp && Board.IsEmpty(this.PosX, this.PosY - 1)) {
                positions.Add(new Position(this.PosX, this.PosY - 1));
                if (!this.hasMoved && Board.IsEmpty(this.PosX, this.PosY -2))
                    positions.Add(new Position(this.PosX, this.PosY - 2));
            }
            return positions;
        }
        public override List<Position> CanKill() {
            var positions = new List<Position>();
            if (!this.directionUp) {
                if(this.IsOpponent(Board.GetPiece(this.PosX + 1, this.PosY + 1)))
                    positions.Add(new Position(this.PosX+1, this.PosY + 1));
                if(this.IsOpponent(Board.GetPiece(this.PosX - 1,this.PosY + 1)))
                    positions.Add(new Position(this.PosX - 1, this.PosY + 1));
            } else {
                if (this.IsOpponent(Board.GetPiece(this.PosX + 1, this.PosY - 1)))
                    positions.Add(new Position(this.PosX + 1, this.PosY - 1));
                if (this.IsOpponent(Board.GetPiece(this.PosX - 1, this.PosY - 1)))
                    positions.Add(new Position(this.PosX - 1, this.PosY -1));
            }
            //TODO: ENPASAN
            return positions;
        }
    }
}
