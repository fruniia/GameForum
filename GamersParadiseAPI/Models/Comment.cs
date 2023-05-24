namespace GamersParadiseAPI.Models;
public class Comment
{
	public int Id { get; set; }
	public int Score { get; set; }
	public string Content { get; set; }
	public DateTime Date { get; set; }
	public int SubCategoryId { get; set; }
}
