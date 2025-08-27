using DesignPatternsProject.Enum;
using DesignPatternsProject.Models;

#region  Create users
List<User> users = new List<User>(){
new User("Avi","a100@gmail.com",Roles.Manager),
new User("Yossi", "y101@gmail.com", Roles.Manager),
new User("Dani", "d102@gmail.com", Roles.Manager),
new User("Yoel", "y200@gmail.com", Roles.Developer),
new User("Gad", "g201@gmail.com", Roles.Developer),
new User("Shimon", "s202@gmail.com", Roles.Developer),
new User("Moshe","m300@gmail.com",Roles.QA),
new User("Yehuda","y301@gmail.com",Roles.QA),
new User("David","d302@gmail.com",Roles.QA)
};
#endregion

#region Create tasks with Builder 
TaskBuilder taskBuilder1 = new TaskBuilder("New feature development");
taskBuilder1.BuildDescription("Developing a new feature for a task management system");
taskBuilder1.BuildAssignee(users[4].Name, users[4].Email, users[4].Role);
taskBuilder1.BuildReporter(users[5].Name, users[5].Email, users[5].Role);
taskBuilder1.BuildReporter(users[1].Name, users[1].Email, users[1].Role);
taskBuilder1.BuildPriority(Priority.Low);
taskBuilder1.BuildEstimationTime(20);
TaskManager task1 = taskBuilder1.Build();

TaskBuilder taskBuilder4 = new TaskBuilder("Full stack project");
taskBuilder4.BuildDescription("A new apllication");
taskBuilder4.BuildAssignee(users[8].Name, users[8].Email, users[8].Role);
taskBuilder4.BuildReporter(users[0].Name, users[0].Email, users[0].Role);
taskBuilder4.BuildPriority(Priority.Medium);
taskBuilder4.BuildEstimationTime(1);
TaskManager task4 = taskBuilder4.Build();

TaskBuilder taskBuilder2 = new TaskBuilder("New DataBase");
taskBuilder2.BuildDescription("Creating a database");
taskBuilder2.BuildAssignee(users[5].Name, users[5].Email, users[5].Role);
taskBuilder2.BuildReporter(users[2].Name, users[2].Email, users[2].Role);
taskBuilder2.BuildPriority(Priority.High);
taskBuilder2.BuildEstimationTime(30);
taskBuilder2.BuildSubTask(task1);
taskBuilder2.BuildSubTask(task4);
TaskManager task2 = taskBuilder2.Build();

TaskBuilder taskBuilder3 = new TaskBuilder("AI project");
taskBuilder3.BuildDescription("Artificial Intelligence Development Project");
taskBuilder3.BuildAssignee(users[1].Name, users[1].Email, users[1].Role);
taskBuilder3.BuildReporter(users[0].Name, users[0].Email, users[0].Role);
taskBuilder3.BuildPriority(Priority.Medium);
taskBuilder3.BuildEstimationTime(100);
taskBuilder3.BuildSubTask(task2);
TaskManager task3 = taskBuilder3.Build();

#endregion

// Printing task details
Console.WriteLine("task1 details:");
task1.PrintTaskDetails();

// Task1 workflow
task1.ActionOnTask();
task1.AdvanceStatus(users[4]);
task1.ActionOnTask();
task1.AdvanceStatus(users[4]);
task1.ActionOnTask();
task1.AdvanceStatus(users[3]);
task1.ActionOnTask();
task1.AdvanceStatus(users[2]);
task1.ActionOnTask();
task1.AdvanceStatus(users[3]);
task1.ActionOnTask();
task1.AdvanceStatus(users[6]);
task1.ActionOnTask();
task1.AdvanceStatus(users[4]);

Console.WriteLine($"Task1 estimatiom time is: {task1.GetEstimationTime()}");
Console.WriteLine($"Task1 logged time is: {task1.GetLoggedTime()}");

Console.WriteLine($"Task2 estimatiom time is: {task2.GetEstimationTime()}");
Console.WriteLine($"Task2 logged time is: {task2.GetLoggedTime()}");

Console.WriteLine($"Task4 estimatiom time is: {task4.GetEstimationTime()}");
Console.WriteLine($"Task4 logged time is: {task4.GetLoggedTime()}");

//task1.AddLoggedTime(10);
//task4.AddLoggedTime(12);
Console.WriteLine($"Task1 logged time is: {task1.GetLoggedTime()}");

Console.WriteLine($"Task3 estimatiom time is: {task3.GetEstimationTime()}");
Console.WriteLine($"Task3 logged time is: {task3.GetLoggedTime()}");

// Check the history
Console.WriteLine("Undo:");
Console.WriteLine($"Task1 estimatiom time is: {task1.GetEstimationTime()}");
task1.AddSubTask(task4);
Console.WriteLine($"Task1 estimatiom time is: {task1.GetEstimationTime()}");
task1.Undo();
Console.WriteLine($"Task1 estimatiom time is: {task1.GetEstimationTime()}");

task1.Undo();
task1.Undo();
task1.Undo();
task1.Undo();
task1.Undo();
task1.Undo();

task1.ActionOnTask();
task1.AdvanceStatus(users[4]);
task1.ActionOnTask();
task1.Undo();
task1.ActionOnTask();

Console.WriteLine($"Task1 logged time is: {task1.GetLoggedTime()}");
task1.AddLoggedTime(12);
Console.WriteLine($"Task1 logged time is: {task1.GetLoggedTime()}");
task1.Undo();
Console.WriteLine($"Task1 logged time is: {task1.GetLoggedTime()}");


Console.WriteLine($"Task3 logged time is: {task3.GetLoggedTime()}");
task2.AddLoggedTime(12);
Console.WriteLine($"Task2 logged time is: {task2.GetLoggedTime()}");
task2.Undo();
Console.WriteLine($"Task2 logged time is: {task2.GetLoggedTime()}");
Console.WriteLine($"Task3 logged time is: {task3.GetLoggedTime()}");


Console.WriteLine($"Task1 estimatiom time is: {task1.GetEstimationTime()}");
task1.AddSubTask(task4);
Console.WriteLine($"Task1 estimatiom time is: {task1.GetEstimationTime()}");
task1.Undo();
Console.WriteLine($"Task1 estimatiom time is: {task1.GetEstimationTime()}");


task1.Receive(users[0]);
task1.AddLoggedTime(1);
task1.Undo();
task1.Undo();
task1.AddLoggedTime(2);

task1.ChangePriority(Priority.High);
task1.Undo();

task1.ChangeAssignee(users[5]);
task1.Undo();

task1.ChangeEstimationTime(1);
task1.Undo();

Console.WriteLine("task1 details:");
task1.PrintTaskDetails();

// View the history
task4.ChangePriority(Priority.High);
task4.ChangeAssignee(users[7]);
task4.AdvanceStatus(users[8]);
task4.AddSubTask(task1);
task4.ChangeEstimationTime(10);
task4.ShowHistory();






