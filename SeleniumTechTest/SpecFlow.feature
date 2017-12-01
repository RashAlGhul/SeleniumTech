Feature: SpecFlow

@add
Scenario: Go to the site and add new tasks
	Given I navigate to the site
	When I add new tasks
	Then I see all tasks at the todo list

@editAll
Scenario: Go to the site add tasks and edit them
	Given I navigate to the site and after I add base tasks to todo list
	When I edit tasks
	Then I see all tasks at the todo list are edited

@completeAll
Scenario: Go to the site add tasks and mark all as completed
	Given I navigate to the site and after I add tasks to todo list
	When I mark all tasks as completed
	Then I see no items left
	And I see all tasks in completed menu

@removeAll
Scenario: Go to the site add tasks and remove them
	Given I navigate to the site and after I add new tasks to todo list
	When I remove all tasks from todo list
	Then I see no task in the list

@completeSingleTask
Scenario: Go to the site add tasks and complete one of them
	Given I navigate to the site and add some tasks to todo list
	When I mark one task from todo list
	Then I see tasks without marked at active menu and all tasks in all menu

@removeSingleTask
Scenario: Go to the site add tasks and remove one them
	Given I navigate to the site and add new tasks to todo list
	When I remove one tasks from todo list
	Then I see tasks without removed