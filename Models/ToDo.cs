using System.ComponentModel.DataAnnotations;
using TWTodos.Validators;

namespace TWTodos.Models;

public class ToDo
{
    public int Id { get; set; }
    [Display(Name = "Titulo")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo deve ter entre 3 e 100 caracteres")]
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    [Display(Name = "Data de Entrega")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    [FutureOrPresent]
    public DateOnly Deadline { get; set; }
    public DateOnly? FinishedAt { get; set; }

    public void Finish()
    {
        FinishedAt = DateOnly.FromDateTime(DateTime.Now);
    }
}