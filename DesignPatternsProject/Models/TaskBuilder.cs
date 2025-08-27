using DesignPatternsProject.Enum;
using DesignPatternsProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Models;

public class TaskBuilder 
{
    DateTime? creationDate = null;
    string? title = null;
    string? description = null;
    User? assignee = null;
    User? reporter = null;
    Priority? priority = null;
    float? estimationTime = null;
    float? loggedTime = null;
    List<TaskManager>? subTasks = null;
    public TaskBuilder(string title)
    {
        this.title = title;
        creationDate = DateTime.Now;
        loggedTime = 0;
    }
    public void BuildDescription(string description)
    {
        this.description = description;
    }
    public void BuildAssignee(string name, string email, Roles role)
    {
        assignee = new User(name, email, role);
    }
    public void BuildReporter(string name, string email, Roles role)
    {
        if (role != Roles.Manager)
        {
            Console.WriteLine("ERROR.Only a manager can assign a task.");
            return;
        }
        reporter = new User(name, email, role);
    }
    public void BuildPriority(Priority priority)
    {
        this.priority = priority;
    }
    public void BuildEstimationTime(float estimationTime)
    {
        this.estimationTime= estimationTime;    
    }
    public void BuildSubTask(TaskManager task)
    {
        if (subTasks == null)
        {
            subTasks = new List<TaskManager>();
            estimationTime = 0;
        }
        subTasks.Add(task);
        estimationTime += task.GetEstimationTime();
    }

    public TaskManager Build()
    {
        if (description == null || assignee == null || reporter == null || priority == null || (subTasks==null && estimationTime == null))
            throw new Exception("Can't craet a task");
        Task1 task =  new Task1()
        {
          CreationDate =(DateTime)creationDate,
          Title=title,
          Description = description,
          Assignee = assignee,
          Reporter = reporter,
          receivers = new List<IReceiver>() { reporter, assignee },
          Priority =(Priority)priority,
          SubTasks=subTasks,
          EstimationTime= (float)estimationTime
        };
        Console.WriteLine("The task was created successfully.");
        return new TaskManager(task);
    }



}
