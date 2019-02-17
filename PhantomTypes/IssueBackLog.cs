namespace PhantomTypesStateMachine
{
    using System;
    using System.Collections.Generic;

    public class IssueBackLog
    {
        public Dictionary<Guid, Issue<Unassigned, InBacklog>> backlog = new Dictionary<Guid, Issue<Unassigned, InBacklog>>();
        public Dictionary<Guid, Issue<Assigned, Active>> active = new Dictionary<Guid, Issue<Assigned, Active>>();

        public IssueBackLog()
        {

        }

        public Issue<Unassigned, InBacklog> Create(string title, string description)
        {
            var i = new Issue<Unassigned, InBacklog>(title, description);
            backlog.Add(i.Id, i);
            return i;
        }

        public Issue<Assigned, Active> AddToSprint(Issue<Unassigned, InBacklog> issue, string username, string sprintIdentifier)
        {
            backlog.Remove(issue.Id);
            var assigned = issue.Assign(username);
            var result = assigned.AddToSprint(sprintIdentifier);
            active.Add(result.Id, result);
            return result;
        }

        public Issue<IAssignedState, Complete> Complete(Issue<IAssignedState, IBacklogState> issue)
        {
            bool found = false;

            if (backlog.ContainsKey(issue.Id))
            {
                backlog.Remove(issue.Id);
                found = true;
            }
            
            if (backlog.ContainsKey(issue.Id))
            {
                backlog.Remove(issue.Id);
                found = true;
            }

            if (!found)
            {
                throw new Exception(); // make a type for this
            }

            return issue.Complete();
        }
    }
}
