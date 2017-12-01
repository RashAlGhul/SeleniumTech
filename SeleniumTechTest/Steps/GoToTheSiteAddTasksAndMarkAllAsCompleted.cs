using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SeleniumTechTest.Steps
{
    [Binding]
    public class GoToTheSiteAddTasksAndMarkAllAsCompleted : BaseSteps
    {
        [Given(@"I navigate to the site and after I add tasks to todo list")]
        public void GivenIAddTasks()
        {
            NavigateToMainPage();
            steps.AddTask(taskList);
        }
        
        [When(@"I mark all tasks as completed")]
        public void WhenIMarkAllTasksAsCompleted()
        {
            steps.CompleteAllTasks();
        }
        
        [Then(@"I see no items left")]
        public void ThenINoItemsLeft()
        {            
            Assert.IsTrue(steps.IsAllTasksCompleted());
        }
        
        [Then(@"I see all tasks in completed menu")]
        public void ThenISeeAllTasksInCompletedMenu()
        {
            steps.GoToCompletedTasks();
            Assert.IsTrue(steps.IsAllTasksFromListAdded(taskList));
            EndTest();
        }
    }
}
