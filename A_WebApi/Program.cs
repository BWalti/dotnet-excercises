var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<Calculator>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/calc", (Calculator c) => c.State);
app.MapPost("/calc/add/{value:int}", (Calculator c, int value) => c.Add(value))
    .WithName("add")
    .WithOpenApi();
app.MapPost("/calc/subtract/{value:int}", (Calculator c, int value) => c.Subtract(value))
    .WithName("subtract")
    .WithOpenApi();
app.MapPost("/calc/multiply/{value:int}", (Calculator c, int value) => c.Multiply(value))
    .WithName("multiply")
    .WithOpenApi();
app.MapPost("/calc/divide/{value:int}", (Calculator c, int value) => c.Divide(value))
    .WithName("divide")
    .WithOpenApi();

app.Run();

class Calculator
{
    public int State { get; set; }

    public int Add(int value)
    {
        State += value;
        return State;
    }

    public int Subtract(int value)
    {
        State -= value;
        return State;
    }

    public int Multiply(int value)
    {
        State *= value;
        return State;
    }

    public int Divide(int value)
    {
        State /= value;
        return State;
    }
}