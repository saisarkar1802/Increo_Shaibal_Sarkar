using ToDoList_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList_DAL.Context
{
    public class ToDoDbContext:DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
            
        }
        public DbSet<ToDo> todoS { get; set; }
    }
}
