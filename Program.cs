using ASPMVC.Services;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Cấu hình thư mục chứa View .CSHTML 
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    // /View/Controller/Action.cshtml
   // /MyView/Controller/Action.cshtml
    // {0} -> ten Action
    // {1} -> ten Controller
    // {2} -> ten Area

    options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension); 
});

builder.Services.AddSingleton<ProductService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // truy cập các file tĩnh lưu ở wwwroot

app.UseRouting();

app.UseAuthentication(); // xác định danh tính 
app.UseAuthorization(); //  xác thực quyền truy cập 

app.UseEndpoints(endpoints =>{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // tạo ra các Endpoint đến các controller
    endpoints.MapRazorPages();
});
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}"); // tạo ra các Endpoint đến các controller
// app.MapRazorPages();


app.Run();
