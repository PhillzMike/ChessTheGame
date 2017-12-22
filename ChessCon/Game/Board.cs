using ChessCon.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ChessCon.Game {
    public class Board {
        private List<Piece>[] allPieces;
        private List<Piece> player1;
        private List<Piece> player2;
        private int sizeX;
        private int sizeY;
        private King player1King;
        private King player2King;
        Piece[,] board;
        public Board() {
            allPieces = new List<Piece>[2];
            player1 = new List<Piece>();
            player2 = new List<Piece>();
            allPieces[0] = player1;
            allPieces[1] = player2;
            this.sizeX = 8;
            this.sizeY = 8;
            board = new Piece[8,8];
        }
        public void Load() {
            for(int i = 0; i < this.SizeX; i++) {
                player1.Add(new Pawn("Pawn",i,1,Color.Black, false));
                player2.Add(new Pawn("Pawn",i,6, Color.White, true));
            }
            player1King = new King("King", 3, 0, Color.Black, false);
            player1.Add(new Rook("Rook",0,0, Color.Black, false));
            player1.Add(new Knight("Knight",1,0, Color.Black, false));
            player1.Add(new Bishop("Bishop",2,0, Color.Black, false));
            player1.Add(new Queen("Queen",4,0, Color.Black, false));
            player1.Add(player1King);
            player1.Add(new Rook("Rook",7,0 ,Color.Black, false));
            player1.Add(new Knight("Knight",6,0 ,Color.Black, false));
            player1.Add(new Bishop("Bishop",5,0, Color.Black, false));

            player2King = new King("King", 4, 7, Color.White, false);
            player2.Add(new Rook("Rook", 0,7, Color.White, false));
            player2.Add(new Knight("Knight",1, 7, Color.White, false));
            player2.Add(new Bishop("Bishop",2, 7, Color.White, false));
            player2.Add(new Queen("Queen", 3,7, Color.White, false));
            player2.Add(player2King);
            player2.Add(new Rook("Rook", 7, 7, Color.White, false));
            player2.Add(new Knight("Knight",6, 7, Color.White, false));
            player2.Add(new Bishop("Bishop",5, 7, Color.White, false));

            foreach (var list in allPieces) {
                foreach (var item in list) {
                    board[item.PosX, item.PosY] = item;
                }
            }

        }


        /// <summary>
        /// Gets the piece.
        /// </summary>
        /// <param name="positionTo">The position to.</param>
        /// <returns></returns>
        public Piece GetPiece(int x, int y) {
            //TODO: Make this guy immutable
            return board[x,y];
        }
        public bool IsEmpty(int x, int y) {
            return GetPiece(x,y) == null;
        }
        public String[,] GetBoard() {
            var board = new String[SizeX,SizeY];
            foreach (var list in allPieces) {
                foreach (var item in list) {
                    board[item.PosX,item.PosY] = item.ToString();
                }
            }
            return board;
        }
        public void DisplayBoard() {
            var board = GetBoard();
            for (int i = 0; i < SizeX; i++) {
                for (int j = 0; j < SizeY; j++) {
                    Console.Write(board[j, i] + " ");
                }
                Console.WriteLine();
            }
        }
        public void MoveTo(int x, int y, int x1, int y1) {
            if (!IsEmpty(x, y)) {
                var piece = GetPiece(x, y);
                if(!(piece is King) && !OnCheck()) {
                    piece.MoveTo(new Position(x1, y1));
                    board[x1, y1] = board[x, y];
                    board[x, y] = null;
                }
                if (OnCheck()) {
                    piece.PosX = x;
                    piece.PosY = y;

                }
            }
        }

        public bool OnCheck() {
            var positionsToCheck = new HashSet<Position>();
            for(int i = -1; i <= 1; i++) {
                for(int j = -1; j <= 1; j++) {
                    if (!player1King.IsTeamMate(GetPiece(player1King.PosX + i, player1King.PosY + j)))
                        positionsToCheck.Add(new Position(player1King.PosX + i, player1King.PosY + j));
                }
            }
            foreach (var item in player2) {
                foreach (var pos in item.CanKill()) {
                    if (positionsToCheck.Contains(pos))
                        return true;
                }
            }
            return false;
        }

        public int SizeX { get => sizeX; set => sizeX = value; }
        public int SizeY { get => sizeY; set => sizeY = value; }
    }
}
