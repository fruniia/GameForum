using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<ForumDbContext>(options => options.UseSqlServer(connectionString));

//TODO: Ta bort kommentarer i addTransient eftersom
builder.Services.AddTransient<MainCategoryManager>();
//builder.Services.AddTransient<SubCategoryManager>();
//builder.Services.AddTransient<UserThreadManager>();
//builder.Services.AddTransient<CommentManager>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
