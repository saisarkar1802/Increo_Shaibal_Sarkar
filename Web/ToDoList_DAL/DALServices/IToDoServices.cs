using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_DAL.Models;

namespace ToDoList_DAL.DALServices
{
    public interface IToDoServices
    {
        public IQueryable<ToDo> GetAllToDos();
        public long Update(long toDoID);
        public long Insert(string name);

        public long UpdatePriorityDownwards(long toDoID);
        public long UpdatePriorityUpwards(long toDoID);
    }
}
