using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onyx.Products.Application.Services;
using Onyx.Products.Shared.Enums;
using Onyx.Products.Shared.Models;

//TODO: Unit tests, integration tests
//TODO: push to git repo, write readme 

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IMapper _mapper;
    private readonly IProductsService _productsService;

    public ProductsController(
        ILogger<ProductsController> logger,
        IMapper mapper,
        IProductsService productsService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
    }

    //TODO: include in readme notes it should ideally be implemented using pagination, explain how to implement
    [HttpGet(Name = "GetAllProducts")]
    [Authorize(Policy = "CanGetAllProducts")]
    public async Task<IActionResult> Get()
    {
        IEnumerable<Product> returnProducts;
        try
        {
            var products = await _productsService.GetAllProducts();
            returnProducts = _mapper.Map<IEnumerable<Product>>(products);
            
            _logger.LogInformation($"GetAllProducts succeeded {DateTime.UtcNow.ToShortDateString()}");
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
        return Ok(returnProducts);
    }

    [HttpGet("colour/{colour}", Name = "GetProductByColour")]
    [Authorize(Policy = "CanFilterProductsByColour")]
    public async Task<IActionResult> Get(ColourEnum colour)
    {
        IEnumerable<Product> returnProducts;
        try
        {
            var products = await _productsService.GetProductsByColour(colour);
            returnProducts = _mapper.Map<IEnumerable<Product>>(products);

            _logger.LogInformation($"GetProductByColour succeeded {DateTime.UtcNow}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
        return Ok(returnProducts);
    }
}