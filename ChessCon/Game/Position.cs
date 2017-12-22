using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCon.Game {
    public class Position {
        private int x;
        private int y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Position(int x, int y) {
            this.x = x;
            this.y = y;
        }
        public Position():this(0,0) {

        }
        public void SetPosition(Position x) {
            this.x = x.X;
            this.y = x.Y;
        }

    }
}
