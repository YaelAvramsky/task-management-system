using DesignPatternsProject.Enum;
using DesignPatternsProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DesignPatternsProject.Models;

public class Task1:ITime
{ 
    public DateTime CreationDate { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public User Assignee { get; set; }
    public User Reporter { get; set; }
    public Priority Priority { get; set; }
    public float EstimationTime { get; set; }
    public float LoggedTime { get; set; }
    public List<TaskManager> SubTasks { get; set; }

    public IStatus status;

    public List<IReceiver> receivers;

    public Task1()
    {
    }
    public void AddSubTask(TaskManager task)
    {
        if (SubTasks == null)
        {
            EstimationTime = 0;
            SubTasks = new List<TaskManager>();
        }
        SubTasks.Add(task);
        EstimationTime += task.GetEstimationTime();
    }
    public void AdvanceStatus(User assignee)
    {
        status.AdvanceStatus(assignee);
    }
    public void SetStatus(IStatus status)
    {
        this.status = status;
    }

    public void ActionOnTask()
    {
        status.ActionOnTask();
    }

    public void ChangePriority(Priority priority)
    {
        Priority = priority;
    }

    public void ChangeAssignee(User assignee)
    {
        receivers.Remove(Assignee);
        receivers.Add(assignee);
        Assignee = assignee;
    }

    public void ChangeEstimationTime(float estimationTime)
    {
        EstimationTime = estimationTime;
    }

    public void AddLoggedTime(float time)
    {
        LoggedTime += time;
    }

    public IDuplicate CreateBackup()
    {
        List<TaskManager> subTasksCopy=null;
        List<IReceiver> receiversCopy =null;
        if (SubTasks != null)
             subTasksCopy = SubTasks.Select(t => t).ToList();
        if(receivers != null)
            receiversCopy = receivers.Select(r=>r).ToList();
        return new Duplicate(Assignee,Priority,EstimationTime,LoggedTime, subTasksCopy,receiversCopy,status);
    }
    public void RestoreTask(IDuplicate memento)
    {
        Assignee=((Duplicate)memento).assignee;
        Priority=((Duplicate)memento).priority;
        EstimationTime=((Duplicate)memento).estimationTime;
        LoggedTime=((Duplicate)memento).loggedTime;
        SubTasks=((Duplicate)memento).subTasks;
        receivers=((Duplicate)memento).receivers;
        status=((Duplicate)memento).status;
    }
    private class Duplicate : IDuplicate
    {
        public User assignee { get; }
        public Priority priority { get; }
        public float estimationTime { get; }
        public float loggedTime { get;}
        public List<TaskManager> subTasks { get; }
        public List<IReceiver> receivers {  get; }
        public IStatus status { get; }
        public Duplicate(User assignee, Priority priority, float estimationTime, float loggedTime, List<TaskManager> subTasks, List<IReceiver> receivers, IStatus status)
        {
            this.assignee = assignee;
            this.priority = priority;
            this.estimationTime = estimationTime;
            this.loggedTime = loggedTime;
            this.subTasks = subTasks;
            this.receivers = receivers;
            this.status = status;
        }

        public string GetDetails()
        {
            string details = $"Assignee name:{assignee.Name} ,Priority:{priority} ,Estimation time:{estimationTime} ,Logged time:{loggedTime} ,Status:{status}";
            if(subTasks!=null)
                details+=$" ,Number of subtasks: { subTasks.Count}";
            if (receivers != null)
                details += $" ,Number of receivers notifications:{receivers.Count}";
            return details;
        }
    }

    public float GetEstimationTime()
    {
        if (SubTasks == null)
            return EstimationTime;
        float sum = 0;
        foreach (var task in SubTasks)
        {
            sum += task.GetEstimationTime();
        }
        return sum;
    }
    public float GetLoggedTime()
    {
        if (SubTasks == null)
            return LoggedTime;
        float sum = 0;
        foreach (var task in SubTasks)
        {
            sum += task.GetLoggedTime();
        }
        return sum;
    }
    public void Receive(IReceiver receiver)
    {
        receivers.Add(receiver);
    }

    public void Notify(string notification)
    {
        if (receivers != null)
        {
            foreach (IReceiver receiver in receivers)
            {
                receiver.ReceiveNotification(notification);
            }
        }
    }
}



