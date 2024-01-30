using Blazored.Modal;
using Blazored.Modal.Services;
using Ensolvers_Challenge.Shared.Dtos.NoteDtos;
using Microsoft.AspNetCore.Components;

namespace Ensolvers_Challenge.Frontend.Pages
{
    public partial class EditNote
    {
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public UpdateNoteDto UpdateNoteDto { get; set; }

        private async Task SubmitForm()
        {
            await BlazoredModal.CloseAsync(ModalResult.Ok());
        }

        private async Task Close()
        {
            await BlazoredModal.CloseAsync(ModalResult.Cancel());
        }
    }
}
