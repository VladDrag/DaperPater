using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SqliteDapper.Demo.ProductMaster;


namespace DaperPatter.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductMasterController : ControllerBase
{
	private readonly IProductProvider productProvider;
	private readonly IProductRepository productRepository;

	public ProductController(IProductProvider productProvider,
		IProductRepository productRepository)
	{
		this.productProvider = productProvider;
		this.productRepository = productRepository;
	}

	// GET: api/<ProductController>
	[HttpGet]
	public async Task<IEnumerable<Product>> Get()
	{
		return await productProvider.Get();
	}


	// POST api/<ProductController>
	[HttpPost]
	public async Task Post([FromBody] Product product)
	{
		await productRepository.Create(product);
	}
}