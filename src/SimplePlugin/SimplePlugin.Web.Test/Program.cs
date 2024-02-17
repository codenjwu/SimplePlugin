using SimplePlugin.Common.Test;
using SimplePlugin;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var mvcbuilder = builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICommonService, CommonService>();
mvcbuilder.ConfigSimplePlugin(@"your plugin folder path");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
// add single assembly
//SimplePluginMiddelwareBuilder.Use(app, SimplePluginOptions.PluginAssemblies.First().Value);
//add multiple assembly
SimplePluginMiddelwareBuilder.Use(app, SimplePluginOptions.PluginAssemblies.Select(x => x.Value));
app.MapControllers();

app.Run();
