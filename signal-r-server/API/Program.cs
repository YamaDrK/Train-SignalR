using API;

var builder = WebApplication.CreateBuilder(args);

var apiPolicy = "SignalR-policy";

builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddWebAPIService();
builder.Services.AddCors(options =>
{
    options.AddPolicy(apiPolicy, policy =>
    {
        policy.SetIsOriginAllowed(origin => new Uri(origin).Host is "localhost")
       .AllowAnyMethod()
       .AllowAnyHeader()
       .AllowCredentials();
    });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(apiPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseApplicationHubs();

app.Run();
