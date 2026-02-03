using AnagramSolver.BusinessLogic;
using AnagramSolver.Contracts;

var builder = WebApplication.CreateBuilder(args);

var rootAppSettings = Path.GetFullPath(Path.Combine(builder.Environment.ContentRootPath, "..", "appsettings.json"));

builder.Configuration.AddJsonFile(rootAppSettings, optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IWordRepository, TextProcessing>();
builder.Services.AddScoped<IAnagramSolver, AnagramProcessing>();
builder.Services.AddScoped<IUserInputProcessor, UserInputProcessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
