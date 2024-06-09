using AdminPanel.Services;

var builder = WebApplication.CreateBuilder(args);

// Dodanie usług do kontenera.
builder.Services.AddRazorPages();
builder.Services.AddScoped<SoapClient>();

var app = builder.Build();

// Skonfigurowanie potoku HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
