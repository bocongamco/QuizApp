
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
// Regist the QuizService
builder.Services.AddScoped<IQuizService, QuizService>();

// Add Authentication
builder.Services.AddAuthentication().AddCookie("CookieAuth", option =>
{
    option.LoginPath = "/Account/Login";
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.Cookie.HttpOnly = true; // Ensures cookies are not accessible by Javascript, 

    //Ensure cookies are secure, and not be stolen from fraud link 
    option.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
    option.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
    option.ExpireTimeSpan = TimeSpan.FromMinutes(30); 
});
builder.Services.AddRazorPages();
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
