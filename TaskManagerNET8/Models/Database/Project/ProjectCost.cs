using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerNET8.Models.Database.Project;

[Table("ProjectCost")]
public partial class ProjectCost
{
    [Key]
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public string Description { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    public bool IsIncome { get; set; }

    public bool IsExecuted { get; set; }

    public bool IsCancelled { get; set; }

    [ForeignKey("ProjectId")]
    [InverseProperty("ProjectCosts")]
    public virtual Project Project { get; set; } = null!;
}
