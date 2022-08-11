using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.ApplicationServices.Persons.Commands;
using PhoneBook.Core.ApplicationServices.Persons.Queries;
using PhoneBook.Core.Domain.Persons.Commands;
using PhoneBook.Core.Domain.Persons.Entities;
using PhoneBook.Core.Domain.Persons.Queries;
using PhoneBook.Core.Domain.Persons.Repositories;
using PhoneBook.Core.Domain.Repositories;
using PhoneBook.Core.Resources.Resources;
using PhoneBook.Framework.Commands;
using PhoneBook.Framework.Queries;
using PhoneBook.Framework.Resources;
using PhoneBook.Infrastructures.Data.SqlServer;
using PhoneBook.Infrastructures.Data.SqlServer.Persons.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
              .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
             .AddDataAnnotationsLocalization(options =>
             {
                 options.DataAnnotationLocalizerProvider = (type, factory) =>
                     factory.Create(typeof(SharedResource));
             });

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


builder.Services.AddDbContext<PhoneBookDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddTransient<IResourceManager, ResourceManager<SharedResource>>();
builder.Services.AddTransient<CommandDispatcher>();
builder.Services.AddTransient<QueryDispatcher>();


builder.Services.AddTransient<IPersonCommandRepository, PersonCommandRepository>();
builder.Services.AddTransient<AddPersonCommandHandler>();
builder.Services.AddTransient<CommandHandler<AddPersonCommand>, AddPersonCommandHandler>();
builder.Services.AddTransient<IQueryHandler<AllPersonQuery, List<Person>>, AllPersonQueryHandler>();
builder.Services.AddTransient<IPersonQueryRepository, PersonQueryRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
