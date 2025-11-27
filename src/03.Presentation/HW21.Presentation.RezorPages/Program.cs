using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Contracts.Repository;
using HW21.Domain.Core.Contracts.Service;
using HW21.Domain.Service.ApplicationServices;
using HW21.Domain.Service.Services;
using HW21.Infra.Data.Repos.Ef;
using HW21.Infra.Db.SqlServer.Ef;
using HW21.Presentation.RezorPages.Extensions;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HW21;User ID=sa;Password=Az@r4180;Trust Server Certificate=True "));
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorAppService,AuthorAppService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IPostAppService, PostAppService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICookieService, CookieService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.MapGet("/", (context) =>
{
    context.Response.Redirect("/Home/Index");
    return Task.CompletedTask;
});
app.Run();
