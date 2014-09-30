using ArtGallery.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Web.DbAdapters
{
    public interface IArtGalleryAdapter
    {
        // Create artwork
        Artwork CreateArtwork(Artwork artwork);

        // Get all artwork
        List<Artwork> GetArtworks();

        // Get all artwork for user
        List<Artwork> GetArtworkForUser(string userId);

        // Get artwork
        Artwork GetArtwork(int id);

        // Update artwork
        Artwork UpdateArtwork(Artwork artwork);

        // Delete artwork
        Artwork DeleteArtwork(int id);

        // Get user
        ApplicationUser GetUser(string id);

    }
}
