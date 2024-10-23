using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data;

public class DailyPlannerContext(DbContextOptions<DailyPlannerContext> options) : DbContext(options);
