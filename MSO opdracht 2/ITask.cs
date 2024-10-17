using System.Drawing;

namespace MSO_opdracht_2
{
	// Interface that's implemented by the different types of tasks
	public interface ITask
	{
		public Player Execute(Player player); // Returns the player after the task is executed
	}
}
