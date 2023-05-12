using GamersParadiseAPI.Models;

namespace GamersParadiseAPI.DAL;
public static class SubcategoryManager
{
    public static List<SubCategory> SubCategory { get; set; }

    public static async Task<List<SubCategory>> GetSubCategories()
    {


        var subCategories = new List<SubCategory>();
        var userThreads = await GetAllUserThreads();

        if (SubCategory is null)
        {
            SubCategory = new List<SubCategory>();
            subCategories.Add(new SubCategory { Id = 1, Name = "Playstation 5", UserThreads = userThreads });
            subCategories.Add(new SubCategory { Id = 2, Name = "Playstation 4", UserThreads = userThreads });
        }
        //var subCategory = subCategories.Where(x => x.Id == 1).FirstOrDefault();
        //var subCategory2 = subCategories.Where(x => x.Id == 2).FirstOrDefault();

        //if (subCategory is null)
        //{
        //    subCategory.UserThreads = new();
        //    subCategory.UserThreads.Add(userThreads[0]);
        //}
        //if (subCategory2 is null)
        //{
        //    subCategory2.UserThreads = new();
        //    subCategory2.UserThreads.Add(userThreads[1]);
        //}



        SubCategory.AddRange(subCategories);

        return SubCategory;
    }
    public static async Task<List<UserThread>> GetAllUserThreads()      //Denna ska in i projektet.
    {

        var userThreads = new List<UserThread>
        {
                new UserThread { Id = 1, Header = "Jag gillar spel", Score = 0, Comments = null, Text = "Jag gillar att spela spel", UserId = 1 },
                new UserThread { Id = 2, Header = "Jag gillar spel 2", Score = 3, Comments = null, Text = "Jag gillar att spela spel 2", UserId = 2 }
        };

        return userThreads;
    }
}
