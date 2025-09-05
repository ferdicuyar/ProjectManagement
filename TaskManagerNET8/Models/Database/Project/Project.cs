using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerNET8.Models.Database.Project;

[Table("Project")]
public partial class Project
{
    [Key]
    public int Id { get; set; }

    public string ProjectTitle { get; set; } = null!;

    public string ProjectDescription { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreateDate { get; set; }

    public int OwnerId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Deadline { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FinishDate { get; set; }

    public bool Finished { get; set; }

    [InverseProperty("Project")]
    public virtual ICollection<ProjectCost> ProjectCosts { get; set; } = new List<ProjectCost>();

    [InverseProperty("Project")]
    public virtual ICollection<ProjectNote> ProjectNotes { get; set; } = new List<ProjectNote>();

    [InverseProperty("Project")]
    public virtual ICollection<ProjectTechnology> ProjectTechnologies { get; set; } = new List<ProjectTechnology>();

    [InverseProperty("Project")]
    public virtual ICollection<TheTask> Tasks { get; set; } = new List<TheTask>();
}
