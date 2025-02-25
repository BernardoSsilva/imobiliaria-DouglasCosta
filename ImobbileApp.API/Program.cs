var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); 
//builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ImmobileAppDbContext>(options => options.UseNpgsql(@"Host=localhost:5432;Username=docker;Password=docker;Database=immobileAppDB"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
