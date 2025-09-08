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

    [ForeignKey("OwnerId")]
    [InverseProperty("Projects")]
    public virtual User Owner { get; set; } = null!;

    [InverseProperty("Project")]
    public virtual ICollection<ProjectCost> ProjectCosts { get; set; } = new List<ProjectCost>();

    [InverseProperty("Project")]
    public virtual ICollection<ProjectNote> ProjectNotes { get; set; } = new List<ProjectNote>();

    [InverseProperty("Project")]
    public virtual ICollection<ProjectTechnology> ProjectTechnologies { get; set; } = new List<ProjectTechnology>();

    [InverseProperty("Project")]
    public virtual ICollection<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();

    [InverseProperty("Project")]
    public virtual ICollection<TheTask> TheTasks { get; set; } = new List<TheTask>();
}
