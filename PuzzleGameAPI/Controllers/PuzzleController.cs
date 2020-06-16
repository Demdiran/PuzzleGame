using System.Collections;
using Microsoft.AspNetCore.Mvc;
using PuzzleGameDomain;
using PuzzleGamePersistence;

namespace PuzzleGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuzzleController : ControllerBase
    {
        private readonly PuzzleRepository _puzzleRepository;
        public PuzzleController(PuzzleRepository puzzleRepository)
        {
            _puzzleRepository = puzzleRepository;
        }

        [HttpGet]
        public Puzzle Get()
        {
            return _puzzleRepository.GetPuzzle();
        }

        [HttpGet]
        [Route("getPuzzleIds")]
        public IList GetPuzzleIds()
        {
            return _puzzleRepository.GetPuzzleIds();
        }

        [HttpGet]
        [Route("getPuzzle")]
        public Puzzle GetPuzzleById([FromRoute] int id)
        {
            return _puzzleRepository.GetPuzzleById(id);
        }
    }
}