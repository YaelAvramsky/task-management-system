# Task Management System – Design Patterns Project 🚀

**Task Management System** is a professional C# application that demonstrates the **practical implementation of Creational, Structural, and Behavioral design patterns**.  
It emphasizes **clean architecture, modular design, and advanced OOP principles**, making it a showcase of professional-grade software engineering.

---

## 📖 Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Design Patterns](#design-patterns)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Demo Workflow](#demo-workflow)
- [Future Enhancements](#future-enhancements)
- [Author](#author)

---

## 📝 Overview
The Task Management System allows users to **create, assign, update, and track tasks** efficiently. Key capabilities include:

- Stepwise task creation via the **Builder Pattern**
- Role-based task workflows (**Developer, Manager, QA**)
- Support for **subtasks** with aggregated estimated and logged time
- Notifications for all task changes via **Observer pattern**
- Full **task history tracking** with undo functionality via **Memento pattern**

This project demonstrates **maintainable, extensible, and professional software design**.

---

## ⚡ Features

### User Management
- User properties: `Name`, `Email`, `Role`
- Roles supported: **Developer**, **Manager**, **QA**
- Role-specific actions:
  - Only **Managers** can approve code
  - Only **QA** can mark tasks as **Done**

### Task Management
- Task attributes:
  - `Title`, `Description`, `Assignee`, `Reporter`
  - `Status` (To Do → In Progress → Code Review → QA → Done)
  - `Priority` (Low, Medium, High)
  - `EstimationTime` and `LoggedTime`
- Supports **subtasks** with aggregated times
- Console-based notifications for **status, priority, and assignment changes**

### Task History
- Tracks **all modifications** to tasks
- Supports **undo of the last action**
- Provides **complete task history review**

---

## 🏗️ Design Patterns Used

| Category      | Pattern                     | Usage in Project |
|---------------|-----------------------------|----------------|
| Creational    | **Builder**                 | Construct complex tasks step-by-step with subtasks |
| Structural    | **Composite**               | Handle tasks with nested subtasks |
| Behavioral    | **Observer / Notification** | Notify users of task updates in real-time |
| Behavioral    | **State**                   | Manage task status transitions (workflow) |
| Behavioral    | **Memento**                 | Store task history and allow undo functionality |

---

## 🛠 Architecture

**Key Components:**

- **Models**: `Task1`, `User`, `TaskManager`, `TaskBuilder`
- **Interfaces**: `IStatus`, `IDuplicate`, `IReceiver`, `INotification`, `ITime`
- **Enums**: `Priority`, `Roles`
- **Status Classes**: `ToDoStatus`, `InProgressStatus`, `CodeReviewStatus`, `QAStatus`, `DoneStatus`
- **Notifications**: `ConsoleNotification` (extensible)

**Design Principles:**

- Each class in a **separate file**
- Clear naming and separation of concerns
- Fully **object-oriented**: encapsulation, abstraction, modularity
- Extensible for **new workflows, roles, or notification channels**

---

## 🚀 Getting Started

### Prerequisites
- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- IDE: **Visual Studio 2022** or **JetBrains Rider**
- Basic knowledge of **C# and OOP concepts**

### Installation & Running
```bash
git clone https://github.com/YaelAvramsky/task-management-system.git
cd DesignPatternsProject
dotnet build
dotnet run
````

---

## 🎯 Usage

* Create tasks using the **Builder pattern**
* Add **subtasks** with estimated and logged times
* Advance tasks through **role-based workflow**
* Observe **console notifications**
* Undo actions and review **task history**

---

## 🔄 Demo Workflow

1. Create users with roles (**Developer, Manager, QA**)
2. Build tasks: `Title`, `Description`, `Assignee`, `Reporter`, `Priority`, `EstimationTime`
3. Add subtasks for complex tasks
4. Advance tasks through the **status workflow**:

   * Developers → **Code Review**
   * Managers → **Approve Code**
   * QA → **Done**
5. Track logged time for tasks and subtasks
6. Receive notifications for task changes
7. View history and undo actions if needed

---

## 🌟 Future Enhancements

* Persist tasks in a **database**
* Add a **GUI or Web interface**
* Implement **email or mobile notifications**
* Role-based access control for advanced security
* Sorting, filtering, and searching for **large task lists**

---

## 👩‍💻 Author

**Yael Avramsky**

* Email: [y0583296331@gmail.com](mailto:y0583296331@gmail.com)
* GitHub: [github.com/YaelAvramsky](https://github.com/YaelAvramsky)

---

> **Task Management System** demonstrates the **real-world application of design patterns**, clean architecture, and modular C# development.
> A showcase of professional software engineering best practices.

---

## 📜 License

This project is licensed under the MIT License.  
Feel free to fork and customize for your needs.