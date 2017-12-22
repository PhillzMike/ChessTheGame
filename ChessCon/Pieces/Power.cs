using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCon.Pieces {
    public class Power {
        private int moveX;
        private int moveY;
        private bool mul;
        private int killX;
        private int killY;
        private bool mul2;
        private bool canGoBack;

        public Power(int x, int y, bool mulitiple, bool canGoBack,int killx, int killy, bool multiple) {
            this.moveX = x;
            this.moveY = y;
            this.mul = mulitiple;
            this.killX = killx;
            this.killY = killy;
            this.mul2 = multiple;
            this.canGoBack = canGoBack;
        }
        public Power(int x, int y, bool mulitiple, bool canGoBack):this(x,y,mulitiple, canGoBack,0,0,false) {
            
            
        }

        public int X { get => moveX; }
        public int Y { get => moveY; }
        public int KillX { get => killX;}
        public int KillY { get => killY; }
        public bool Mul { get => mul; }
        public bool CanGoBack { get => canGoBack;  }
    }
}
