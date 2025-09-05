using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerNET8.Models.Database.Project;

[Table("ProjectNote")]
public partial class ProjectNote
{
    [Key]
    public int Id { get; set; }

    public string NoteContent { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public int ProjectId { get; set; }

    public bool IsPinned { get; set; }

    [ForeignKey("ProjectId")]
    [InverseProperty("ProjectNotes")]
    public virtual Project Project { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("ProjectNotes")]
    public virtual User User { get; set; } = null!;
}
