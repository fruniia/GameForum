namespace GamersParadiseAPI.Models;
public class Post
{
	public int Id { get; set; }
	public int Score { get; set; }
	public string Header { get; set; }
	public string Text {get; set;}
	public int UserId { get; set; }
	public List<Comment>? Comments { get; set; }
}



