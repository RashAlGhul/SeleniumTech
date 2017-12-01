using OpenQA.Selenium;
using SeleniumTechTest.Pages;
using System.Collections.Generic;

namespace SeleniumTechTest.Steps
{
    public class MainPageSteps //wrapper over Main Page
    {
        private MainPage mainPage;
        public MainPageSteps(IWebDriver driver)
        {
            mainPage = new MainPage(driver);
        }

        public void GoToMainPage(string url)
        {
            mainPage.NavigateTo(url);
        }

        public void AddTask(List<string> taskList)
        {
            mainPage.AddTasks(taskList);
        }

        public void RemoveAllTasks()
        {
            mainPage.RemoveAllTasks();
        }

        public bool IsAllTasksRemoved()
        {
            return mainPage.IsAllTasksRemoved();
        }

        public void GoToAllTasks()
        {
            mainPage.GoToAllTasks();
        }

        public void GoToActiveTasks()
        {
            mainPage.GoToActiveTasks();
        }

        public void GoToCompletedTasks()
        {
            mainPage.GoToCompletedTasks();
        }

        public void CompleteAllTasks()
        {
            mainPage.CompleteAllTasks();
        }

        public bool IsAllTasksCompleted()
        {
            return mainPage.IsAllTasksCompleted();
        }

        public void EditTask(string oldTask, string newTask)
        {
            mainPage.EditTask(oldTask, newTask);
        }

        public void EditeToDoList(List<string> oldTaskList, List<string> newTaskList)
        {
            mainPage.EditToDoList(oldTaskList, newTaskList);
        }

        public void MarkTask(string task)
        {
            mainPage.MarkTask(task);
        }

        public void RemoveTask(string task)
        {
            mainPage.RemoveTask(task);
        }

        public bool IsAllTasksFromListAdded(List<string> tasks)
        {
            return mainPage.IsAllTasksFromListAdded(tasks);
        }
    }
}
