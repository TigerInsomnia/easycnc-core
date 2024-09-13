using System.Security.Cryptography.X509Certificates;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace easycnc_core.Workflow
{
    public class AddNumberWorkflow : IWorkflow<MyDataClass>
    {
        public string Id => "AddNumber";

        public int Version => 1;

        public void Build(IWorkflowBuilder<MyDataClass> builder)
        {
            builder
                .StartWith<AddNum>()
                    .Input(step => step.Input1, data => data.Value1)
                    .Input(step => step.Input2, data => data.Value2)
                    .Output(data => data.Answer, step => step.Output)
                .Then<ShowMessage>()
                    .Input(step => step.Answer, data => data.Answer);

        }
    }

    public class MyDataClass
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Answer { get; set; }
    }

    public class AddNum : StepBody
    {
        public int Input1 { get; set; }
        public int Input2 { get; set; }
        public int Output { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Output=Input1+Input2;
            return ExecutionResult.Next();
        }
    }

    public class ShowMessage : StepBody
    {
        public int Answer { get; set; }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            
            Console.WriteLine("计算的结果是 : "+Answer.ToString());
            return ExecutionResult.Next();
        }
    }
}
