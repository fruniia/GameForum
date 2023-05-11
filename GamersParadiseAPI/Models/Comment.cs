namespace GamersParadiseAPI.Models;
public class Comment
{
	public int Id { get; set; }
	public int Score { get; set; }
	public string Title { get; set; }
	public string Message { get; set; }
	public int UserId { get; set; }
	public DateTime Date { get; set; }
}
