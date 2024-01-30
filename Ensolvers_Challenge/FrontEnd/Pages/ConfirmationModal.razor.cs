using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace Ensolvers_Challenge.Frontend.Pages
{
    public partial class ConfirmationModal
    {
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter] public string ConfirmationText { get; set; }

        private async Task ConfirmAction()
        {
            await BlazoredModal.CloseAsync(ModalResult.Ok());
        }

        private async Task Close()
        {
            await BlazoredModal.CloseAsync(ModalResult.Cancel());
        }
    }
}
