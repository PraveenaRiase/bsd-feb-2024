var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Above this line is 'internal' config stuu 
var app = builder.Build();
// after this line is config for the middleware
//how actual HTTP requests are handled and responses are sent
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// GET /
app.MapGet("/support-info", () =>
{
    return new SupportInfoResponse("Graham", "555-1212");
});

app.Run();
public record SupportInfoResponse(string Name, string Phone);

public partial class Program { }