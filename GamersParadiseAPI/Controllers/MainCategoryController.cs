using Microsoft.EntityFrameworkCore;

namespace GamersParadiseAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MainCategoryController : ControllerBase
{
    private readonly MainCategoryManager _mainCategoryManager;

    public MainCategoryController(MainCategoryManager mainCategoryManager)
    {
        _mainCategoryManager = mainCategoryManager;
    }

    [HttpGet]
    public async Task<List<MainCategory>> Get()
    {
        var mainCategories = await _mainCategoryManager.GetMainCategories();
        return mainCategories;
    }

    [HttpGet("{id}")]
    public async Task<MainCategory> GetOneMainCategory(int id)
    {
        var mainCategories = await _mainCategoryManager.GetMainCategories();

        var mainCategory = mainCategories.Where(x => x.Id == id).FirstOrDefault();

        return mainCategory;
    }

    [HttpPost]
    public async Task CreateMainCategory([FromBody] MainCategory mainCategory)
    {
        await _mainCategoryManager.AddMainCategory(mainCategory);
    }

    [HttpPut("{id}")]
    public async Task UpdateMainCategory([FromBody] MainCategory mainCategory, int id)
    {
        await _mainCategoryManager.UpdateMainCategory(mainCategory, id);
    }

    [HttpDelete("{id}")]
    public async Task DeleteMainCategory(int id)
    {
        await _mainCategoryManager.DeleteMainCategory(id);
    }

}
