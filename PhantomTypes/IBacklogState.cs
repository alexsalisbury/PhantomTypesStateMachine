namespace PhantomTypesStateMachine
{
    public interface IBacklogState
    {
    }

    public class InBacklog : IBacklogState
    {
        private InBacklog() { }
    }

    public class Active : IBacklogState
    {
        private Active() { }
    }

    public class Complete : IBacklogState
    {
        private Complete() { }
    }

    public interface ITodoable<T, U> where T : IBacklogState
    {
        U AddToSprint(string sprintIdentifier);
    }

    public interface ICompletable<T, U> where T : IBacklogState
    {
        U Complete();
    }
}
