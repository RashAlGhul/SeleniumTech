using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SeleniumTechTest.Steps
{
    [Binding]
    public class GoToTheSiteAddTasksAndRemoveOneOfThem : BaseSteps
    {
        [Given(@"I navigate to the site and add new tasks to todo list")]
        public void GivenINavigateToTheSiteAndAddNewTasksToTodoList()
        {
            NavigateToMainPage();
            steps.AddTask(newTaskList);
        }
        
        [When(@"I remove one tasks from todo list")]
        public void WhenIRemoveOneTasksFromTodoList()
        {
            steps.RemoveTask(newTaskList[newTaskList.Count - 1]);
        }
        
        [Then(@"I see tasks without removed")]
        public void ThenISeeTasksWithoutRemoved()
        {
            Assert.IsTrue(steps.IsAllTasksFromListAdded(newTaskList.GetRange(0, taskList.Count - 2)));
            EndTest();
        }
    }
}
