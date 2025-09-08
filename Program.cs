using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Text;
//#nullable disable

WebApplicationBuilder builder = WebApplication.CreateBuilder(args); //статический метод создаёт объект WebApplicationBuilder
WebApplication app = builder.Build(); //создаём объект WebApplication
//app.MapGet("/", () => "Hello World!");

//app.Run(async (context) => await context.Response.WriteAsync("Hello from response!"));
//app.Run(foo); //запускаем метод foo
//app.Run(saveAttachment);

app.Run(sendForm);



app.Run();

async Task sendForm(HttpContext context)
{
    var response = context.Response;

    if(context.Request.Path == "/postuser")
    {
        var form = context.Request.Form;
        string name = form["name"];
        string age = form["age"];
        await response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p></div>");
    }
    else await response.SendFileAsync("html / index.html");
}

async Task saveAttachment(HttpContext context)
{
    var path = context.Request.Path;
    var fullPath = $"html/{path}";
    var response = context.Response;

    response.OnStarting(() =>
    {
        response.Headers.ContentLanguage = "ru-Ru";
        response.ContentType = "text/html; charset=utf-8";
        return Task.CompletedTask;
    });

    if (File.Exists(fullPath))
    {
        await context.Response.SendFileAsync(fullPath);
    }
    else
    {
        //response.StatusCode = 404;
        //await context.Response.WriteAsync("<h2>Not Found</h2>");

        var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
        var fileInfo = fileProvider.GetFileInfo("5_этажка.JPG");

        response.Headers.ContentDisposition = "attachment; filename=my_forest.jpg";
        await response.SendFileAsync(fileInfo);
    }
}
async Task foo(HttpContext context)
{
    var response = context.Response;
    response.OnStarting(()=> {
        response.Headers.ContentLanguage = "ru-Ru";
        response.ContentType = "text/html; charset=utf-8";
        return Task.CompletedTask;});

    //StringBuilder sb = new StringBuilder("<table>");
    //foreach(var header in context.Request.Headers)
    //{
    //    sb.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
    //}
    //sb.Append($"<tr><td>Path</td><td>{context.Request.Path}</td></tr>");
    //sb.Append("</table>");
    //await context.Response.WriteAsync(sb.ToString());






}


