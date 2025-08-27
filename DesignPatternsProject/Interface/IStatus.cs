using DesignPatternsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Interface;

public abstract class IStatus
{
    protected TaskManager _taskCareTaker;
    protected IStatus(TaskManager taskCareTaker)
    {
        _taskCareTaker = taskCareTaker;
    }
    abstract public void AdvanceStatus(User assignee);
    abstract public void ActionOnTask();
}
