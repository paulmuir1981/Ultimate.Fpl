using Fpl.Client.Clients;
using Serilog;
using System.Net;
using Ultimate.Fpl.Ui.Services;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    var outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] ({SourceContext}) {Message:lj}{NewLine}{Exception}";
    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console(outputTemplate: outputTemplate)
        .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day, outputTemplate: outputTemplate));

    builder.Services.AddRazorPages();

    var clientHandler = new HttpClientHandler
    {
        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
    };

    builder.Services.AddHttpClient<IGeneralClient, GeneralClient>()
        .ConfigurePrimaryHttpMessageHandler(() => clientHandler);
    builder.Services.AddHttpClient<IEntryClient, EntryClient>()
        .ConfigurePrimaryHttpMessageHandler(() => clientHandler);

    builder.Services.AddDistributedMemoryCache();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddScoped<ICacheService, CacheService>();
    builder.Services.AddScoped<IDataService, DataService>();
    builder.Services.AddScoped<IEntryService, EntryService>();

    builder.Services.AddHttpContextAccessor();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapRazorPages();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}