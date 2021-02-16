using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_DAL.Context;
using ToDoList_DAL.Models;

namespace ToDoList_DAL.DALServices
{
    public class ToDoServices:IToDoServices
    {
        private readonly ToDoDbContext _toDoDbContext;
        public ToDoServices(ToDoDbContext toDoDbContext)
        {
            this._toDoDbContext = toDoDbContext;
        }

        /// <summary>
        /// Fetches All todo's from database
        /// </summary>
        /// <returns></returns>
        public IQueryable<ToDo> GetAllToDos()
        {
            return _toDoDbContext.Set<ToDo>();
        }

        /// <summary>
        /// DB method to Soft delete(Mark complete) a task
        /// </summary>
        /// <param name="toDoID"></param>
        /// <returns></returns>
        public long Update(long toDoID)
        {
            ToDo todo = _toDoDbContext.todoS.Find(toDoID);
            if(todo!=null)
            {
                todo.isDeleted = true;
                _toDoDbContext.Entry(todo).State = EntityState.Modified;
                if(_toDoDbContext.SaveChanges() == 1)
                {
                    return todo.Id;
                }
            }
            return 0;
        }

        /// <summary>
        /// DB Method to increase the priority of a task
        /// </summary>
        /// <param name="toDoID"></param>
        /// <returns></returns>
        public long UpdatePriorityUpwards(long toDoID)
        {
            ToDo todo = _toDoDbContext.todoS.Find(toDoID);
            ToDo otherToDo = _toDoDbContext.todoS.Where(a=>a.Priority== todo.Priority- 1).FirstOrDefault();
            if (todo != null && otherToDo !=null)
            {
                todo.Priority -= 1;
                otherToDo.Priority += 1;
                _toDoDbContext.Entry(todo).State = EntityState.Modified;
                _toDoDbContext.Entry(otherToDo).State = EntityState.Modified;
                if (_toDoDbContext.SaveChanges() == 1)
                {
                    return todo.Id;
                }
            }
            return 0;
        }
        /// <summary>
        /// DB method to decrease the priority of a task
        /// </summary>
        /// <param name="toDoID"></param>
        /// <returns></returns>
        public long UpdatePriorityDownwards(long toDoID)
        {
            ToDo todo = _toDoDbContext.todoS.Find(toDoID);
            ToDo otherToDo = _toDoDbContext.todoS.Where(a => a.Priority == todo.Priority + 1).FirstOrDefault();
            if (todo != null && otherToDo != null)
            {
                todo.Priority += 1;
                otherToDo.Priority -= 1;
                _toDoDbContext.Entry(todo).State = EntityState.Modified;
                _toDoDbContext.Entry(otherToDo).State = EntityState.Modified;
                if (_toDoDbContext.SaveChanges() == 1)
                {
                    return todo.Id;
                }
            }
            return 0;
        }

        /// <summary>
        /// DB method to Insert a task
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public long Insert(string name)
        {
            try
            {
                ToDo newTodo = new ToDo();
                newTodo.Name = name;
                var existingTodo = _toDoDbContext.todoS
                        .OrderByDescending(a => a.Priority).ToList();
                if(existingTodo.Count()>0)
                {
                    newTodo.Priority = existingTodo.FirstOrDefault().Priority + 1;
                }
                else
                {
                    newTodo.Priority =  1;
                }
                newTodo.isDeleted = false;
                _toDoDbContext.todoS.Add(newTodo);
                if (_toDoDbContext.SaveChanges() == 1)
                {
                    return newTodo.Id;
                }
                return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
