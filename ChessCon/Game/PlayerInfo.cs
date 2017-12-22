using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCon.Game {
    public class PlayerInfo {
        private string name;
        private int noOfGamesPlayed;
        private int noOfWins;
        private int noOfLosses;
        private int noOfDraws;
        private string profilePics;
        private int rating;

        public PlayerInfo(string name) {
            this.name = name;
        }
        public PlayerInfo(string name, string profilePics) {
            this.name = name;
            this.profilePics = profilePics;
        }
        public string Name { get => name; set => name = value; }
        public int NoOfGamesPlayed { get => noOfGamesPlayed; set => noOfGamesPlayed = value; }
        public int NoOfWins { get => noOfWins; set => noOfWins = value; }
        public int NoOfLosses { get => noOfLosses; set => noOfLosses = value; }
        public int NoOfDraws { get => noOfDraws; set => noOfDraws = value; }
        public string ProfilePics { get => profilePics; set => profilePics = value; }
        public int Rating { get => rating; set => rating = value; }
    }
}
