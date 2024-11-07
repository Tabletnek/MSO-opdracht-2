namespace MSO_Opdracht_3
{
	internal interface IRepeat : ITask
	{
		List<ITask> Tasks { get; }
		int StepsDone { get; }
		int StepsLimit { get; }
	}
}
