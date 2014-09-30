using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.DataModels
{
    public class Artwork
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Artwork()
        {

        }
        public Artwork(string applicationUserId, string imageUrl, string title, string description)
        {
            ApplicationUserId = applicationUserId;
            ImageUrl = imageUrl;
            Title = title;
            Description = description;
                
        }

        public void SetProperties(Artwork artwork)
        {
            ImageUrl = artwork.ImageUrl;
            Title = artwork.Title;
            Description = artwork.Description;
        }
    }
}
