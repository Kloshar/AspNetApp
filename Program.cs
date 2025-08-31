using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args); //статический метод создаёт объект WebApplicationBuilder
WebApplication app = builder.Build(); //создаём объект WebApplication
//app.MapGet("/", () => "Hello World!");

//app.Run(async (context) => await context.Response.WriteAsync("Hello from response!"));
int x = 1;

app.Run(foo); //запускаем метод foo
app.Run();

async Task foo(HttpContext context)
{
    var response = context.Response;
    response.OnStarting(()=> {
        response.Headers.ContentLanguage = "ru-Ru";
        response.ContentType = "text/html; charset=utf-8";
        return Task.CompletedTask;
    });

    StringBuilder sb = new StringBuilder("<table>");

    foreach(var header in context.Request.Headers)
    {
        sb.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
    }
    sb.Append("</table>");
    

    await context.Response.WriteAsync(sb.ToString());




}


