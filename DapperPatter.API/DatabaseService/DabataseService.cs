using System.Data.SQLite;
// using Dapper;
// using DapperPatter.API.Models;
// using Microsoft.Data.Sqlite;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DapperPatter.API.DatabaseService;


public class DbService
{
	private string _connectionString;
	// private System.Configuration.ConfigurationManager _configuration = new System.Configuration.ConfigurationManager();

	// public DbService(IConfiguration configuration)
	public DbService(ConfigurationBuilder builder)
	{
		builder.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json");
		var config = builder.Build();

		_connectionString = config.GetConnectionString("DefaultConnection");
		// string connString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
	}

	public string GetConnectionString()
	{
		
		// connection.Open();

		return _connectionString;
	}
}