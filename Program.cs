WebApplicationBuilder builder = WebApplication.CreateBuilder(args); //статический метод создаёт объект WebApplicationBuilder
WebApplication app = builder.Build(); //создаём объект WebApplication

app.MapGet("/", () => "Hello World!");

//app.Run(async (context) => await context.Response.WriteAsync("Hello from response!"));

app.Run(foo);

app.Run();

 async Task foo(HttpContext context)
{
    await context.Response.WriteAsync("Hello from response!");
}
