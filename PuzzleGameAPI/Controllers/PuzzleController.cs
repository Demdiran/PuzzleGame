using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PuzzleGameDomain;
using PuzzleGameDomain.Rules;
using PuzzleGamePersistence;

namespace PuzzleGameAPI.Controllers
{
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
        [Route("puzzle/GetPuzzleIds")]
        public IList GetPuzzleIds()
        {
            return _puzzleRepository.GetPuzzleIds();
        }

        [HttpGet]
        [Route("puzzle/GetPuzzleNames")]
        public IList GetPuzzleNames()
        {
            return _puzzleRepository.GetPuzzleNames();
        }

        [HttpGet]
        [Route("puzzle/GetPuzzle/{id}")]
        public Puzzle GetPuzzleById([FromRoute] int id)
        {
            return _puzzleRepository.GetPuzzleById(id);
        }

        [HttpGet]
        [Route("puzzle/GetEmptyPuzzle")]
        public Puzzle GetEmptyPuzzle()
        {
            return new Puzzle(9);
        }

        [HttpPost]
        [Route("puzzle/SavePuzzle")]
        public bool SavePuzzle([FromBody]Puzzle puzzle)
        {
            puzzle.SetHints();
            _puzzleRepository.SaveOrUpdate(puzzle);
            return true;
        }
    }
}