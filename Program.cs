using SimpleTODOLesson.Context;
using SimpleTODOLesson.Services;
using SimpleTODOLesson.Services.Interfaces;
// Основная программа, что запускает api

var builder = WebApplication.CreateBuilder(args);


// Отправляем весь код в Builder
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IPostsService, PostsService>();
builder.Services.AddSingleton<MyDataContext>();


// БД из appsettings.json в Builder
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("local");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

//Если не в режиме отладки, HTTPS
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
