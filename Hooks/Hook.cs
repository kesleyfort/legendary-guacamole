using SpecFlowProjectKesley.Drivers;

namespace SpecFlowProjectKesley.Hooks
{
    [Binding]
    public class Hooks
    {
        [AfterScenario]
        public static void AfterScenario(Driver browserDriver)
        {
            browserDriver.Current.Quit();
        }
    }
}