using DesignPatternsProject.Enum;
using DesignPatternsProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Models;

public class QAStatus : IStatus
{
    public QAStatus(TaskManager taskCareTaker) : base(taskCareTaker)
    {
    }
    override public void AdvanceStatus(User assignee)
    {
        if (assignee.Role == Roles.QA)
        {
            _taskCareTaker.SetStatus(new DoneStatus(_taskCareTaker));
        }
        else Console.WriteLine("Only QA can mark a task as done after testing it");
    }
    override public void ActionOnTask()
    {
        Console.WriteLine("the task is in 'QA' status");
    }
}
