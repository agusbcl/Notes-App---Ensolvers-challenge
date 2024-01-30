using Ensolvers_Challenge.Shared.Dtos.CategoryDtos;

namespace Ensolvers_Challenge.Shared.Dtos.NoteDtos
{
    public class GetNoteDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}
