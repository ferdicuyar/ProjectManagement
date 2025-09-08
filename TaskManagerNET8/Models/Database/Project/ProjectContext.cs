using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerNET8.Models.Database.Project;

public partial class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions<ProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectCost> ProjectCosts { get; set; }

    public virtual DbSet<ProjectNote> ProjectNotes { get; set; }

    public virtual DbSet<ProjectTechnology> ProjectTechnologies { get; set; }

    public virtual DbSet<ProjectUser> ProjectUsers { get; set; }

    public virtual DbSet<SubTask> SubTasks { get; set; }

    public virtual DbSet<TaskNote> TaskNotes { get; set; }

    public virtual DbSet<Technology> Technologies { get; set; }

    public virtual DbSet<TheTask> TheTasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserTheTask> UserTheTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasOne(d => d.Owner).WithMany(p => p.Projects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Project_User");
        });

        modelBuilder.Entity<ProjectCost>(entity =>
        {
            entity.HasOne(d => d.Project).WithMany(p => p.ProjectCosts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectCost_Project");
        });

        modelBuilder.Entity<ProjectNote>(entity =>
        {
            entity.HasOne(d => d.Project).WithMany(p => p.ProjectNotes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectNote_Project");

            entity.HasOne(d => d.User).WithMany(p => p.ProjectNotes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectNote_User");
        });

        modelBuilder.Entity<ProjectTechnology>(entity =>
        {
            entity.HasOne(d => d.Project).WithMany(p => p.ProjectTechnologies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectTechnology_Project");

            entity.HasOne(d => d.Technology).WithMany(p => p.ProjectTechnologies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectTechnology_Technology");
        });

        modelBuilder.Entity<ProjectUser>(entity =>
        {
            entity.HasOne(d => d.Project).WithMany(p => p.ProjectUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectUser_Project");

            entity.HasOne(d => d.User).WithMany(p => p.ProjectUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectUser_User");
        });

        modelBuilder.Entity<SubTask>(entity =>
        {
            entity.HasOne(d => d.Task).WithMany(p => p.SubTasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubTask_Task");

            entity.HasOne(d => d.User).WithMany(p => p.SubTasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubTask_User");
        });

        modelBuilder.Entity<TaskNote>(entity =>
        {
            entity.HasOne(d => d.Owner).WithMany(p => p.TaskNotes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskNote_User");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskNotes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskNote_Task");
        });

        modelBuilder.Entity<TheTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Task");

            entity.HasOne(d => d.Project).WithMany(p => p.TheTasks).HasConstraintName("FK_Task_Project");

            entity.HasOne(d => d.TaskUser).WithMany(p => p.TheTasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_User");
        });

        modelBuilder.Entity<UserTheTask>(entity =>
        {
            entity.HasOne(d => d.TheTask).WithMany(p => p.UserTheTasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTheTask_TheTask");

            entity.HasOne(d => d.User).WithMany(p => p.UserTheTasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTheTask_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
