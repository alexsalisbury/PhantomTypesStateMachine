namespace PhantomTypesStateMachine
{
    public interface IAssignedState
    {
    }

    public class Assigned : IAssignedState
    {
        private Assigned() { }
    }

    public class Unassigned : IAssignedState
    {
        private Unassigned() { }
    }

    public interface IAssignable<T, U> where T : IAssignedState
    {
        U Assign(string userName);
    }
}
