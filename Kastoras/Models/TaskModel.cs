using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kastoras.Enums;

namespace Kastoras.Models;

public enum PriorityLevel { High, Medium, Low }

public class TaskModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public PriorityLevel Priority { get; set; }
    public TaskStatus Status { get; set; }
    public List<Subtask> Subtasks { get; set; }
    public int? ProjectId { get; set; }
    public Project Project { get; set; }
}

public class Subtask
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskModel Task { get; set; }
}