using Ensolvers_Challenge.Shared.Dtos;
using Ensolvers_Challenge.Shared.Dtos.NoteDtos;

namespace Ensolvers_Challenge.Backend.Services.Interfaces
{
    public interface INoteService
    {
        Task<ServiceResponse<List<GetNoteDto>>> AddNote(UpdateNoteDto addNote, string userId, int noteStatus, int categoryId);
        Task<ServiceResponse<List<GetNoteDto>>> GetAllNotes(string userId, int noteStatus, int categoryId);
        Task<ServiceResponse<List<GetNoteDto>>> DeleteNote(string userId, int noteId, int noteStatus, int categoryId);
        Task<ServiceResponse<List<GetNoteDto>>> EditNote(string userId, int noteId, UpdateNoteDto updatedNote, int noteStatus, int categoryId);
    }
}
