using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerNET8.Models.Database.Project;

[Table("TaskNote")]
public partial class TaskNote
{
    [Key]
    public int Id { get; set; }

    public int TaskId { get; set; }

    public string NoteContent { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime NoteDate { get; set; }

    public int OwnerId { get; set; }

    [ForeignKey("OwnerId")]
    [InverseProperty("TaskNotes")]
    public virtual User Owner { get; set; } = null!;

    [ForeignKey("TaskId")]
    [InverseProperty("TaskNotes")]
    public virtual TheTask Task { get; set; } = null!;
}
