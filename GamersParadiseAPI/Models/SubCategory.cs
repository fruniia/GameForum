namespace GamersParadiseAPI.Models;

public class SubCategory
{
	public int Id { get; set; }
	public string Name { get; set; }
	public List<Post>? Posts { get; set; }
}
