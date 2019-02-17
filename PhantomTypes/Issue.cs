using System;
using System.Collections.Generic;

namespace PhantomTypesStateMachine
{
    public class Issue<TAssignableState, TBacklogState> : IAssignable<TAssignableState, Issue<Assigned, TBacklogState>>, ITodoable<TBacklogState, Issue<TAssignableState, Active>>, ICompletable<TBacklogState, Issue<TAssignableState, Complete>>
        where TAssignableState : IAssignedState
        where TBacklogState : IBacklogState
    {
        Dictionary<string, object> dataStore = new Dictionary<string, object>();
        public Guid Id { get; private set; }

        private Issue()
        {
        }

        public Issue(string title, string description)
        {
            this.Id = new Guid();
            this.dataStore["Title"] = title;
            this.dataStore["Description"] = description;
        }

        private void SetDataStore(Dictionary<string, object> ds)
        {
            this.dataStore = ds;
        }

        public Issue<Assigned, TBacklogState> Assign(string userName)
        {
            var i = new Issue<Assigned, TBacklogState>();
            i.Id = this.Id;
            i.SetDataStore(this.dataStore);
            i.dataStore["AssignedTo"] = userName;
            i.dataStore["AssignedOn"] = DateTime.UtcNow;
            return i;
        }

        public Issue<TAssignableState, Active> AddToSprint(string sprintIdentifier)
        {
            var i = new Issue<TAssignableState, Active>();
            i.SetDataStore(this.dataStore);
            i.dataStore["ActiveSprint"] = sprintIdentifier;
            i.dataStore["MovedToSprintOn"] = DateTime.UtcNow;
            return i;
        }

        public Issue<TAssignableState, Complete> Complete()
        {
            var i = new Issue<TAssignableState, Complete>();
            i.SetDataStore(this.dataStore);
            i.dataStore["CompletedOn"] = DateTime.UtcNow;
            return i;
        }
    }
}