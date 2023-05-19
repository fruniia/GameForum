namespace GamersParadiseAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MainCategoryController : ControllerBase
{
    private static List<MainCategory> _categories;

    [HttpGet]
    public async Task<List<MainCategory>> Get()
    {
        _categories = await MainCategoryManager.GetMainCategories(); 
        return _categories;
    }

    [HttpGet("{id}")]
    public async Task<MainCategory> GetOneMainCategory(int id)
    {
        if (_categories is null)
        {
            _categories = await MainCategoryManager.GetMainCategories();
        }
        var category = _categories.Where(x => x.Id == id).FirstOrDefault();

        return category;
    }

    [HttpPost]
    public async Task CreateMainCategory([FromBody] MainCategory mainCategory)
    {
        if (_categories is null)
        {
            _categories = await MainCategoryManager.GetMainCategories();
        }
        mainCategory.Id = _categories.TakeLast(1).Select(x => x.Id).FirstOrDefault() + 1;
        _categories.Add(mainCategory);
    }

    [HttpPut("{id}")]
    public async Task UpdateMainCategory([FromBody] MainCategory mainCategory, int id)
    {
        if (_categories is null)
        {
            _categories = await MainCategoryManager.GetMainCategories();
        }

        var category = _categories.Where(x => x.Id == id).FirstOrDefault();
        if (category is not null)
        {
            category.Name = mainCategory.Name;

        }

    }

    [HttpDelete("{id}")]
    public async Task DeleteMainCategory(int id)
    {
        if (_categories is null)
        {
            _categories = await MainCategoryManager.GetMainCategories();

        }

        if (id <= _categories.Count)
        {
            var deleteCategory = _categories.Where(x => x.Id == id).FirstOrDefault();
            _categories.Remove(deleteCategory);
        }
    }

}
