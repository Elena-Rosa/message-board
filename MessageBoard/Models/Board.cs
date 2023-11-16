namespace MessageBoardApi;

public class Board
{
    public int BoardId { get; set; }
    public string Name { get; set; }
    public List<Message> Messages { get; set; }
}