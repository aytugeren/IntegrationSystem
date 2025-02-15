namespace Category.API.Controllers
{
    using Category.API.Entities;
    using Category.API.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepositories _categoryRepository;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryRepositories categoryRepository, ILogger<CategoryController> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Category>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            return Ok(categories);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Category>> AddCategory([FromBody] Category category)
        {
            await _categoryRepository.AddCategory(category);
            return Ok(category);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Category>> UpdateCategory([FromBody] Category category)
        {
            return Ok(await _categoryRepository.UpdateCategory(category));
        }

        [HttpDelete("{id}", Name ="DeleteCategory")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteCategoryById(string id)
        {
            return Ok(await _categoryRepository.DeleteCategory(id));
        }
    }
}
