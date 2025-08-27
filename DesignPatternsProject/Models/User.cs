using DesignPatternsProject.Enum;
using DesignPatternsProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Models;

public class User:IReceiver
{
    public string Name { get; set; }
    public string Email { get; set; }
    public Roles Role { get; set; }

    public User(string name, string email, Roles role)
    {
        Name = name;
        Email = email;
        Role = role;
    }

    private INotification notification = new ConsoleNotification();

    public void SetNotification(INotification notification)
    {
        this.notification = notification;
    }
    public void ReceiveNotification(string notification)
    {
        this.notification.SendNotification($"The {Role} {Name} recieved the notification: {notification}");
    }
}
