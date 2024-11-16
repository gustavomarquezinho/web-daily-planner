using Microsoft.EntityFrameworkCore;
using WebAPI.Features.TaskItems;

namespace WebAPI.Data;

public class DailyPlannerContext(DbContextOptions<DailyPlannerContext> options) : DbContext(options)
{
    public DbSet<TaskItem> TaskItems { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        TaskItemHelper.ConfigureModelProperties(modelBuilder);
    }
}
