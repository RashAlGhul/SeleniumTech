using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SeleniumTechTest.Steps
{
    [Binding]
    public class GoToTheSiteAddTasksAndEditThem : BaseSteps
    {

        [Given(@"I navigate to the site and after I add base tasks to todo list")]
        public void GivenAddTasks()
        {
            NavigateToMainPage();
            steps.AddTask(taskList);
        }
        
        [When(@"I edit tasks")]
        public void WhenIEditTasks()
        {
            steps.EditeToDoList(taskList, editedTaskList);
        }
        
        [Then(@"I see all tasks at the todo list are edited")]
        public void ThenISeeAllTasksAtTheTodoListAreEdited()
        {
            Assert.IsTrue(steps.IsAllTasksFromListAdded(editedTaskList));
            EndTest();
        }
    }
}
