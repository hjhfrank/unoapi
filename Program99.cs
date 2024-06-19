using System;
using System.Data;
using a31;
using a41;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy  =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
//app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

a311.Map(app);
a411.Map(app);

app.Run();
