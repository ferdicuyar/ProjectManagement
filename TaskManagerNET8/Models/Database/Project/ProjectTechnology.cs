using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerNET8.Models.Database.Project;

[Table("ProjectTechnology")]
public partial class ProjectTechnology
{
    [Key]
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int TechnologyId { get; set; }

    [ForeignKey("ProjectId")]
    [InverseProperty("ProjectTechnologies")]
    public virtual Project Project { get; set; } = null!;

    [ForeignKey("TechnologyId")]
    [InverseProperty("ProjectTechnologies")]
    public virtual Technology Technology { get; set; } = null!;
}
