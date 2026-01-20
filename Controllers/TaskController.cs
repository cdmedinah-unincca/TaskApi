using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;

namespace TaskApi.Controllers;

[ApiController]
[Route("api/tareas")]
public class TasksController : ControllerBase
{
    private static readonly List<TaskModel> _tasks = new();
    private static int _nextId = 1;

    [HttpPost]
    public ActionResult<TaskModel> CreateTask(TaskModel task)
    {
        if (string.IsNullOrWhiteSpace(task.Title))
            return BadRequest("El título es requerido.");

        task.Id = _nextId++;
        task.IsCompleted = false;
        _tasks.Add(task);
        return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
    }

    [HttpGet]
    public ActionResult<List<TaskModel>> GetAll()
    {
        return Ok(_tasks);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, TaskModel updatedTask)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
            return NotFound();

        task.Title = updatedTask.Title;
        task.Description = updatedTask.Description;
        return Ok(task);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
            return NotFound();

        _tasks.Remove(task);
        return NoContent();
    }

    [HttpPatch("{id}/completar")]
    public IActionResult MarkAsCompleted(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
            return NotFound();

        task.IsCompleted = true;
        return Ok(task);
    }
}