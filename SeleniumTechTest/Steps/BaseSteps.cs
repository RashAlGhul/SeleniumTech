using OpenQA.Selenium;
using System.Collections.Generic;

namespace SeleniumTechTest.Steps
{
    public class BaseSteps
    {
        protected List<string> taskList = new List<string>(TestData.BaseTasks.Split('+'));
        protected List<string> newTaskList = new List<string>(TestData.NewTasks.Split('+'));
        protected List<string> editedTaskList = new List<string>(TestData.EditedTasks.Split('+'));

        protected IWebDriver driver;
        protected MainPageSteps steps;
        protected void NavigateToMainPage()//initialize driver and navigate to main page
        {
            IWebDriver Driver = WebDriverConcurrent.InitDriver(this.GetType());
            steps = new MainPageSteps(Driver);
            steps.GoToMainPage(TestData.BaseUrl);
        }

        protected void EndTest()//remove driver from dictinary
        {
            WebDriverConcurrent.KillDriver(GetType());
        }
    }
}
