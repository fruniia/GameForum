﻿namespace GamersParadiseAPI.Models;
public class Message
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int SenderId { get; set; }
    public int RecipientId { get; set; }
}
