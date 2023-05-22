namespace GamersParadiseAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubCategoryController : ControllerBase
{
	private static List<SubCategory> _categories;

    [HttpGet]
    public async Task<List<SubCategory>> Get()
    {
        _categories = await SubCategoryManager.GetSubCategories();
        return _categories;
    }

    [HttpGet("{id}")]
	public async Task<SubCategory> GetOneSubCategory(int id)
	{
		if (_categories is null)
		{
			_categories = await SubCategoryManager.GetSubCategories();
		}
		var category = _categories.Where(x => x.Id == id).FirstOrDefault();

		return category;
	}

	[HttpPost]
	public async Task CreateSubCategory([FromBody] SubCategory subCategory)
	{
		if (_categories is null)
		{
            _categories = await SubCategoryManager.GetSubCategories();
        }
        subCategory.Id = _categories.TakeLast(1).Select(x => x.Id).FirstOrDefault() + 1;
		_categories.Add(subCategory);
	}

	[HttpPut("{id}")]
	public async Task UpdateSubCategory([FromBody] SubCategory subCategory, int id)
	{
		if (_categories is null)
		{
            _categories = await SubCategoryManager.GetSubCategories();
        }

        var category = _categories.Where(x => x.Id == id).FirstOrDefault();
		if (category is not null)
		{
			category.Name = subCategory.Name;

		}

	}

	[HttpDelete("{id}")]
	public async Task DeleteSubCategory(int id)
	{
		if (_categories is null)
		{
            _categories = await SubCategoryManager.GetSubCategories();
        }

       

        if (id <= _categories.Count)
		{
			var deleteCategory = _categories.Where(x => x.Id == id).FirstOrDefault();
			_categories.Remove(deleteCategory);
		}
	}

}
