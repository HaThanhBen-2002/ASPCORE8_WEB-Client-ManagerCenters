using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TrainingCenters.ConnectApi;
using TrainingCenters.InterfacesApi;
using TrainingCenters.RepositoryApi;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<ConnectApi>(builder.Configuration.GetSection("ConnectionStrings"));


builder.Services.AddHttpClient("ConnectApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetSection("ConnectionStrings")["StringConnectAPI"]);
});

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWorkRepon>();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    // Thêm định tuyến controller mặc định cho không có khu vực (global)
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
