using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Tareas
{
    public class Task
    {
        /// <summary>
        /// Id of the task.
        /// </summary>
        public int Id { get; set; } 

        /// <summary>
        /// Description of the task.
        /// </summary>
        [Required]
        public string Description { get; set; } = string.Empty; // Initialize to an empty string

        /// <summary>
        /// Status of the task.
        /// </summary>
        public TaskStatus Status { get; set; } = TaskStatus.Pending;

        /// <summary>
        /// Creation date and time of the task.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        //If you are still getting a warning even after doing the step above you might need to add a parameterless constructor like the one below.
        public Task() { }

        /// <summary>
        /// Constructor to initialize the description of the task.
        /// </summary>

        // Example of another constructor to initialize the description
        public Task(string description)
        {
            Description = description;
        }
    }

    /// <summary>
    /// Represents the status of a task.
    /// </summary>
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed
    }

    public class TasksController : Controller  // Inherit from Controller
    {
        private static List<Task> _tasks = new List<Task>();
        private static int _nextId = 1;

        /// <summary>
        /// Displays the list of tasks.
        /// </summary>
        /// <returns>
        /// IActionResult: The view with the list of tasks.
        /// </returns>
        /// <response code="200">Returns the list of tasks.</response>
        /// <response code="404">If no tasks are found.</response>
        
        public IActionResult Index() // Return IActionResult
        {
            return View(_tasks); 
        }

        public IActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="task">The task to create.</param>
        /// <returns>
        /// IActionResult: The view with the created task or an error message.
        /// </returns>
        /// <response code="200">Returns the created task.</response>
        /// <response code="400">If the model is invalid.</response>
       [HttpPost]
        public IActionResult Create(Task task)
        {
            try
            {
                if (ModelState.IsValid) // Verifica si el modelo es válido
                {
                    task.Id = _nextId++;
                    _tasks.Add(task);
                    return RedirectToAction("Index"); 
                }
                else
                {
                    // Maneja errores de validación del modelo (opcional)
                    return View(task); // Vuelve a mostrar el formulario con los errores
                }

            }
            catch (Exception ex)
            {
                // Registra la excepción (usando un logger, por ejemplo)
                Console.WriteLine($"Error al crear tarea: {ex.Message}"); // Ejemplo simple

                // Muestra un mensaje de error al usuario (opcional)
                ModelState.AddModelError(string.Empty, "Hubo un error al crear la tarea. Por favor, inténtalo de nuevo.");
                return View(task); // O redirige a una página de error
            }
        }

        /// <summary>
        /// Edits an existing task.
        /// </summary>
        /// <param name="task">The task to edit.</param>
        /// <returns>
        /// IActionResult: The view with the edited task.
        /// </returns>
        /// <response code="200">Returns the edited task.</response>
        /// <response code="404">If the task is not found.</response>
        [HttpPost]
        public IActionResult Edit(Task task)
        {
            
            var existingTask = _tasks.Find(t => t.Id == task.Id);

            if(existingTask != null){
                existingTask.Description = task.Description;
                existingTask.Status = task.Status;
            }

            return RedirectToAction("Index"); //Fix redirection
        }

        /// <summary>
        /// Deletes a task.
        /// </summary>
        /// <param name="id">The ID of the task to delete.</param>
        /// <returns>
        /// IActionResult: The view with the list of tasks.
        /// </returns>
        /// <response code="200">Returns the updated list of tasks.</response>
        /// <response code="404">If the task is not found.</response>
        [HttpPost]
        public IActionResult Delete(int id)
        {
             _tasks.RemoveAll(x=> x.Id == id);
            return RedirectToAction("Index"); //Fix redirection
        }

        /// <summary>
        /// Displays the edit view for a task.
        /// </summary>
        /// <param name="id">The ID of the task to edit.</param>
        /// <returns>
        /// IActionResult: The edit view for the task.
        /// </returns>
        /// <response code="200">Returns the edit view.</response>
        /// <response code="404">If the task is not found.</response>
        public IActionResult Edit(int id)
        {
            return View(_tasks.Find(t => t.Id == id));
        }

        /// <summary>
        /// Displays the delete view for a task.
        /// </summary>
        /// <param name="task">The task to delete.</param>
        /// <returns>
        /// IActionResult: The delete view for the task.
        /// </returns>
        public IActionResult Delete(Task task)
        {
            return View(task);
        }
    }
}
