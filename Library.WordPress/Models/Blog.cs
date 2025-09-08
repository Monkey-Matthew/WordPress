namespace Library.WordPress.Models
{
    public class Blog
    {
        public string? Title { get; set; }
        public string? Content { get; set; }

        public int Id {  get; set; } //Guid data type?

        public override string ToString()
        {
            return $"{Id}. {Title} - {Content}";

        }


    }
}