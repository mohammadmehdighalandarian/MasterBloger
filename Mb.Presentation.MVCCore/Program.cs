using Mb.Application.contracts.ArticaleCategory;
using Mb.Application;
using Mb.Domain.ArticleCategoryAgg.Repository;
using Mb.infrastructure.Repository;
using Mb.Infrastructure.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

Bootstrapper.Config(builder.Services, builder.Configuration.GetConnectionString("MasterBlogger"));
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

app.MapRazorPages();

app.MapDefaultControllerRoute();

app.Run();

