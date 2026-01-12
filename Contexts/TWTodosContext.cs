using Microsoft.EntityFrameworkCore;
using TWTodos.Models;


namespace TWTodos.Contexts;

public class TWTodosContext : DbContext
{
        public DbSet<ToDo> ToDos =>  Set<ToDo>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=todos.sqlite3");
    }
}