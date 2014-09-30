using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtGallery.DataModels;
using ArtGallery.Data;

namespace ArtGallery.Web.DbAdapters
{
    public class ArtGalleryAdapter : IArtGalleryAdapter
    {

        public Artwork CreateArtwork(Artwork artwork)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                artwork = db.Artworks.Add(artwork);
                db.SaveChanges();
                
            }
            return artwork;

        }

        public List<Artwork> GetArtworks()
        {
            List<Artwork> artworks;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                artworks = db.Artworks.ToList();
            }
            return artworks;
        }

        public List<Artwork> GetArtworkForUser(string userId)
        {
            List<Artwork> artworks;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                artworks = db.Artworks.Where(x => x.ApplicationUserId == userId).ToList();
            }
            return artworks;
        }

        public Artwork GetArtwork(int id)
        {
            Artwork artwork;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                artwork = db.Artworks.Find(id);
            }
            return artwork;
        }

        public Artwork UpdateArtwork(Artwork artwork)
        {
            Artwork dbArtwork;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                dbArtwork = db.Artworks.Find(artwork.Id);
                dbArtwork.SetProperties(artwork);
                db.SaveChanges();
            }
            return dbArtwork;
        }

        public Artwork DeleteArtwork(int id)
        {
            Artwork artwork;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                artwork = db.Artworks.Find(id);
                db.Artworks.Remove(artwork);
                db.SaveChanges();
            }
            return artwork;
        }


        public ApplicationUser GetUser(string id)
        {
            ApplicationUser user;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                user = db.Users.Find(id);
            }
            return user;
        }
    }
}