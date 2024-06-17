using MilkyProject.BussinessLayer.Abstract;
using MilkyProject.BussinessLayer.Concrete;
using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.DataAccessLayer.Context;
using MilkyProject.DataAccessLayer.EntityFramework;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>(); 

builder.Services.AddScoped<IProductService, ProductManager>(); 
builder.Services.AddScoped<IProductDal,EfProductDal>();

builder.Services.AddScoped<ISliderService, SliderManager>();
builder.Services.AddScoped<ISliderDal, EfSliderDal>(); 

builder.Services.AddScoped<IAboutDal,EfAboutDal>(); 
builder.Services.AddScoped<IAboutService,AboutManager>(); 

builder.Services.AddScoped<IAdressDal,EfAdressDal>(); 
builder.Services.AddScoped<IAdressService,AdressManager>(); 

builder.Services.AddScoped<IContactDal,EfContactDal>(); 
builder.Services.AddScoped<IContactService, ContactManager>(); 

builder.Services.AddScoped<ITeamDal,EfTeamDal>();
builder.Services.AddScoped<ITeamService, TeamManager>(); 

builder.Services.AddScoped<ITestimonialDal,EfTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>(); 

builder.Services.AddScoped<IWhyUsDal,EfWhyUsDal>(); 
builder.Services.AddScoped<IWhyUsService,WhyUsManager>();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler =
    ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<MilkyContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
