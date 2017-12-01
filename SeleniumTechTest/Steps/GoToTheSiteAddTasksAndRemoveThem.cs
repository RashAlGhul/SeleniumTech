using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SeleniumTechTest.Steps
{
    [Binding]
    public class GoToTheSiteAddTasksAndRemoveThem:BaseSteps
    {
        
        [Given(@"I navigate to the site and after I add new tasks to todo list")]
        public void GivenIAddTasks()
        {
            NavigateToMainPage();
            steps.AddTask(newTaskList);
        }

        [When(@"I remove all tasks from todo list")]
        public void WhenIRemoveAllTasksFromTodoList()
        {
            steps.RemoveAllTasks();
        }

        [Then(@"I see no task in the list")]
        public void ThenISeeAllTasksInCompletedMenu()
        {
            Assert.IsTrue(steps.IsAllTasksRemoved());
            EndTest();
        }
    }
}
