using DesignPatternsProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Models;

public class DoneStatus:IStatus
{
    public DoneStatus(TaskManager taskCareTaker) :base(taskCareTaker)
    {
    }
    override public void AdvanceStatus(User assignee)
    {
        Console.WriteLine("The task has already been completed.");
    }
    override public void ActionOnTask()
    {
        Console.WriteLine("the task is in 'DONE' status");
    }
}
