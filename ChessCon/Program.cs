using ChessCon.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCon {
    class Program {
        static void Main(string[] args) {
            var board = new Board();
            board.Load();
            board.DisplayBoard();
            Console.Read();
        }
    }
}
