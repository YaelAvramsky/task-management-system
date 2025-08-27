using DesignPatternsProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Models;

public class InProgressStatus:IStatus
{
    public InProgressStatus(TaskManager taskCareTaker) :base(taskCareTaker)
    {
    }
    override public void AdvanceStatus(User assignee)
    {
        _taskCareTaker.SetStatus(new CodeReviewStatus(_taskCareTaker));
    }
    override public void ActionOnTask()
    {
        Console.WriteLine("the task is in 'In Progress' status");
    }
}
