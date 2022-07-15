using Client_Biblioteca_TrabalhoFinal.Data.Repository;
using Client_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRepositoryObras, RepositoryObras>();
builder.Services.AddScoped<IRepositoryObras_Nucleos, RepositoryObras_Nucleos>();
builder.Services.AddScoped<IRepositoryLeitores, RepositoryLeitores>();
builder.Services.AddScoped<IRepositoryNucleos, RepositoryNucleos>();
builder.Services.AddScoped<IRepositoryRequisicoes, RepositoryRequisicoes>();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddHttpClient();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
