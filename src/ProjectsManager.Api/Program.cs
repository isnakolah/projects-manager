using ProjectsManager.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ProjectsRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(
    opt => opt.AddDefaultPolicy(policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwagger().UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors();

app.MapGet("/api/projects", async (ProjectsRepository repo) => await repo.GetAllAsync());
app.MapGet("/api/projects/{id:guid}", async (ProjectsRepository repo, Guid id) => await repo.GetSingleAsync(id));

app.Run();