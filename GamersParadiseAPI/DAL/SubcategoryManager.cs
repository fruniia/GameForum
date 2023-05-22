using GamersParadiseAPI.Models;

namespace GamersParadiseAPI.DAL;
public static class SubCategoryManager
{
    public static List<SubCategory> SubCategory { get; set; }

    public static async Task<List<SubCategory>> GetSubCategories()
    {
        var subCategories = new List<SubCategory>();

        if (SubCategory is null)
        {
            SubCategory = new List<SubCategory>();
            //subCategories.Add(new SubCategory { Id = 1, Name = "Playstation 5" });
            //subCategories.Add(new SubCategory { Id = 2, Name = "Playstation 4" });
        }
       
        SubCategory.AddRange(subCategories);

        return SubCategory;
    }

}
