namespace DAL.Entities
{
    public class Link
    {
        public int Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ClickCount { get; set; }
    }
}
