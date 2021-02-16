using Increo_To_do_List.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDoList_DAL.DALServices;
using ToDoList_DAL.Models;

namespace Increo_To_do_List.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IToDoServices _toDoServices; 

        public HomeController(ILogger<HomeController> logger,IToDoServices toDoServices)
        {
            _logger = logger;
            _toDoServices = toDoServices;
        }

        
        /// <summary>
        /// Action method invoked when the page is initially loaded
        /// </summary>
        /// <returns></returns>
        public IActionResult ToDoList()
        {
            return View();
        }
        
        /// <summary>
        /// Json method invoked by Ajax call to get latest list of tasks
        /// </summary>
        /// <returns>Json</returns>
        public JsonResult GetList()
        {
            List<ToDo> newList = _toDoServices.GetAllToDos().ToList();
            return Json(newList.OrderBy(a => a.Priority).ToList());
        }

        /// <summary>
        /// Json method invoked by Ajax call to add a task
        /// </summary>
        /// <param name="input">task text as input</param>
        /// <returns></returns>
        public JsonResult AddToDo(string input)
        {
            long i = _toDoServices.Insert(input);
            return Json(i);
        }
        /// <summary>
        /// Json method invoked by Ajax call to mark a task complete/delete it
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public JsonResult Delete(long input)
        {
            return Json(_toDoServices.Update(input));
        }
        /// <summary>
        /// Json Action to increase priority of a task
        /// </summary>
        /// <param name="input">Unique Id of the Task</param>
        /// <returns></returns>
        public JsonResult UpwardsPriority(long input)
        {
            return Json(_toDoServices.UpdatePriorityUpwards(input));
        }
        /// <summary>
        /// Json Action to decrease priority of a task
        /// </summary>
        /// <param name="input">Unique Id of the Task</param>
        /// <returns></returns>
        public JsonResult DownwardsPriority(long input)
        {
            return Json(_toDoServices.UpdatePriorityDownwards(input));
        }

        /// <summary>
        /// Default Controller action for Error
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
