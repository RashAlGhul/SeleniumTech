using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SeleniumTechTest.Steps
{
    [Binding]
    public class GoToTheSiteAddTasksAndCompleteOneOfThem : BaseSteps
    {
        [Given(@"I navigate to the site and add some tasks to todo list")]
        public void GivenINavigateToTheSiteAndAddSomeTasksToTodoList()
        {
            NavigateToMainPage();
            steps.AddTask(taskList);
        }
        
        [When(@"I mark one task from todo list")]
        public void WhenIMarkTaskFromTodoList()
        {
            steps.MarkTask(taskList[0]);
        }
        
        [Then(@"I see tasks without marked at active menu and all tasks in all menu")]
        public void ThenITasksWithoutMarkedAtActiveMenuANdAllTasksInAllMenu()
        {
            steps.GoToActiveTasks();
            Assert.IsTrue(steps.IsAllTasksFromListAdded(taskList.GetRange(1, taskList.Count - 1)));
            steps.GoToAllTasks();
            Assert.IsTrue(steps.IsAllTasksFromListAdded(taskList));
            EndTest();
        }
    }
}
