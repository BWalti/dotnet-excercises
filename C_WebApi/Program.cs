using C_WebApi.Blogging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkSqlite()
    .AddDbContext<BloggingContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/blogs", (BloggingContext ctx) => ctx.Blogs);
app.MapPost("/blogs", async (BloggingContext ctx, Blog b) =>
{
    ctx.Blogs.Add(b);
    await ctx.SaveChangesAsync();
});

app.Run();
