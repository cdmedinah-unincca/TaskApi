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
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

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

    [HttpGet("buscar")]
    public ActionResult<List<TaskModel>> SearchTasks([FromQuery] string q)
    {
        if (string.IsNullOrWhiteSpace(q))
            return BadRequest("El parámetro 'q' es requerido.");

        var results = _tasks
            .Where(t => t.Title.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                        t.Description.Contains(q, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return Ok(results);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, TaskModel updatedTask)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
            return NotFound();

        task.Title = updatedTask.Title;
        task.Description = updatedTask.Description;
        // No se modifica IsCompleted en PUT
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

    [HttpPatch("{id}/pendiente")]
    public IActionResult MarkAsPending(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
            return NotFound();

        task.IsCompleted = false;
        return Ok(task);
    }
}