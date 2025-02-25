using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kastoras.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public List<Task> Tasks { get; set; }
    public List<Milestone> Milestones { get; set; }
}

public class Milestone
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime TargetDate { get; set; }
    public bool IsCompleted { get; set; }
}