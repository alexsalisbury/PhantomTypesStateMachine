namespace PhantomTypesStateMachine
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            IssueBackLog ib = new IssueBackLog();
            var item = ib.Create("Test Item", "Fake issue");
            item.Assign("Me");
            item.Complete();

            Console.WriteLine("Hello World!");
        }
    }
}
