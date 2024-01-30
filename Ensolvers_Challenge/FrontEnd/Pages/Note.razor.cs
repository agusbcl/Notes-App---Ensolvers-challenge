using Blazored.Modal;
using Blazored.Modal.Services;
using Ensolvers_Challenge.Frontend.Services.Interfaces;
using Ensolvers_Challenge.Shared.Dtos.CategoryDtos;
using Ensolvers_Challenge.Shared.Dtos.NoteDtos;
using Ensolvers_Challenge.Shared.Enums;
using Ensolvers_Challenge.Shared.Helpers;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Ensolvers_Challenge.Frontend.Pages
{
    public partial class Note
    {
        [Inject] private INoteService NoteService { get; set; }
        [Inject] private IModalService ModalService { get; set; }

        [Parameter] public GetNoteDto NoteItem { get; set; }
        [Parameter] public List<CategoryDto> CategoriesList { get; set; }
        [Parameter] public List<GetNoteDto> NotesList { get; set; }
        [Parameter] public EventCallback<List<GetNoteDto>> NotesListChanged { get; set; }
        [Parameter] public NoteStatus NoteStatus { get; set; }
        [Parameter] public int CategoryId { get; set; }

        private bool _isOpen;

        private async Task DeleteNoteAsync()
        {
            var parameters = new ModalParameters()
                .Add("ConfirmationText", "Do you confirm delete action?");

            var confirmModal = ModalService.Show<ConfirmationModal>("Alert", parameters);
            var result = await confirmModal.Result;
            if (result.Confirmed)
            {
                NotesList = await NoteService.DeleteNote(NoteItem.Id, NoteStatus, CategoryId);

                await NotesListChanged.InvokeAsync(NotesList);
            }
        }

        private async Task EditNoteAsync()
        {
            var updatedNote = new UpdateNoteDto()
            {
                Id = NoteItem.Id,
                Description = NoteItem.Description,
                Title = NoteItem.Title,
                Status = NoteItem.Status,
                Categories = NoteItem.Categories
            };

            var parameters = new ModalParameters()
                .Add(nameof(UpdateNoteDto), updatedNote);

            var noteForm = ModalService.Show<EditNote>(ModalHelpers.FormatTitle(updatedNote.Id), parameters);

            var result = await noteForm.Result;
            if (result.Confirmed)
            {
                if (HasChanges(NoteItem, updatedNote))
                {
                    await EditAsync(updatedNote);
                }
            }
        }

        private bool HasChanges(GetNoteDto noteItem, UpdateNoteDto updatedNote)
        {
            if (noteItem.Title.Equals(updatedNote.Title, StringComparison.Ordinal) &&
                noteItem.Description.Equals(updatedNote.Description, StringComparison.Ordinal))
            {
                return false;
            }
            return true;
        }

        public async Task ChangeNoteStatus(NoteStatus status)
        {
            var updatedNote = new UpdateNoteDto()
            {
                Id = NoteItem.Id,
                Description = NoteItem.Description,
                Title = NoteItem.Title,
                Status = (int)status,
                Categories = NoteItem.Categories
            };

            NotesList = await NoteService.EditNote(updatedNote, NoteStatus, CategoryId);
            await NotesListChanged.InvokeAsync(NotesList);
        }

        private async Task EditAsync(UpdateNoteDto updatedNote)
        {
            NotesList = await NoteService.EditNote(updatedNote, NoteStatus, CategoryId);
            await NotesListChanged.InvokeAsync(NotesList);
        }

        private void ToggleCategory()
        {
            _isOpen = !_isOpen;
        }

        public async Task RemoveCategory(int categoryId)
        {
            NoteItem.Categories.RemoveAll(c => c.Id == categoryId);

            var updatedNote = new UpdateNoteDto()
            {
                Id = NoteItem.Id,
                Description = NoteItem.Description,
                Title = NoteItem.Title,
                Status = NoteItem.Status,
                Categories = NoteItem.Categories
            };

            await EditAsync(updatedNote);
        }

        public async Task AddCategory(CategoryDto newCategory)
        {
            NoteItem.Categories.Add(newCategory);
            ToggleCategory();

            var updatedNote = new UpdateNoteDto()
            {
                Id = NoteItem.Id,
                Description = NoteItem.Description,
                Title = NoteItem.Title,
                Status = NoteItem.Status,
                Categories = NoteItem.Categories
            };

            await EditAsync(updatedNote);
        }
    }
}
