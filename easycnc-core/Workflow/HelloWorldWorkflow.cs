using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace easycnc_core.Workflow
{
    public class HelloWorldWorkflow : IWorkflow
    {
        public string Id => "HelloWorld";

        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder.StartWith<Hello>()
                .Then<Goodbye>();
        }
    }

    public class Hello : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("hello world");
            return ExecutionResult.Next();
        }
    }

    public class Goodbye : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("goodbye world");
            return ExecutionResult.Next();
        }
    }
}
