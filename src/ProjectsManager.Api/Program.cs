using ProjectsManager.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ProjectsRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(
    opt => opt.AddDefaultPolicy(policy => policy
        .WithOrigins("http://localhost:8000").AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

app.MapGet("/api/projects", async (ProjectsRepository repo) => await repo.GetAll());
app.MapGet("/api/projects/{id:guid}", async (ProjectsRepository repo, Guid id) => await repo.GetSingle(id));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.Run();