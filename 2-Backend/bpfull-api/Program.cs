using bpfull_api.Middleware;
using bpfull_core.Cliente;
using bpfull_core.Mapper;
using bpfull_core.Utils.StringFormatter;
using bpfull_core.Utils.Validator;
using bpfull_infrastructure.Cliente;
using bpfull_infrastructure.Contato;
using bpfull_infrastructure.Data;
using bpfull_infrastructure.Documento;
using bpfull_infrastructure.Endereco;
using bpfull_shared.Model.Cliente;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
});

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddAutoMapper(typeof(ClienteProfile));
builder.Services.AddAutoMapper(typeof(ContatoProfile));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<DbSession>();

builder.Services.AddTransient<IClienteManager, ClienteManager>();
builder.Services.AddTransient<IClienteDAL, ClienteDAL>();
builder.Services.AddTransient<IContatoDAL, ContatoDAL>();
builder.Services.AddTransient<IDocumentoDAL, DocumentoDAL>();
builder.Services.AddTransient<IEnderecoDAL, EnderecoDAL>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IStringFormatter, StringFormatter>();

builder.Services.AddScoped<IRequestValidator<ClienteRequestModel>, ClienteRequestValidator>();
builder.Services.AddScoped<IValidatorCNPJ, ValidadorCnpj>();
builder.Services.AddScoped<IValidatorCPF, ValidadorCpf>();
builder.Services.AddScoped<IValidatorEmail, ValidadorEmail>();


var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
    c.RoutePrefix = string.Empty; // Exibe o Swagger UI na raiz da aplicação
});

app.UseCors("AllowAllOrigins");

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();