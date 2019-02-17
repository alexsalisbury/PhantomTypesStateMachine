namespace PhantomTypesStateMachine
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            IssueBackLog ib = new IssueBackLog();

#if item_was_not_immutable
            var item = ib.Create("Test Item", "Fake issue");
            item.Assign("Me");// <-- You're not capturing the new state since this function returns a new object. 
            item.Complete(); // <-- this data wouldn't have the "AssignedTo" property set
#endif
            // you couldn't do this, var is still static typing.
#if this_was_javascript
            var item = ib.Create("Test Item", "Fake issue");
            item = item.Assign("Me");// <-- You're not getting the current object back. 
            item = item.Complete();
#endif

            var s1 = ib.Create("Test Item", "Fake issue");
            var s2 = s1.Assign("Me");
            var s3 = s2.Complete(); // properly chained. I think this makes most sense on a web API.

            //Assert s3.dataStore["AssignedTo"] == "Me";

            Console.WriteLine("Hello World!");
        }
    }
}
