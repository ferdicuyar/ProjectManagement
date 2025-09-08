using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerNET8.Models.Database.Project;

[Table("ProjectUser")]
public partial class ProjectUser
{
    [Key]
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int UserId { get; set; }

    [ForeignKey("ProjectId")]
    [InverseProperty("ProjectUsers")]
    public virtual Project Project { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("ProjectUsers")]
    public virtual User User { get; set; } = null!;
}
