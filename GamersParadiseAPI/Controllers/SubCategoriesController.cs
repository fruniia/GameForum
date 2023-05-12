﻿namespace GamersParadiseAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubCategoriesController : ControllerBase
{
	private static List<SubCategory> _categories;

	MainCategory MainRoot { get; set; }


    //[HttpGet]
    //public async Task<MainCategory> Get()
    //{
    //	MainRoot = new MainCategory();

    //	MainRoot.SubCategories = await SubcategoryManager.GetSubCategories();
    //	return MainRoot;
    //}

    [HttpGet]
    public async Task<List<SubCategory>> Get()
    {
		List<SubCategory> categories = new();

        categories = await SubcategoryManager.GetSubCategories();
        return categories;
    }

    [HttpGet("{id}")]
	public async Task<SubCategory> GetOneSubCategory(int id)
	{
		if (_categories is null)
		{
			_categories = await SubcategoryManager.GetSubCategories();
		}
		var category = _categories.Where(x => x.Id == id).FirstOrDefault();

		return category;
	}

	[HttpPost]
	public async Task CreateSubCategory([FromBody] SubCategory subCategory)
	{
		if (_categories is null)
		{
            _categories = await SubcategoryManager.GetSubCategories();
        }
        subCategory.Id = _categories.TakeLast(1).Select(x => x.Id).FirstOrDefault() + 1;
		subCategory.UserThreads = new();
		_categories.Add(subCategory);
	}

	[HttpPut("{id}")]
	public async Task UpdateSubCategory([FromBody] SubCategory subCategory, int id)
	{
		if (_categories is null)
		{
            _categories = await SubcategoryManager.GetSubCategories();
        }

        var category = _categories.Where(x => x.Id == id).FirstOrDefault();
		if (category is not null)
		{
			category.Name = subCategory.Name;
			category.UserThreads = subCategory.UserThreads;

		}

	}

	[HttpDelete("{id}")]
	public async Task DeleteSubCategory(int id)
	{
		if (_categories is null)
		{
            _categories = await SubcategoryManager.GetSubCategories();
        }

       

        if (id <= _categories.Count)
		{
			var deleteCategory = _categories.Where(x => x.Id == id).FirstOrDefault();
			_categories.Remove(deleteCategory);
		}
	}

}
