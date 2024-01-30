using Ensolvers_Challenge.Shared.Dtos.NoteDtos;
using Ensolvers_Challenge.Shared.Enums;

namespace Ensolvers_Challenge.Frontend.Services.Interfaces
{
    public interface INoteService
    {
        Task<List<GetNoteDto>> GetNotes(NoteStatus noteStatus, int categoryId);
        Task<List<GetNoteDto>> AddNote(UpdateNoteDto newNote, NoteStatus noteStatus, int categoryId);
        Task<List<GetNoteDto>> DeleteNote(int noteId, NoteStatus noteStatus, int categoryId);
        Task<List<GetNoteDto>> EditNote(UpdateNoteDto updatedNote, NoteStatus noteStatus, int categoryId);
        Task<List<GetNoteDto>> GetNotesByCategory(NoteStatus noteStatus, int categoryId);
    }
}
