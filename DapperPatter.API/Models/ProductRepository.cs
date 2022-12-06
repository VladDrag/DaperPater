using DapperPatter.API.Database;
using Microsoft.Data.Sqlite;

namespace DapperPatter.API.Models;

public interface IProductRepository
{
	Task Create(Product product);
}
public class ProductRepository : IProductRepository
{
	private readonly DatabaseConfig databaseConfig;

	public ProductRepository(DatabaseConfig databaseConfig)
	{
		this.databaseConfig = databaseConfig;
	}

	public async Task Create(Product product)
	{
		using var connection = new SqliteConnection(databaseConfig.Name);

		await connection.ExecuteAsync("INSERT INTO Product (Name, Description)" +
			"VALUES (@Name, @Description);", product);
	}
}
