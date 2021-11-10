using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.service
{
    class TaskService
    {
        public bool AddTask(Task newTask)
        {
            using (var _TaskContext = new ToDoListEntities())
            {
                _TaskContext.Tasks.Add(newTask);
                _TaskContext.SaveChanges();
            }     
            return true;
        }
        public bool CompleteTask(int taskId)
        {
            using(var _TaskContext = new ToDoListEntities())
            {
                var query = from task in _TaskContext.Tasks
                            where task.Id == taskId
                            select task;
                Task selectedTask = query.First();
                selectedTask.Status = true;
                selectedTask.DateCompleted = DateTime.Now;
                _TaskContext.Tasks.AddOrUpdate(selectedTask);
                _TaskContext.SaveChanges();
            }
            return true;
        }
        public bool DeleteTask(int taskId)
        {
            using (var _TaskContext = new ToDoListEntities())
            {
                var query = from task in _TaskContext.Tasks
                            where task.Id == taskId
                            select task;
                Task selectedTask = query.First();
                _TaskContext.Tasks.Remove(selectedTask);
                _TaskContext.SaveChanges();
            }
            return true;
        }

    }
}
