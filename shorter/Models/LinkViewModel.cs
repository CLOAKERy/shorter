using System.ComponentModel.DataAnnotations;

namespace shorter.Models
{
    public class LinkViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a long URL.")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string LongUrl { get; set; }

        public string ShortenedUrl { get; set; }

        [Required]
        [Display(Name = "Creation Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Click Count")]
        public int ClickCount { get; set; } = 0;
    }

    public class LinkViewModels
    {
        public string BaseUrl;
        public IEnumerable<LinkViewModel> linkViewModels;
    }
}
