using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerNET8.Models.Database.Project;

[Table("User")]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [StringLength(50)]
    public string Password { get; set; } = null!;

    public string LongName { get; set; } = null!;
    public bool Deleted { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<ProjectNote> ProjectNotes { get; set; } = new List<ProjectNote>();

    [InverseProperty("Owner")]
    public virtual ICollection<TaskNote> TaskNotes { get; set; } = new List<TaskNote>();

    [InverseProperty("TaskUser")]
    public virtual ICollection<TheTask> Tasks { get; set; } = new List<TheTask>();
}
