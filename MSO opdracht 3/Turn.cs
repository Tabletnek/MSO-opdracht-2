using System;
using System.Collections.Generic;
using System.Drawing;

namespace MSO_opdracht_3
{
    // The Turn class implements the ITask interface and turns the player either left or right
    public class Turn : ITask
    {
        public string direction; 

        // Constructor to initialize the direction of the turn.
        public Turn(string direction)
        {
            this.direction = direction;
        }

        // Executes the turn, updating the player's direction based on the current direction and the turn direction.
        void ITask.Execute(Player player, IGrid grid)
        {
            switch (direction)
            {
                case "right":  // Handle turning right based on the current direction.
                    switch (player.direction)
                    {
                        case "North":
                            player.direction = "East";
							break;
						case "East":
                            player.direction = "South";
							break;
						case "South":
                            player.direction = "West";
							break;
						case "West":
                            player.direction = "North";
							break;
					}
					break;
				case "left":  // Handle turning left based on the current direction.
                    switch (player.direction)
                    {
                        case "North":
                            player.direction = "West";
                            break;
                        case "East":
                            player.direction = "North";
							break;
						case "South":
                            player.direction = "East";
							break;
						case "West":
                            player.direction = "South";
							break;
					}
				break;
			}
		}

        // Returns a string representation of the turn command.
        public override string ToString()
        {
            return $"Turn {this.direction}, ";
        }
    }
}
