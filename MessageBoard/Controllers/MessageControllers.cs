[ApiController]
[Route("api/boards/{boardId}/messages")]
public class MessagesController : ControllerBase
{
    private readonly MessageBoardContext _context;

    public MessagesController(MessageBoardContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Message>> GetMessages(int boardId)
    {
        var messages = _context.Messages.Where(m => m.BoardId == boardId).ToList();
        return messages;
    }

    [HttpPost]
    public ActionResult<Message> PostMessage(int boardId, Message message)
    {
        var board = _context.Boards.Find(boardId);

        if (board == null)
        {
            return NotFound("Board not found");
        }

        message.BoardId = boardId;
        message.CreatedAt = DateTime.Now;

        _context.Messages.Add(message);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMessages), new { boardId }, message);
    }

    // Other actions...
}
