namespace Batonezas.WebApi.BusinessRules.TestCommands
{
    public class TestCommand : CommandBase
    {
        public int b { get; set; }

        public int result { get; set; }

        protected override void ExecuteCommand()
        {
            var a = 2;

            result = a + b;
        }
    }
}