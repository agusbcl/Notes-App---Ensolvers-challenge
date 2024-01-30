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
    public partial class Notes : ComponentBase
    {
        [Inject] private INoteService NoteService { get; set; }
        [Inject] private IModalService ModalService { get; set; }
        [Inject] private ICategoryService CategoryService { get; set; }

        public List<GetNoteDto> NotesList { get; set; }
        public List<CategoryDto> CategoriesList { get; set; } = new();
        public NoteStatus StatusValue { get; set; }
        private bool IsStatusActive => StatusValue == NoteStatus.Active;
        private MudChip? _selectedCategory;
        private int SelectedCategoryValue => _selectedCategory != null ? (int)_selectedCategory.Value : 0;

        private async Task AddNote()
        {
            var updateNoteDto = new UpdateNoteDto();

            var parameters = new ModalParameters()
                .Add(nameof(UpdateNoteDto), updateNoteDto);

            var noteForm = ModalService.Show<EditNote>(ModalHelpers.FormatTitle(updateNoteDto.Id), parameters);
            var result = await noteForm.Result;
            if (result.Confirmed)
            {
                await SubmitAsync(updateNoteDto);
            }
        }

        private async Task SwitchStatus(NoteStatus newStatus)
        {
            StatusValue = newStatus;
            await RefreshNotes();
        }

        protected override async Task OnInitializedAsync()
        {
            CategoriesList = await CategoryService.GetAllCategories();
            await RefreshNotes();
        }

        private async Task RefreshNotes()
        {
            NotesList = await NoteService.GetNotes(StatusValue, SelectedCategoryValue);
        }

        private async Task SubmitAsync(UpdateNoteDto newNote)
        {
            NotesList = await NoteService.AddNote(newNote, StatusValue, SelectedCategoryValue);

        }

        private async Task FilterByCategory(MudChip? obj)
        {
            _selectedCategory = obj;
            NotesList = await NoteService.GetNotesByCategory(StatusValue, SelectedCategoryValue);
        }
    }
}
