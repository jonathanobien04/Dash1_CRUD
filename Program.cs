using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_REPO.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MVC_REPO.Data.ApplicationDbContext>();
    if (!context.Customers.Any())
    {
        context.Customers.AddRange(
            new MVC_REPO.Models.Customer { CustomerName = "Acme Corp", ContactName = "Ana Cruz", Email = "ana@acme.com", Phone = "0917-111-1001", Address = "12 Rizal St", City = "Manila", State = "NCR", ZipCode = "1000" },
            new MVC_REPO.Models.Customer { CustomerName = "BlueTech", ContactName = "Ben Lim", Email = "ben@bluetech.com", Phone = "0917-111-1002", Address = "34 Mabini Ave", City = "Cebu", State = "Cebu", ZipCode = "6000" },
            new MVC_REPO.Models.Customer { CustomerName = "GreenMart", ContactName = "Cara Reyes", Email = "cara@green.com", Phone = "0917-111-1003", Address = "56 Bonifacio", City = "Davao", State = "Davao", ZipCode = "8000" },
            new MVC_REPO.Models.Customer { CustomerName = "SunFoods", ContactName = "Dan Tan", Email = "dan@sunfoods.com", Phone = "0917-111-1004", Address = "78 Luna St", City = "Manila", State = "NCR", ZipCode = "1001" },
            new MVC_REPO.Models.Customer { CustomerName = "PrimeParts", ContactName = "Ella Santos", Email = "ella@prime.com", Phone = "0917-111-1005", Address = "9 Osmena Blvd", City = "Cebu", State = "Cebu", ZipCode = "6001" },
            new MVC_REPO.Models.Customer { CustomerName = "CityCare", ContactName = "Faye Ong", Email = "faye@citycare.com", Phone = "0917-111-1006", Address = "21 Quezon Ave", City = "Davao", State = "Davao", ZipCode = "8001" },
            new MVC_REPO.Models.Customer { CustomerName = "NovaSupply", ContactName = "Gio Ramos", Email = "gio@nova.com", Phone = "0917-111-1007", Address = "3 Roxas St", City = "Manila", State = "NCR", ZipCode = "1002" },
            new MVC_REPO.Models.Customer { CustomerName = "StarLink", ContactName = "Hana Cruz", Email = "hana@starlink.com", Phone = "0917-111-1008", Address = "45 Aguinaldo", City = "Cebu", State = "Cebu", ZipCode = "6002" }
        );
        context.SaveChanges();
    }
}

app.Run();
