using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerNET8.Models.Database.Project;

[Table("UserTheTask")]
public partial class UserTheTask
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TheTaskId { get; set; }

    [ForeignKey("TheTaskId")]
    [InverseProperty("UserTheTasks")]
    public virtual TheTask TheTask { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserTheTasks")]
    public virtual User User { get; set; } = null!;
}
