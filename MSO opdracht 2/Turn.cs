using System;
using System.Collections.Generic;
using System.Drawing;

namespace MSO_opdracht_2
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
        Player ITask.Execute(Player player)
        {
            switch (direction)
            {
                case "right":  // Handle turning right based on the current direction.
                    switch (player.direction)
                    {
                        case "North":
                            player.direction = "East";
                            return player;
                        case "East":
                            player.direction = "South";
                            return player;
                        case "South":
                            player.direction = "West";
                            return player;
                        case "West":
                            player.direction = "North";
                            return player;
                    }
                    return player;
                case "left":  // Handle turning left based on the current direction.
                    switch (player.direction)
                    {
                        case "North":
                            player.direction = "West";
                            return player;
                        case "East":
                            player.direction = "North";
                            return player;
                        case "South":
                            player.direction = "East";
                            return player;
                        case "West":
                            player.direction = "South";
                            return player;
                    }
                    return player;
            }
            return player;
        }

        // Returns a string representation of the turn command.
        public override string ToString()
        {
            return $"Turn {this.direction}, ";
        }
    }
}
