using Microsoft.EntityFrameworkCore;

namespace WebAPI.Features.TaskItems;

public static class TaskItemHelper
{
    public static void ConfigureModelProperties(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>()
            .ToTable("task_items");

        modelBuilder.Entity<TaskItem>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<TaskItem>()
            .Property(x => x.Title)
            .HasMaxLength(80)
            .IsRequired();

        modelBuilder.Entity<TaskItem>()
            .Property(x => x.Description)
            .HasMaxLength(255)
            .IsRequired(false);

        modelBuilder.Entity<TaskItem>()
            .Property(x => x.CreateDate)
            .HasColumnType("DATETIME(3)");

        modelBuilder.Entity<TaskItem>()
            .Property(x => x.DueDate)
            .HasColumnType("DATETIME(3)");

        modelBuilder.Entity<TaskItem>()
            .Property(x => x.DueDate)
            .HasColumnType("DATETIME(3)");

        modelBuilder.Entity<TaskItem>()
            .Property(x => x.CompletionDate)
            .HasColumnType("DATETIME(3)");

        modelBuilder.Entity<TaskItem>()
            .Property(x => x.Status)
            .IsRequired();
    }
}
