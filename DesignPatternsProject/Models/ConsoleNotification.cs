using DesignPatternsProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Models;

public class ConsoleNotification : INotification
{
    public void SendNotification(string notification)
    {
        Console.WriteLine(notification);
    }
}
