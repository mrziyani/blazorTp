using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DAL.Models  // Adaptez ce namespace si nécessaire
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Déterminez le répertoire de base.
            // Comme DAL est une bibliothèque, il n'a pas de appsettings.json propre.
            // En général, ce fichier se trouve dans le projet WebAPI.
            // Vous pouvez ajuster le chemin de base pour pointer vers le dossier du projet WebAPI.
            // Par exemple, si le dossier WebAPI est au même niveau que DAL :
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "WebAPI");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Récupérer la chaîne de connexion depuis la configuration
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
