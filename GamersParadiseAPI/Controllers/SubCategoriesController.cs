namespace GamersParadiseAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubCategoriesController : ControllerBase
{
	private static List<SubCategory> _categories;

	private static MainCategoryController _mainCategoryController;

	private static MainCategory _mainCategory;

	[HttpGet]
	public async Task<List<SubCategory>> GetSubCategories()
	{

		_mainCategory = _mainCategoryController.GetOneMainCategory();


        if (_mainCategory.SubCategories is null)
		{
            //TODO: Ta bort!
            _mainCategory.SubCategories = new List<SubCategory>();
            _categories = new List<SubCategory>();
			_categories.Add(new SubCategory { Id = 1, Name = "Playstation 5", UserThreads = null });
			_categories.Add(new SubCategory { Id = 2, Name = "Playstation 4", UserThreads = null });
		}
		return _categories;
	}

	[HttpGet("{id}")]
	public async Task<SubCategory> GetOneSubCategory(int id)
	{
		if (_categories is null)
		{
			_categories = await GetSubCategories();
		}
		var category = _categories.Where(x => x.Id == id).FirstOrDefault();

		return category;
	}

	[HttpPost]
	public async Task CreateSubCategory([FromBody] SubCategory subCategory)
	{
		if (_categories is null)
		{
			_categories = await GetSubCategories();
		}
		subCategory.Id = _categories.TakeLast(1).Select(x => x.Id).FirstOrDefault() + 1;
		subCategory.UserThreads = null;
		_categories.Add(subCategory);
	}

	[HttpPut("{id}")]
	public async Task UpdateSubCategory([FromBody] SubCategory subCategory, int id)
	{
		if (_categories is null)
		{
			_categories = await GetSubCategories();
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
			_categories = await GetSubCategories();
		}

		await GetSubCategories();
		if (id <= _categories.Count)
		{
			var deleteCategory = _categories.Where(x => x.Id == id).FirstOrDefault();
			_categories.Remove(deleteCategory);
		}
	}

}
