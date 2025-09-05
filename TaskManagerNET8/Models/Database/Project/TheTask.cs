using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerNET8.Models.Database.Project;

[Table("TheTask")]
public partial class TheTask
{
    [Key]
    public int Id { get; set; }

    public int? ProjectId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Deadline { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FinishDate { get; set; }

    public int TaskUserId { get; set; }

    public int TaskKategoryId { get; set; }

    public string? LastNote { get; set; }

    [ForeignKey("ProjectId")]
    [InverseProperty("Tasks")]
    public virtual Project? Project { get; set; }

    [InverseProperty("Task")]
    public virtual ICollection<SubTask> SubTasks { get; set; } = new List<SubTask>();

    [InverseProperty("Task")]
    public virtual ICollection<TaskNote> TaskNotes { get; set; } = new List<TaskNote>();

    [ForeignKey("TaskUserId")]
    [InverseProperty("Tasks")]
    public virtual User TaskUser { get; set; } = null!;
}
