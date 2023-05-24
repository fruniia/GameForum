using GamersParadiseAPI.DAL;

namespace GamersParadiseAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubCategoryController : ControllerBase
{
    private readonly SubCategoryManager _subCategoryManager;
    public SubCategoryController(SubCategoryManager subCategoryManager)
    {
        _subCategoryManager = subCategoryManager;
    }

    [HttpGet]
    public async Task<List<SubCategory>> Get()
    {
        var subCategories = await _subCategoryManager.GetSubCategories();
        return subCategories;
    }

    [HttpGet("{id}")]
    public async Task<SubCategory> GetOneSubCategory(int id)
    {
        var subCategory = await _subCategoryManager.GetOneSubCategory(id);
        return subCategory;
    }

    [HttpPost]
    public async Task CreateSubCategory([FromBody] SubCategory subCategory)
    {
        await _subCategoryManager.AddSubCategory(subCategory);
    }

    [HttpPut("{id}")]
    public async Task UpdateSubCategory([FromBody] SubCategory subCategory, int id)
    {
        await _subCategoryManager.UpdateSubCategory(subCategory, id);
    }

    [HttpDelete("{id}")]
    public async Task DeleteSubCategory(int id)
    {
        await _subCategoryManager.DeleteSubCategory(id);
    }

}
