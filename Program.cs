WebApplicationBuilder builder = WebApplication.CreateBuilder(args); //����������� ����� ������ ������ WebApplicationBuilder
WebApplication app = builder.Build(); //������ ������ WebApplication

app.MapGet("/", () => "Hello World!");

app.UseWelcomePage();

app.Run();
