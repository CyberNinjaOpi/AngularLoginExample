using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ArtGallery.Web.DbAdapters;
using ArtGallery.DataModels;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ArtGallery.Web.Controllers
{

    [Authorize]
    public class ValuesController : ApiController
    {
        IArtGalleryAdapter _adapter = new ArtGalleryAdapter();

        // GET api/values
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            List<Artwork> artworks = _adapter.GetArtworks();
            foreach (var art in artworks)
            {
                art.ApplicationUser = new ApplicationUser();
            }
            return Ok(artworks);
        }

        // GET api/values/5
        [AllowAnonymous]
        public IHttpActionResult Get(int id)
        {
            Artwork artwork = _adapter.GetArtwork(id);
            artwork.ApplicationUser = new ApplicationUser();

            var user = _adapter.GetUser(artwork.ApplicationUserId);

            artwork.ApplicationUser.UserName = user.UserName;

            return Ok(artwork);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]Artwork artwork)
        {
            if (User.Identity.IsAuthenticated)
            {
                artwork.ApplicationUserId = User.Identity.GetUserId();
                artwork = _adapter.CreateArtwork(artwork);
                return Ok(artwork);
            }

            return Unauthorized();
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody]Artwork artwork)
        {
            if (artwork.ApplicationUserId == User.Identity.GetUserId())
            {
                artwork = _adapter.UpdateArtwork(artwork);
                artwork.ApplicationUser = new ApplicationUser();
                return Ok(artwork);
            }

            return Unauthorized();
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            Artwork artwork = _adapter.GetArtwork(id);
            if (artwork.ApplicationUserId == User.Identity.GetUserId())
            {
                artwork = _adapter.DeleteArtwork(id);
                return Ok();
            }

            return Unauthorized();
        }
    }
}
