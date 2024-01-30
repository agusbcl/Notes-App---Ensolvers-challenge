using AutoMapper;
using Ensolvers_Challenge.Backend.Models;
using Ensolvers_Challenge.Backend.Repositories.Interfaces;
using Ensolvers_Challenge.Backend.Services.Interfaces;
using Ensolvers_Challenge.Shared.Dtos;
using Ensolvers_Challenge.Shared.Dtos.NoteDtos;
using Microsoft.EntityFrameworkCore;

namespace Ensolvers_Challenge.Backend.Services
{
    public class NoteService : INoteService
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<NoteService> _logger;

        public NoteService(IMapper mapper, ILogger<NoteService> logger, INoteRepository noteRepository,
            ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _noteRepository = noteRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ServiceResponse<List<GetNoteDto>>> AddNote(UpdateNoteDto addNote, string userId, int noteStatus, int categoryId)
        {
            var serviceResponse = new ServiceResponse<List<GetNoteDto>>();
            try
            {
                var newNote = _mapper.Map<Note>(addNote);
                newNote.ApplicationUserId = userId;
                await _noteRepository.Insert(newNote);
                await _noteRepository.SaveChangesAsync();

                var dbNotes = await _noteRepository.GetAllNotes(userId, noteStatus, categoryId);

                serviceResponse.Data = dbNotes;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error adding new note - {ex.Message}");
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetNoteDto>>> GetAllNotes(string userId, int noteStatus, int categoryId)
        {
            var serviceResponse = new ServiceResponse<List<GetNoteDto>>();

            try
            {
                serviceResponse.Data = await _noteRepository.GetAllNotes(userId, noteStatus, categoryId);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error getting notes - {ex.Message}");
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetNoteDto>>> DeleteNote(string userId, int noteId, int noteStatus, int categoryId)
        {
            var serviceResponse = new ServiceResponse<List<GetNoteDto>>();

            try
            {
                if (await _noteRepository.Delete(noteId))
                    await _noteRepository.SaveChangesAsync();

                serviceResponse.Data = await _noteRepository.GetAllNotes(userId, noteStatus, categoryId);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error deleting note {noteId} - {ex.Message}");
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetNoteDto>>> EditNote(string userId, int noteId, UpdateNoteDto updatedNote, int noteStatus, int categoryId)
        {
            var serviceResponse = new ServiceResponse<List<GetNoteDto>>();
            try
            {
                var dbNote = await _noteRepository.GetNoteWithCategories(userId, noteId);

                if (dbNote == null)
                {
                    throw new Exception($"Note Id '{noteId}' not found.");
                }

                _mapper.Map(updatedNote, dbNote);

                // Update Collections
                dbNote.Categories = await _categoryRepository.GetAll()
                    .Where(c => updatedNote.Categories.Select(unc => unc.Id).Contains(c.Id))
                    .ToListAsync();

                await _noteRepository.SaveChangesAsync();

                serviceResponse.Data = await _noteRepository.GetAllNotes(userId, noteStatus, categoryId);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error editing note {noteId} - {ex.Message}");
            }
            return serviceResponse;
        }
    }
}
