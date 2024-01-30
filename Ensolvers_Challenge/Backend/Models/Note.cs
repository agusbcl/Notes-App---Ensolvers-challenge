namespace Ensolvers_Challenge.Backend.Models
{
    public class Note : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public int Status { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
