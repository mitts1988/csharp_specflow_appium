using MyQHMobileAutomation.Drivers;
using System;
using TechTalk.SpecFlow;

namespace MyQHMobileAutomation.Hooks
{
    [Binding]
    public class Hooks
    {
        [Before]
        public void Initialize()
        {
            Console.WriteLine("Initializing Driver");
            MyQHAndroidDriver.InitializeDriver();
            Console.WriteLine("Driver started");
        }

        [After]
        public void Quit()
        {
            Console.WriteLine("Quitting Driver");
            MyQHAndroidDriver.Quit();
        }
    }
}
