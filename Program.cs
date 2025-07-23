using SimpleTODOLesson.Data;
using SimpleTODOLesson.Services;
using SimpleTODOLesson.Services.Interfaces;
// Основная программа, что запускает api

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IPostsService, PostsService>();
builder.Services.AddSingleton<MyDataContext>();


// Config DB from appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("local");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
