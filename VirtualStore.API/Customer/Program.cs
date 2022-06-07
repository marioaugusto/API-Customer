using System.IO.Compression;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VirtualStore.Domain.Customer.Handlers;
using VirtualStore.Domain.Customer.Repositories;
using VirtualStore.Infra.Customer.Contexts;
using VirtualStore.Infra.Customer.Repositories;

var builder = WebApplication.CreateBuilder(args);
ConfigureAuthentication(builder);
ConfigureMvc(builder);
ConfigureServices(builder);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
LoadConfiguration(app);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();
app.UseResponseCompression();

app.UseRouting();

//Para Permitir endereços Localhost
app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader() );

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

void LoadConfiguration(WebApplication app)
{
    /*Configuration.JwtKey = app.Configuration.GetValue<string>("JwtKey");
    Configuration.ApiKeyName = app.Configuration.GetValue<string>("ApiKeyName");
    Configuration.ApiKey = app.Configuration.GetValue<string>("ApiKey");

    var smtp = new Configuration.SmtpConfiguration();
    app.Configuration.GetSection("SmtpConfiguration").Bind(smtp);
    Configuration.Smtp = smtp;*/
}

void ConfigureAuthentication(WebApplicationBuilder builder)
{
    //Autenticação Gerando o Token Local
   /* var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });*/

//Autenticação Acessando com Token do Firebase (LOgin com Google, Facebook...) - Ajustar
    builder.Services
               .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.Authority = "https://securetoken.google.com/api-customer-95f27";
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidIssuer = "https://securetoken.google.com/api-customer-95f27",
                       ValidateAudience = true,
                       ValidAudience = "api-customer-95f27",
                       ValidateLifetime = true
                   };
               });
}

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services.AddMemoryCache();
    builder.Services.AddResponseCompression(options =>
    {
        // options.Providers.Add<BrotliCompressionProvider>();
        options.Providers.Add<GzipCompressionProvider>();
        // options.Providers.Add<CustomCompressionProvider>();
    });
    builder.Services.Configure<GzipCompressionProviderOptions>(options =>
    {
        options.Level = CompressionLevel.Optimal;
    });
    builder
        .Services
        .AddControllers()
        .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; })
        .AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        });
}

void ConfigureServices(WebApplicationBuilder builder)
{
    //Banco de Dados em Memória
    //builder.Services.AddDbContext<MyContext>(options => options.UseInMemoryDatabase("Database"));

    //Nactive Dependency Injections
    // AddDbContext é um AddScoped otimizado para Banco de Dados, abre a conexão com o BD no inicio da requisicao e fecha no final
    
    builder.Services.AddDbContext<MyContext>(
        options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));

    builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
    builder.Services.AddTransient<CustomerHandler, CustomerHandler>();



}