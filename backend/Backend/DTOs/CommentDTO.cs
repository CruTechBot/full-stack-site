namespace Backend.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = "";
        public string Comment { get; set; } = "";
        public DateTime Created { get; set; }

    }
}
