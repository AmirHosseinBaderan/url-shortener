using Microsoft.AspNetCore.Mvc;
using Shortner.Grain;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseOrleans(static oriBuilder =>
{
    oriBuilder.UseLocalhostClustering();
    oriBuilder.AddMemoryGrainStorage(UrlSchema.StorageName);
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// Map Endpoints

app.MapGet("/shorten",
    static async (string url, IGrainFactory grains, IConfiguration configuration) =>
    {
        if (string.IsNullOrWhiteSpace(url) || Uri.IsWellFormedUriString(url, UriKind.Absolute) is false)
            return Results.BadRequest("Input url is not valid");

        string shortCode = GenerateCode(url);

        IUrlShortenerGrain shortenerGrain = grains.GetGrain<IUrlShortenerGrain>(shortCode);
        await shortenerGrain.SetLongUrlAsync(url);

        UriBuilder resultBuilder = new(configuration["BaseUrl"]!) { Path = $"/{shortCode}" };
        return Results.Ok(resultBuilder.Uri);
    });

app.MapGet("/{short_code:required}",
    static async (IGrainFactory grains, [FromRoute(Name = "short_code")] string shortCode) =>
    {
        IUrlShortenerGrain shortenerGrain = grains.GetGrain<IUrlShortenerGrain>(shortCode);

        string url = await shortenerGrain.GetLongUrlAsync();
        UriBuilder redirectBuilder = new(url);
        return Results.Redirect(redirectBuilder.Uri.ToString());
    });


await app.RunAsync();

static string GenerateCode(string longUrl)
{
    var hashBytes = MD5.HashData(Encoding.UTF8.GetBytes(longUrl));
    var hashCode = BitConverter.ToString(hashBytes)
                               .Replace(oldValue: "-", newValue: "")
                               .ToLower();

    return hashCode[10..];
}