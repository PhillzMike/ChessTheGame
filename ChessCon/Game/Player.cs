using ChessCon.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCon.Game {
    public class Player {
        private bool up;
        private bool onCheck;
        private bool turn;
        private List<Piece> pieces;
        private PlayerInfo playerinfo;
        private Color color;
        public Player(PlayerInfo playerinfo, Color color) {
            this.playerinfo = playerinfo;
            this.color = color;
        }

        public void Play(string positionFrom, string positionTo) {

        }
        public bool Up { get => up; set => up = value; }
        public bool OnCheck { get => onCheck; set => onCheck = value; }
        public bool Turn { get => turn; set => turn = value; }
    }
}
