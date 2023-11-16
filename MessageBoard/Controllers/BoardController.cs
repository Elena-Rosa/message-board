using Microsoft.AspNetCore.Mvc;

namespace MessageBoard.Controllers;

[ApiController]
[Route("[controller]")]
public class BoardController : ControllerBase
{
  private static MessageBoardContext _context;
  {
    _context = context;
  }

  private readonly ILogger<BoardController> _logger;

  public BoardController(ILogger<BoardController> logger)
  {
    _logger = logger;
  }

  [HttpGet(Name = "GetMessageBoard")]
  public IEnumerable<MessageBoard> GetBoards()
  {
    var boards = _context.Boards
      .Include(b => b.Messages)
      .ToList();
  }
}
