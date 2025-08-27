using DesignPatternsProject.Enum;
using DesignPatternsProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Models;

public class TaskManager
{
    private Task1 task;
    private Stack<IDuplicate> historyStack;
    public TaskManager(Task1 task)
    {
        historyStack = new Stack<IDuplicate>();
        this.task = task;
        this.task.status=new ToDoStatus(this);
    }
    public void AddSubTask(TaskManager subtask)
    {
       historyStack.Push(task.CreateBackup());
       task.AddSubTask(subtask);
       task.Notify($"A subtask was added and the estimated time was updated in '{task.Title}' task.");
    }

    public void AdvanceStatus(User assignee)
    {
        task.AdvanceStatus(assignee);
    }
    public void SetStatus(IStatus status)
    {
        historyStack.Push(task.CreateBackup());
        task.SetStatus(status);
        task.Notify($"Status changed to the next status in '{task.Title}' task.");
    }

    public void ActionOnTask()
    {
        task.ActionOnTask();
    }

    public void ChangePriority(Priority priority)
    {
        historyStack.Push(task.CreateBackup());
        task.ChangePriority(priority);
        task.Notify($"Priority changed in '{task.Title}' task.");
    }

    public void ChangeAssignee(User assignee)
    {
        historyStack.Push(task.CreateBackup());
        task.ChangeAssignee(assignee);
        task.Notify($"Assignee changed in '{task.Title}' task.");
    }

    public void ChangeEstimationTime(float estimationTime)
    {
        historyStack.Push(task.CreateBackup());
        task.ChangeEstimationTime(estimationTime);
        task.Notify($"Estimation time changed in '{task.Title}' task.");
    }
    public void AddLoggedTime(float time)
    {
        historyStack.Push(task.CreateBackup());
        task.AddLoggedTime(time);
        task.Notify($"Logged time changed in '{task.Title}' task.");
    }
    public float GetEstimationTime()
    {
        return task.GetEstimationTime();
    }
    public float GetLoggedTime()
    {
        float oldLoggedTime=task.LoggedTime;
        float newLoggedTime = task.GetLoggedTime();
        if (oldLoggedTime!=newLoggedTime)
        {
            historyStack.Push(task.CreateBackup());
            task.LoggedTime = newLoggedTime;
            task.Notify($"Logged time changed in '{task.Title}' task.");
        }
        return newLoggedTime;
         
    }
    public void Receive(IReceiver receiver)
    {
        historyStack.Push(task.CreateBackup());
        task.Notify($"Added user to message recipients in '{task.Title}' task.");
        task.Receive(receiver);
    }
    public void Undo()
    {
        if (historyStack.Count > 0)
        {
            var memento = historyStack.Pop();
            task.RestoreTask(memento);
            task.Notify("The last action in the task was undone.");
        }
        else Console.WriteLine("There is no history");
    }

    public void ShowHistory()
    {
        foreach (var duplicate in historyStack)
        {
            Console.WriteLine(duplicate.GetDetails()); 
        }
    }

    public void PrintTaskDetails()
    {
        Console.WriteLine($"Creation date:{task.CreationDate},\nTitle:{task.Title},\nDescription:{task.Description},\nAssignee name:{task.Assignee.Name},\nReporter name:{task.Reporter.Name},\nPriority:{task.Priority},\nEstimation time:{this.GetEstimationTime()},\nLogged time:{this.GetLoggedTime()}");
    }
}
