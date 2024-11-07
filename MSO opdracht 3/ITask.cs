namespace MSO_Opdracht_3
{
	// Interface that's implemented by the different types of tasks
	public interface ITask
	{
		public void Execute(Player player, IGrid grid); // Returns the player after the task is executed
	}
}
