WebApplicationBuilder builder = WebApplication.CreateBuilder(args); //статический метод создаёт объект WebApplicationBuilder
WebApplication app = builder.Build(); //создаём объект WebApplication

app.MapGet("/", () => "Hello World!");

app.UseWelcomePage();

app.Run();
