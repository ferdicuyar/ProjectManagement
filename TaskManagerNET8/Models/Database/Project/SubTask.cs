using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerNET8.Models.Database.Project;

[Table("SubTask")]
public partial class SubTask
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public bool Executed { get; set; }

    public int TaskId { get; set; }

    [ForeignKey("TaskId")]
    [InverseProperty("SubTasks")]
    public virtual Task Task { get; set; } = null!;
}
