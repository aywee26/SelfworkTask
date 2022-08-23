using SelfworkTask.Library.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IDialogSearchService, DialogSearchService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
