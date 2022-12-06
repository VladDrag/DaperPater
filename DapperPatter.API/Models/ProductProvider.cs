using Dapper;
using Microsoft.Data.Sqlite;
using SqliteDapper.Demo.Database;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DapperPatter.API.Models;

public interface IProductRepository
{
	Task<IEnumerable<Product>> Get();
}

public class ProductRepository : IProductRepository
{
	private readonly DatabaseConfig databaseConfig;

	public ProductProvider(DatabaseConfig databaseConfig)
	{
		this.databaseConfig = databaseConfig;
	}

	public async Task<IEnumerable<Product>> Get()
	{
		using var connection = new SqliteConnection(databaseConfig.Name);

		return await connection.QueryAsync<Product>("SELECT rowid AS Id, Name, Description FROM Product;");
	}
}