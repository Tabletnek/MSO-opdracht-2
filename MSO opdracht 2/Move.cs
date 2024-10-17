using System;
using System.Collections.Generic;
using System.Drawing;  
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_opdracht_2
{
    // The Move class implements the ITask interface and defines a move command for a player
    public class Move : ITask
    {
        // The distance or number of steps the player should move
        public int amount;

        // Constructor that sets the movement amount when a Move object is created
        public Move(int amount)
        {
            this.amount = amount;
        }

        // Implementation of the Execute method from the ITask interface
        // It moves the player based on their current direction and the specified amount
        Player ITask.Execute(Player player)
        {
            // Switch statement to update the player's position depending on their current direction
            switch (player.direction)
            {
                case "North":
                    // Moving north increases the Y-coordinate
                    player.position = new Point(player.position.X, player.position.Y + amount);
                    return player;
                case "East":
                    // Moving east increases the X-coordinate
                    player.position = new Point(player.position.X + amount, player.position.Y);
                    return player;
                case "South":
                    // Moving south decreases the Y-coordinate
                    player.position = new Point(player.position.X, player.position.Y - amount);
                    return player;
                case "West":
                    // Moving west decreases the X-coordinate
                    player.position = new Point(player.position.X - amount, player.position.Y);
                    return player;
            }
            // Return the updated player position after moving
            return player;
        }

        // Override of the ToString method to return a string representation of the move command
        public override string ToString()
        {
            // Returns a description of the move, including the amount of movement
            return $"Move {amount}, ";
        }
    }
}
