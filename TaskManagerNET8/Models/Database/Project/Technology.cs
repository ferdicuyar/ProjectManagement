using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerNET8.Models.Database.Project;

[Table("Technology")]
public partial class Technology
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    [InverseProperty("Technology")]
    public virtual ICollection<ProjectTechnology> ProjectTechnologies { get; set; } = new List<ProjectTechnology>();
}
