using Ensolvers_Challenge.Backend.Models;
using Ensolvers_Challenge.Shared.Dtos.NoteDtos;

namespace Ensolvers_Challenge.Backend.Repositories.Interfaces
{
    public interface INoteRepository : IGenericRepository<Note, int>
    {
        Task<List<GetNoteDto>> GetAllNotes(string userId, int noteStatus, int categoryId);
        Task<bool> Delete(string userId, int noteId);
        Task<Note?> GetNoteWithCategories(string userId, int noteId);
    }
}
