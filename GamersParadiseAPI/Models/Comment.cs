namespace GamersParadiseAPI.Models;
public class Comment
{
	public int Id { get; set; }
	public int Score { get; set; }
	public string Content { get; set; }
	public DateTime CreatedDate { get; set; }
	public DateTime? EditedDate { get; set; }
	public int UserThreadId { get; set; }
	public string UserId { get; set; }
}
