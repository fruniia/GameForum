using System.Text.Json.Serialization;

namespace GamersParadiseAPI.Models;
public class UserThread
{
	public int Id { get; set; }
	public int Score { get; set; }
	public string Header { get; set; }
	public string Content {get; set;}
    public DateTime Date { get; set; }
    public DateTime? EditedDate { get; set; }
    public int SubCategoryId { get; set; }
	public string UserId { get; set; }
	public bool Reported { get; set; }

}



