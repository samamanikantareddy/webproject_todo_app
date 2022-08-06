using Microsoft.AspNetCore.Mvc;
using todoproject.Models;

namespace todoproject.Controllers
{
    public class TodoController : Controller
    {
        private static List<TodoModel> todos = new List<TodoModel>();
        public IActionResult Index()
        {
            return View(todos);
        }
        public IActionResult CreateTodo(TodoModel item)
        {
            item.Finishdate = DateTime.MaxValue;
            todos.Add(item);
            return RedirectToAction(nameof(Index));

        }
        

        public IActionResult Edit(int id)
        {
            return View(todos.Where(x => x.Id == id).FirstOrDefault());
        }

        public IActionResult EditTodo(TodoModel editedTodo)
        {
            todos = todos.Where(item => item.Id == editedTodo.Id).Select(item => { item = editedTodo; return item; }).ToList();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Complete(int id)
        {
            return View(todos.Where(x => x.Id == id).FirstOrDefault());
        }

        public IActionResult CompleteTodo(int id)
        {
            
            todos = todos.Where(item => item.Id == id).Select(item => { item.Finishdate = DateTime.Now; return item; }).ToList();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            var todo = new TodoModel();
            return View(todo);
        }

    }
}