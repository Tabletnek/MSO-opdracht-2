namespace MSO_Opdracht_3
{
    // The Turn class implements the ITask interface and turns the player either left or right
    public class Turn : ITask
    {
        public string Direction; 

        // Constructor to initialize the direction of the turn.
        public Turn(string direction)
        {
            this.Direction = direction;
        }

        // Executes the turn, updating the player's direction based on the current direction and the turn direction.
        void ITask.Execute(Player player, IGrid grid)
        {
            switch (Direction)
            {
                case "right":  // Handle turning right based on the current direction.
                    switch (player.Direction)
                    {
                        case "North":
                            player.Direction = "East";
							break;
						case "East":
                            player.Direction = "South";
							break;
						case "South":
                            player.Direction = "West";
							break;
						case "West":
                            player.Direction = "North";
							break;
					}
					break;
				case "left":  // Handle turning left based on the current direction.
                    switch (player.Direction)
                    {
                        case "North":
                            player.Direction = "West";
                            break;
                        case "East":
                            player.Direction = "North";
							break;
						case "South":
                            player.Direction = "East";
							break;
						case "West":
                            player.Direction = "South";
							break;
					}
				break;
			}
		}

        // Returns a string representation of the turn command.
        public override string ToString()
        {
            return $"Turn {this.Direction}, ";
        }
    }
}
