using ChessCon.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ChessCon.Pieces {
    public abstract class Piece {
        private Position pos;
        protected bool hasMoved;
        private Color color;
        protected readonly bool directionUp;
        private static Board board;
        private string name;
        private bool isAlive;
        //private Piece(String name, Color color,bool directionUp):this(name,0,0,color, directionUp) {

        //}
        public Piece(string name,int x,int y,Color color, bool directionUp){
            this.name = name;
            pos = new Position(x, y);
            this.hasMoved = false;
            this.color = color;
            this.directionUp = directionUp;
            this.isAlive = true;
        }
        //public Piece(IEnumerable<Power> powers,int x,int y, Color color, bool directionUp) {
        //    this.powers = new List<Power>(powers);
        //    this.hasMoved = false;
        //    pos = new Position(x, y);
        //    this.color = color;
        //    this.directionUp = directionUp;
        //}


        /// <summary>
        /// Moves this piece to positionTo
        /// </summary>
        /// <param name="positionTo">The position the piece would be moved to.</param>
        /// <exception cref="ArgumentException"> when the piece cannot move to the positionTo</exception>
        public void MoveTo(Position positionTo) {
            if (this.CheckPosition(() => CanMove(),positionTo)) {
                //TODO Remember to check for check
                pos.SetPosition(positionTo);
                this.hasMoved = true;
            } else
                throw new ArgumentException(this.ToString() + "cannot move to this point");
        }
        public void Kill(Piece piece) {
            if(this.CheckPosition(() => CanKill(),piece.pos)){
                //TODO Remember to check for check
                pos.SetPosition(piece.pos);
            }
        }
        private bool CheckPosition(Func<List<Position>> list, Position positionTo) {
            foreach (Position item in list.Invoke()) {
                if (positionTo.Equals(item))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Determines whether the specified piece is opponent.
        /// </summary>
        /// <param name="piece">The piece.</param>
        /// <returns>
        ///   <c>true</c> if the specified piece is opponent; otherwise and also if piece is null <c>false</c>.
        /// </returns>
        public bool IsOpponent(Piece piece) {
            if (piece == null)
                return false;
            else
                return !piece.Color.Equals(this.Color);
        }
        public void UndoMove(Position positionTo) {
            this.PosX = positionTo.X;
            this.PosY = positionTo.Y;
        }
        public void UndoKill(Piece piece) {

        }
        /// <summary>
        /// Determines whether [is team mate] [the specified piece].
        /// </summary>
        /// <param name="piece">The piece.</param>
        /// <returns>
        ///   <c>true</c> if [is team mate] [the specified piece]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsTeamMate(Piece piece) {
            if (piece == null)
                return false;
            else
                return piece.Color.Equals(this.Color);
        }
        /// <summary>
        /// Returns the List of positions this piece can move to
        /// </summary>
        /// <returns> A List of positions this piece can move to</returns>
        public abstract List<Position> CanMove();
        /// <summary>
        /// Returns the list of positions this piece can kill
        /// </summary>
        /// <returns></returns>
        public abstract List<Position> CanKill();
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public sealed override string ToString() {
            return (this.Color.Name.First().ToString() + this.Name.First()).ToLower(); 
        }
        /// <summary>
        /// Gets the name of this piece
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String Name { get => name; }
        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public Color Color { get => color; }
        /// <summary>
        /// Gets a value indicating whether this piece has moved since the game started.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has moved; otherwise, <c>false</c>.
        /// </value>
        public bool HasMoved { get => hasMoved; }
        /// <summary>
        /// Gets or sets the position x on the board.
        /// </summary>
        /// <value>
        /// The position x.
        /// </value>
        public int PosX { get => pos.X; set => pos.X = value; }
        /// <summary>
        /// Gets or sets the position y on the board.
        /// </summary>
        /// <value>
        /// The position y.
        /// </value>
        public int PosY { get => pos.Y; set => pos.Y = value; }
        /// <summary>
        /// Gets the board.
        /// </summary>
        /// <value>
        /// The board.
        /// </value>
        internal static Board Board { get => board; }
        /// <summary>
        /// Gets a value indicating whether this instance is alive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is alive; otherwise, <c>false</c>.
        /// </value>
        public bool IsAlive => isAlive;
    }
}
