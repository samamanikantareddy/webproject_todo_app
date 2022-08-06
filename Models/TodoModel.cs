namespace todoproject.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int? Duration { get; set; }
        public DateTime Finishdate { get; set;}
    }
}
