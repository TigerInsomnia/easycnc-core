using WorkflowCore.Interface;

namespace easycnc_core.Workflow
{
    public class HumanWorkflow : IWorkflow
    {
        public string Id => "HumanWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
            .StartWith(context => Console.WriteLine("start"))
                .UserTask("Do you approve", data => "lisi")
                    .WithOption("yes", "I approve").Do(then => then
                        .StartWith(context => Console.WriteLine("You approved"))
                    )
                    .WithOption("no", "I do not approve").Do(then => then
                        .StartWith(context => Console.WriteLine("You did not approve"))
                    )
                .Then(context => Console.WriteLine("end"));
        }
    }
}
