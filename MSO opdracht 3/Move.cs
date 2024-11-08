namespace MSO_Opdracht_3
{
    // The Move class implements the ITask interface and defines a move command for a player
    public class Move : ITask
    {
        // The distance or number of steps the player should move
        public int Amount;

        // Constructor that sets the movement amount when a Move object is created
        public Move(int amount)
        {
            this.Amount = amount;
        }

        // Implementation of the Execute method from the ITask interface
        // It moves the player based on their current direction and the specified amount
        void ITask.Execute(Player player, IGrid grid)
        {
	        grid.AddVisitedPoint(player.Position);
			Point newPoint = new Point(0, 0);

			for (int i = 1; i <= Amount; i++)
			{
                // Switch statement to update the player's position depending on their current direction
                switch (player.Direction)
				{
                    case "North":
                        // Moving north increases the Y-coordinate
                        newPoint = new Point(player.Position.X, player.Position.Y + 1); break;
                    case "East":
                        // Moving east increases the X-coordinate
                        newPoint = new Point(player.Position.X + 1, player.Position.Y); break;
                    case "South":
                        // Moving south decreases the Y-coordinate
                        newPoint = new Point(player.Position.X, player.Position.Y - 1); break;
                    case "West":
                        // Moving west decreases the X-coordinate
                        newPoint = new Point(player.Position.X - 1, player.Position.Y); break;
                }
                if (grid.InsideBoard(newPoint))
                {
                    grid.AddVisitedPoint(newPoint);
                    player.Position = newPoint;
                }
                else if (grid is PathFindingGrid pathGrid && pathGrid.InsideWall(newPoint))
                {
                    throw new InvalidOperationException("Tried to move inside a wall");
                }
                else
                {
                    throw new InvalidOperationException("Tried to move outside the grid");
                }
            } 
        }

        // Override of the ToString method to return a string representation of the move command
        public override string ToString()
        {
            // Returns a description of the move, including the amount of movement
            return $"Move {Amount}, ";
        }
    }
}
