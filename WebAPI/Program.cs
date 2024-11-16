using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
MySqlServerVersion serverVersion = new(new Version(8, 0, 29));

builder.Services.AddDbContext<DailyPlannerContext>(options =>
{
    options.UseMySql(connectionString, serverVersion);
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    DailyPlannerContext databaseContext = scope.ServiceProvider.GetRequiredService<DailyPlannerContext>();

    if (!databaseContext.Database.CanConnect())
    {
        throw new NotImplementedException("Can't connect to database");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseCors();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
