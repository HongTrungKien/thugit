﻿using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Interfaces;
using KoiFishApp.Repositories.Repositories;
using KoiFishApp.Services.Interfaces;
using KoiFishApp.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// DI
builder.Services.AddDbContext<QlcktnContext>();
// DI Repositories
builder.Services.AddScoped<IKoiFishRepositories, KoiFishRepositories>();
// DI Services
builder.Services.AddScoped<IKoiFishServices, KoiFishServices>();
builder.Services.AddScoped<IPondServices, PondServices>(); // Đăng ký IPondServices
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

app.Run();
