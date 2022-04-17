using Microsoft.EntityFrameworkCore;
using YourRecipes.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("YourRecipesContextConnection");;

builder.Services.AddDbContextPool<YourRecipesDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("YourRecipes"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<YourRecipesDbContext>();;

// Add services to the container.
builder.Services.AddRazorPages();



builder.Services.AddScoped<IRecipeData, SqlRecipeData>();

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

app.UseAuthentication();

app.MapRazorPages();

app.Run();
