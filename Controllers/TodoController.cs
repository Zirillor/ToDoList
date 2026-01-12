using Microsoft.AspNetCore.Mvc;
using TWTodos.Contexts;
using TWTodos.Models;

namespace TWTodos.Controllers;

public class TodoController : Controller
{
    private readonly TWTodosContext _context;

    public TodoController(TWTodosContext context)
    {
        _context = context;
    }


    [HttpGet]
    public IActionResult Index()
    {
        ViewData["Title"] = "Lista de Tarefas";
        var todos = _context.ToDos.ToList();
        
        return View(todos);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewData["Title"] = "Nova Tarefa";
        return View("form");
    }

    [HttpPost]
    public IActionResult Create(ToDo todo)
    {
         //CONSERTAR POIS NAO ESTA APARECENDO O TITULO
        if (ModelState.IsValid)
        {
            todo.CreatedAt = DateTime.Now;
            _context.ToDos.Add(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
        ViewData["Title"] = "Nova Tarefa";
        return View("Form", todo);
        
        

        
    }

    [HttpGet]
    public IActionResult Edit(int Id)
    {
        var todo = _context.ToDos.Find(Id);
        if (todo is null)
        {
            return NotFound();
        }
        ViewData["Title"] = "Editar Tarefa";
        return View("Form", todo);
       
    }

    [HttpPost]
    public IActionResult Edit(ToDo todo)
    {
        if (ModelState.IsValid)
        {
            todo.CreatedAt = DateTime.Now;
            _context.ToDos.Update(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Editar Tarefa";
        return View("Form", todo);
        
    }

    [HttpGet]
    public IActionResult Delete(int Id)
    {
        var todo = _context.ToDos.Find(Id);
        if (todo is null)
        {
            return NotFound();
        }
        ViewData["Title"] = "Excluir Tarefa";
        return View(todo);
    }

    [HttpPost]
    public IActionResult Delete(ToDo todo)
    {
        _context.ToDos.Remove(todo);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Finish(int id)
    {
        var todo = _context.ToDos.Find(id);
        if (todo is null)
        {
            return NotFound();
        }
        todo.Finish();
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
