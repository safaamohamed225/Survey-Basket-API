
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddOutputCache(options =>
{
    options.AddPolicy("Polls", x => x.Cache()
    .Expire(TimeSpan.FromSeconds(120))
    .Tag("AvailableQuestion"));
});

builder.Host.UseSerilog((context, configuration) =>

configuration.ReadFrom.Configuration(context.Configuration)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.UseOutputCache();

app.MapControllers();

app.UseExceptionHandler();

app.Run();
