WebApplicationBuilder builder = WebApplication.CreateBuilder(args); //����������� ����� ������ ������ WebApplicationBuilder
WebApplication app = builder.Build(); //������ ������ WebApplication

app.MapGet("/", () => "Hello World!");

app.Run(async (context) => await context.Response.WriteAsync("Hello from response!"));

//app.UseWelcomePage();

app.Run();
