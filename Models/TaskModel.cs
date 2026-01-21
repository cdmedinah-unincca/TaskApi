using System.ComponentModel.DataAnnotations;

namespace TaskApi.Models;

public class TaskModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El título es obligatorio.")]
    [MinLength(1, ErrorMessage = "El título no puede estar vacío.")]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }
}