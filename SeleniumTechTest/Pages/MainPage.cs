using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;


namespace SeleniumTechTest.Pages
{
    public class MainPage : BasePage
    {
        private readonly By newTask = By.XPath("//input[@id='new-todo']"); //input task field
        private readonly By toDoList = By.XPath("//div[@class='view']//label"); //all labels with tasks on the page
        private readonly By destroyButton = By.XPath("//button[@class='destroy'][@ng-click='removeTodo(todo)']"); //destroy buuton which enable when you select task
        private readonly By markAllTaskToggle = By.XPath("//input[@id='toggle-all']");//toggle which mark all tasks as completed
        private readonly By markTaskToggle = By.XPath("//div[@class='view']//input");//toggle which mark single task as completed
        private readonly By allTasksMenu = By.XPath("//a[contains(text(),'All')]");//all tasks menu button
        private readonly By activeTasksMenu = By.XPath("//a[contains(text(),'Active')]");//active tasks menu button
        private readonly By completedTasksMenu = By.XPath("//a[contains(text(),'Completed')]");//completed tasks menu button
        private readonly By tasksLeftCount = By.XPath("//span[@id='todo-count']//strong");//item left label
        private readonly By editField = By.XPath("//form[@ng-submit=\"saveEdits(todo, 'submit')\"]//input");//field which enable when you edit task
        private int taskNumber = 0; //counter for the list of tasks to be edited
        public MainPage(IWebDriver driver) : base(driver) { }
        
        public void AddTasks(List<string> taskList)//add all tasks from list to 
        {
            foreach (string task in taskList)
            {
                driver.FindElement(newTask).SendKeys($@"{task}{ Keys.Return}");
            }
        }

        public void EditToDoList(List <string> oldTaskList, List<string> newTaskList)//edit all tasks from the old list
        {
            for (int i = 0; i < oldTaskList.Count; i++)
            {
                taskNumber = i;
                EditTask(oldTaskList[i],newTaskList[i]);
            }
            taskNumber = 0;
        }

        public void RemoveAllTasks()//clear todo list
        {
            IReadOnlyList<IWebElement> taskList = driver.FindElements(toDoList);
            taskList[0].Click();
            for (int i = 1; i < taskList.Count + 1; i++)
            {
                driver.FindElement(destroyButton).Click();
            }
        }

        public void RemoveTask(string task)//remove one task from todo list
        {
            IReadOnlyList<IWebElement> taskList = driver.FindElements(toDoList);
            for (int i = 0; i < taskList.Count; i++)
            {
                if (taskList[i].Text.Equals(task))
                {
                    new Actions(driver).MoveToElement(taskList[i]).Click().Perform();
                    new Actions(driver).Click(driver.FindElement(destroyButton)).Perform();
                }
            }
        }

        public bool IsAllTasksRemoved()//verify that todo list clear
        {
            return driver.FindElements(toDoList).Count == 0;
        }

        public void GoToAllTasks()//click to all button
        {
            driver.FindElement(allTasksMenu).Click();
        }

        public void GoToActiveTasks()//click to active button
        {
            driver.FindElement(activeTasksMenu).Click();
        }

        public void GoToCompletedTasks()//click to completed button
        {
            driver.FindElement(completedTasksMenu).Click();
        }

        public void CompleteAllTasks()//click to complete all task button
        {
            driver.FindElement(markAllTaskToggle).Click();
        }

        public bool IsAllTasksCompleted()//verify that all tasks mark as completed
        {
            return driver.FindElement(tasksLeftCount).Text.Equals("0");
        }

        public void EditTask(string oldTask, string newTask)//change old task to new
        {
            By taskForEdit = By.XPath($@"//label[contains(text(),'{oldTask}')]");
            new Actions(driver).DoubleClick(driver.FindElement(taskForEdit)).Perform();
            driver.FindElements(editField)[taskNumber].Clear();
            driver.FindElements(editField)[taskNumber].SendKeys($@"{newTask}{Keys.Return}");            
        }

        public void MarkTask(string task)//mark single task as completed
        {
            IReadOnlyList<IWebElement> tasksList = driver.FindElements(toDoList);
            IReadOnlyList<IWebElement> marksList = driver.FindElements(markTaskToggle);
            for (int i = 0; i < tasksList.Count; i++)
            {
                if (tasksList[i].Text.Equals(task))
                {
                    marksList[i].Click();
                }
            }
        }

        public bool IsAllTasksFromListAdded(List<string> tasks)////verify that all tasks from list added to todo list
        {
            IReadOnlyList<IWebElement> taskList = driver.FindElements(toDoList);
            for (int i = 0; i < taskList.Count; i++)
            {
                foreach (string task in tasks)
                {
                    if (taskList[i].Text.Equals(task))
                    {
                        tasks.Remove(task);
                        break;
                    }
                }
            }
            return tasks.Count == 0;
        }
    }
}
