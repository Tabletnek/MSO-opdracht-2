using System;
using System.Collections.Generic;
using System.Drawing; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_2
{
    // The Player class represents a player in the game, including their position and direction
    public class Player
    {
        public Point position { get; set; }

        public string direction { get; set; }

        // Constructor to initialize a Player object with a starting position and direction.
        public Player(Point pos, string dir)
        {
            this.position = pos;  
            this.direction = dir;  
        }
    }
}
