
using ManagementMB.CQRS.Handlers;
using ManagementMB.CQRS.Queries.Query_Handlers;
using ManagementMB.Infrastructure;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Interfaces.IServices;
using ManagementMB.Repositories;
using ManagementMB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ManagementMB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionStringsSQL")));
            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ISaleRepository, SaleRepository>();
            builder.Services.AddScoped<ISaleService, SaleService>();
            builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            builder.Services.AddScoped<IPurchaseService, PurchaseService>();
            builder.Services.AddScoped<IExpensesRepository, ExpensesRepository>();
            builder.Services.AddScoped<IExpensesService, ExpensesService>();
            builder.Services.AddScoped<IBalanceService, BalanceService>();
            builder.Services.AddScoped<IBalanceRepository, BalanceRepository>();
            builder.Services.AddScoped<ICashFlowService, CashFlowService>();
            builder.Services.AddScoped<ICashFlowRepository, CashFlowRepository>();
            builder.Services.AddScoped<IMaterialResourcesRepository, MaterialResourcesRepository>();
            builder.Services.AddScoped<IMaterialResourcesService, MaterialResourcesService>();

            builder.Services.AddScoped<IDebtorsRepository, DebtorsRepository>();
            builder.Services.AddScoped<ILiabilitiiesRepository, LiabilitiiesRepository>();
            builder.Services.AddScoped<IFinancialIndicatorsRepository, FinancialIndicatorsRepository>();


            builder.Services.AddScoped<AuthService>();

            builder.Services.AddScoped<CreateWorkerCommandHandler>();
            builder.Services.AddScoped<UpdateWorkerCommandHandler>();
            builder.Services.AddScoped<DeleteWorkerCommandHandler>();
            builder.Services.AddScoped<GetWorkerQueryHandler>();
            builder.Services.AddScoped<GetWorkerByIdQueryHandler>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Management application APIs", Version = "v1" });

                // Add the JWT Bearer authentication scheme
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                };
                c.AddSecurityDefinition("Bearer", securityScheme);

                // Use the JWT Bearer authentication scheme globally
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                         { securityScheme, new List<string>() }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //Enable CORS 
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
