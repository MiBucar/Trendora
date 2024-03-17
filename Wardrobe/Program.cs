using Microsoft.EntityFrameworkCore;
using Wardrobe.Data_Access;
using Wardrobe.Services.Implementations;
using Wardrobe.Services.Interfaces;
using Radzen;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Identity;
using Wardrobe.Models.Models;
using Microsoft.Extensions.Options;
using FluentAssertions.Common;

var builder = WebApplication.CreateBuilder(args);

// Session storage
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<ApplicationDatabaseContext>(options =>
{
    var env = builder.Environment;
    string connectionString = env.IsDevelopment()
                              ? builder.Configuration.GetConnectionString("Default")
                              : Environment.GetEnvironmentVariable(" ConnectionStrings__Default");

    options.UseSqlServer(connectionString)
           .EnableSensitiveDataLogging(env.IsDevelopment());
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDatabaseContext>()
    .AddDefaultTokenProviders().AddDefaultUI();

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISizeService, SizeService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddTransient<ApiService>();
builder.Services.AddRadzenComponents();
builder.Services.AddBlazoredLocalStorage();

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


app.UseSession();
app.UseEndpoints(configure: endpoints =>
{
    _ = endpoints.MapControllers();
    _ = endpoints.MapRazorPages();
});

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
