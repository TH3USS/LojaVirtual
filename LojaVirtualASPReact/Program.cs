using LojaVirtualASPReact.Data;
using LojaVirtualASPReact.Models;
using Microsoft.EntityFrameworkCore;
using React.AspNet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();
builder.Services.AddReact();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();

    if (!context.Produtos.Any())
    {
        context.Produtos.AddRange(new List<Produto>
        {
            new Produto { Nome = "Produto 1", Preco = 50.00M },
            new Produto { Nome = "Produto 2", Preco = 100.00M },
            new Produto { Nome = "Produto 3", Preco = 150.00M }
        });
        context.SaveChanges();
    }
}



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
    pattern: "{controller=Produto}/{action=Index}/{id?}");

app.Run();
