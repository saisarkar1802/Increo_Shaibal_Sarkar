using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList_DAL.Models
{
    [Table("ToDoData")]
    public class ToDo
    {
        public long Id { get; set; }
        public int Priority { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; }
    }
}
