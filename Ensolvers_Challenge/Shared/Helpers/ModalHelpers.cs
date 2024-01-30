namespace Ensolvers_Challenge.Shared.Helpers
{
    public static class ModalHelpers
    {
        public static string FormatTitle(int id)
        {
            var isNew = id == 0;

            return isNew ? "Create Note" : "Edit Note";
        }

    }
}
