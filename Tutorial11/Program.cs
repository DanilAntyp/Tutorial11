using Tutorial11.Data;
using Tutorial11.Services;
using Microsoft.EntityFrameworkCore;

namespace Tutorial11;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllers();

        builder.Services.AddScoped<IDbService, DbService>();
        builder.Services.AddScoped<IPatientService, PatientService>();
        builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();

        builder.Services.AddDbContext<DatabaseContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
        );

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();
        app.Run();

    }
}