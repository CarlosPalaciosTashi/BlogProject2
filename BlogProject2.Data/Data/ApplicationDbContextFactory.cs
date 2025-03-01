using BlogProject2.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BlogProject2.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Obtener el directorio raíz del proyecto
            var basePath = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName 
                           ?? Directory.GetCurrentDirectory(); // Asegurar que no sea null

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(basePath, "BlogProject2.Web")) // Asegurar que basePath tiene un valor
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("No se encontró la cadena de conexión 'DefaultConnection'.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
