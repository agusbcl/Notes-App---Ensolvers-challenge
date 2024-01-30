using Ensolvers_Challenge.Shared.Dtos.CategoryDtos;
using System.ComponentModel.DataAnnotations;

namespace Ensolvers_Challenge.Shared.Dtos.NoteDtos
{
    public class UpdateNoteDto
    {
        public int Id { get; set; }
        [Required, MinLength(4), MaxLength(30)]
        public string Title { get; set; }
        [Required, MinLength(4), MaxLength(200)]
        public string Description { get; set; }
        public int Status { get; set; }
        public List<CategoryDto> Categories { get; set; } = new();
    }
}
