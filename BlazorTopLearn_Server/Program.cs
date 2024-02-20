using Blazor.Business.Mapper;
using Blazor.Business.Repository;
using Blazor.Business.Repository.IRepository;
using BlazorTopLearn_Server.Service;
using BlazorTopLearn_Server.Service.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Blazor.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
endpoints.MapRazorPages());

app.Run();
