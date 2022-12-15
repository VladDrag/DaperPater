using Microsoft.AspNetCore.Mvc;
using DapperPatter.API.Models;
// using System.Data.SQLite;
using Microsoft.Data.Sqlite;
using DapperPatter.API.DatabaseService;
using System.Linq;
using Dapper;

namespace DapperPatter.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonsController : ControllerBase
{
	private string _connectionString;

	public PersonsController(DbService databaseService)
	{
		_connectionString = databaseService.GetConnectionString();
		// Console.WriteLine(connStr);
		using (var connection = new SqliteConnection(_connectionString))
		{
			connection.Open();
			connection.Execute(@"CREATE TABLE IF NOT EXISTS Persons (Id INTEGER PRIMARY KEY, FirstName TEXT, LastName TEXT, Email TEXT, City TEXT)");
		}
	}
    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    // private readonly ILogger<WeatherForecastController> _logger;

    // public WeatherForecastController(ILogger<WeatherForecastController> logger)
    // {
    //     _logger = logger;
    // }

    [HttpGet()]
	public async Task<IEnumerable<Person>> GetPersons()
	{
		using (var connection = new SqliteConnection(_connectionString))
		{
			connection.Open();
			var result = await connection.QueryAsync<Person>("SELECT * FROM Persons");
			if (result == null) return new List<Person>();
			return result;
		}

	}

	// [HttpGet("{id}")]
	// public Person GetPerson(int id)
	// {
	// 	return _connection.Query<Person>("SELECT * FROM Persons WHERE Id = @Id", new { Id = id }).FirstOrDefault();
	// }
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }
	[HttpPost()]
	public async Task<Person> PostPerson(Person person)
	{
		using (var connection = new SqliteConnection(_connectionString))
		{
			connection.Open();
			var result = await connection.ExecuteAsync("INSERT INTO Persons (FirstName, LastName, Email, City) VALUES (@FirstName, @LastName, @Email, @City)", person);
			return person;
		}
	}
}
