using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ensolvers_Challenge.Backend.Data;
using Ensolvers_Challenge.Backend.Models;
using Ensolvers_Challenge.Backend.Repositories.Interfaces;
using Ensolvers_Challenge.Shared.Dtos.NoteDtos;
using Microsoft.EntityFrameworkCore;

namespace Ensolvers_Challenge.Backend.Repositories
{
    public class NoteRepository : GenericRepository<Note, int>, INoteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public NoteRepository(IMapper mapper, ApplicationDbContext context) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<GetNoteDto>> GetAllNotes(string userId, int noteStatus, int categoryId)
        {
            return await GetAll()
                    .Where(n => n.ApplicationUserId == userId && n.Status == noteStatus &&
                        (categoryId == 0 || n.Categories.Select(c => c.Id).Contains(categoryId)))
                    .ProjectTo<GetNoteDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<bool> Delete(string userId, int noteId)
        {
            var dbNote = await Entities.FirstOrDefaultAsync(n => n.Id == noteId && n.ApplicationUserId == userId);
            var result = Delete(dbNote);

            return result;
        }

        public async Task<Note?> GetNoteWithCategories(string userId, int noteId)
        {
            return await Entities
                    .Include(n => n.Categories)
                    .FirstOrDefaultAsync(n => n.Id == noteId && n.ApplicationUserId == userId);
        }
    }
}
