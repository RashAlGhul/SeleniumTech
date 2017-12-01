using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SeleniumTechTest.Steps
{
    [Binding]
    public class GoToSiteAndAddNewTasks : BaseSteps
    {     

        [Given(@"I navigate to the site")]
        public void GivenINavigateToTheSite()
        {
            NavigateToMainPage();
        }
        
        [When(@"I add new tasks")]
        public void WhenIAddNewTasks()
        {
            steps.AddTask(taskList);
        }
        
        [Then(@"I see all tasks at the todo list")]
        public void ThenISeeAllTasksAtTheTodoList()
        {
            Assert.IsTrue(steps.IsAllTasksFromListAdded(taskList));
            EndTest();
        }
    }
}
