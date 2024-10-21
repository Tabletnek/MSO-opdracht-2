using System.Drawing;

namespace MSO_opdracht_3
{
	// Interface that's implemented by the different types of tasks
	public interface ITask
	{
		public void Execute(Player player, Board board); // Returns the player after the task is executed
	}
}
