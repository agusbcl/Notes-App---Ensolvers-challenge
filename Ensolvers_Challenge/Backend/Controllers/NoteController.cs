using Ensolvers_Challenge.Backend.Services.Interfaces;
using Ensolvers_Challenge.Shared.Dtos;
using Ensolvers_Challenge.Shared.Dtos.NoteDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ensolvers_Challenge.Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetNoteDto>>>> GetAllNotes(int noteStatus, int categoryId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _noteService.GetAllNotes(userId, noteStatus, categoryId));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetNoteDto>>>> AddNote(UpdateNoteDto newNote, int noteStatus, int categoryId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _noteService.AddNote(newNote, userId, noteStatus, categoryId));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetNoteDto>>>> DeleteNote(int noteId, int noteStatus, int categoryId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _noteService.DeleteNote(userId, noteId, noteStatus, categoryId));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetNoteDto>>>> EditNote(UpdateNoteDto updatedNote, int noteId, int noteStatus, int categoryId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _noteService.EditNote(userId, noteId, updatedNote, noteStatus, categoryId));
        }

        [HttpGet("SearchNotesByCategory")]
        public async Task<ActionResult<ServiceResponse<List<GetNoteDto>>>> SearchNotesByCategory(int noteStatus, int categoryId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _noteService.GetAllNotes(userId, noteStatus, categoryId));
        }
    }
}
