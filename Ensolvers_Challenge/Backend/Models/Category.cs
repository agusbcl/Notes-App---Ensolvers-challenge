namespace Ensolvers_Challenge.Backend.Models
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public IEnumerable<Note> Notes { get; set; }
    }
}
