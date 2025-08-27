using DesignPatternsProject.Enum;
using DesignPatternsProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Models;
public class CodeReviewStatus:IStatus
{
    public CodeReviewStatus(TaskManager taskCareTaker) :base(taskCareTaker)
    {
    }
    override public void AdvanceStatus(User assignee)
    {
        if (assignee.Role == Roles.Manager)
        {
            _taskCareTaker.SetStatus(new QAStatus(_taskCareTaker));
        }
        else Console.WriteLine("Only managers can review and approve code");
    }
    override public void ActionOnTask()
    {
        Console.WriteLine("the task is in 'Code Review' status");
    }
}
