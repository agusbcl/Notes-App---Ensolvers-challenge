using Ensolvers_Challenge.Frontend.Services.Interfaces;
using Ensolvers_Challenge.Shared.Dtos;
using Ensolvers_Challenge.Shared.Dtos.NoteDtos;
using Ensolvers_Challenge.Shared.Enums;
using System.Net.Http.Json;

namespace Ensolvers_Challenge.Frontend.Services
{
    public class NoteService : INoteService
    {
        private readonly HttpClient _http;
        private readonly ILogger<NoteService> _logger;
        private const string NoteUrl = "api/note";

        public NoteService(HttpClient http, ILogger<NoteService> logger)
        {
            _http = http;
            _logger = logger;
        }

        public async Task<List<GetNoteDto>> GetNotes(NoteStatus noteStatus, int categoryId)
        {
            var notes = new List<GetNoteDto>();
            try
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<List<GetNoteDto>>>($"{NoteUrl}?noteStatus={(int)noteStatus}&categoryId={categoryId}");
                if (result != null && result.Success && result.Data != null)
                {
                    notes = result.Data;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return notes;
        }

        public async Task<List<GetNoteDto>> AddNote(UpdateNoteDto newNote, NoteStatus noteStatus, int categoryId)
        {
            var notes = new List<GetNoteDto>();

            try
            {

                var response = await _http.PostAsJsonAsync($"{NoteUrl}?noteStatus={(int)noteStatus}&categoryId={categoryId}", newNote);
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<GetNoteDto>>>();

                if (result != null && result.Success && result.Data != null)
                    notes = result.Data;

                return notes;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return notes;
        }

        public async Task<List<GetNoteDto>> DeleteNote(int noteId, NoteStatus noteStatus, int categoryId)
        {
            var notes = new List<GetNoteDto>();

            try
            {
                var response = await _http.DeleteAsync($"{NoteUrl}?noteId={noteId}&noteStatus={(int)noteStatus}&categoryId={categoryId}");
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<GetNoteDto>>>();

                if (result != null && result.Success && result.Data != null)
                    notes = result.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return notes;
        }

        public async Task<List<GetNoteDto>> EditNote(UpdateNoteDto updatedNote, NoteStatus noteStatus, int categoryId)
        {
            var notes = new List<GetNoteDto>();

            try
            {
                var response = await _http.PutAsJsonAsync($"{NoteUrl}?noteId={updatedNote.Id}&noteStatus={(int)noteStatus}&categoryId={categoryId}", updatedNote);
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<GetNoteDto>>>();

                if (result != null && result.Success && result.Data != null)
                    notes = result.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return notes;
        }

        public async Task<List<GetNoteDto>> GetNotesByCategory(NoteStatus noteStatus, int categoryId)
        {
            var notes = new List<GetNoteDto>();
            try
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<List<GetNoteDto>>>($"{NoteUrl}/SearchNotesByCategory?noteStatus={(int)noteStatus}&categoryId={categoryId}");
                if (result != null && result.Success && result.Data != null)
                {
                    notes = result.Data;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return notes;
        }
    }
}
