using Microsoft.AspNetCore.Mvc;
using PuzzleGameDomain;

namespace PuzzleGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuzzleController : ControllerBase
    {
        private readonly Puzzle _mockPuzzle = new Puzzle(new[] {
                                                    "----5----",
                                                    "--9----3-",
                                                    "---------",
                                                    "-----1---",
                                                    "-6--9--2-",
                                                    "---------",
                                                    "-------9-",
                                                    "-9-------",
                                                    "-4---8---"
                                                });

        [HttpGet]
        public Puzzle Get()
        {
            return _mockPuzzle;
        }
    }
}