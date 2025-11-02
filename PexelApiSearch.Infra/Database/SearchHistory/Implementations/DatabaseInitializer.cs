using Microsoft.Extensions.Configuration;
using Dapper;
using MySql.Data.MySqlClient;
using PexelApiSearch.Infra.Database.SearchHistory.Interfaces;

namespace PexelApiSearch.Infra.Database.SearchHistory.Implementations
{
    public class DatabaseInitializer : IDatabaseInitializer
    {

        private readonly string _connectionString;
        private readonly bool _shouldInitialize;

        public DatabaseInitializer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
            _shouldInitialize = Convert.ToBoolean(configuration.GetSection("Database:Initialize").Value);
        }

        public async Task InitializeAsync()
        {
            if (!_shouldInitialize)
                return;

            Console.WriteLine("🧱 Verificando e criando banco/tabelas se necessário...");

            var builder = new MySqlConnectionStringBuilder(_connectionString);
            var databaseName = builder.Database;
            builder.Database = "";

            // Cria banco se não existir
            using (var connection = new MySqlConnection(builder.ConnectionString))
            {
                await connection.ExecuteAsync($"CREATE DATABASE IF NOT EXISTS `{databaseName}`;");
            }

            // Cria tabela se não existir
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(@"
                    CREATE TABLE IF NOT EXISTS SearchHistory (
                        Id CHAR(36) NOT NULL,
                        Query VARCHAR(255) NOT NULL,
                        SearchDate DATETIME NOT NULL,
                        PRIMARY KEY (Id)
                    );
                ");
            }

            Console.WriteLine("✅ Banco e tabelas verificados/criados com sucesso!");
        }
    }
}

