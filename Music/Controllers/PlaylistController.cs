using Microsoft.AspNet.Identity;
using Music.Models;
using Music.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Music.Controllers
{
    public class PlaylistController : Controller
    {
        private MusicContext db = new MusicContext();

        private readonly Microsoft.AspNet.Identity.UserManager<AppUser> userManager;

        public PlaylistController()
            : this(Startup.UserManagerFactory.Invoke())
        {

        }

        public PlaylistController(Microsoft.AspNet.Identity.UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        // GET: Playlist
        public ActionResult Index()
        {
            String userId = User.Identity.GetUserId();
            AppUser user = userManager.FindById(userId);
            ViewBag.Date = user.DateJoined;
            var playlists = db.Playlist.Where(a => a.OwnerID == userId);
            return View(playlists);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Playlist playlist)
        {
            String userId = User.Identity.GetUserId();
            playlist.OwnerID = userId;
            db.Playlist.Add(playlist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int? id)
        {
            Playlist playlist = db.Playlist.Find(id);
            db.Playlist.Remove(playlist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Playlist playlist = (Playlist)db.Playlist.Where(a => a.PlaylistID == id).FirstOrDefault();





            return View("Edit", playlist);
        }

        [HttpPost]
        public ActionResult Edit(Playlist playlist)
        {
            db.Entry(playlist).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add(int? id)
        {
            AddAlbumPlaylistViewModel addPlaylist = new AddAlbumPlaylistViewModel();
            Playlist playlist = (Playlist)db.Playlist.Where(a => a.PlaylistID == id).FirstOrDefault();
            addPlaylist.ownerID = playlist.OwnerID;
            addPlaylist.playlistID = playlist.PlaylistID;
            addPlaylist.playlistName = playlist.Name;





            List<Album> albumList = db.Albums.ToList();

            ViewBag.albumList = new SelectList(db.Albums, "AlbumID", "Title");
            //ViewBag.albumList = albumList.Select((album) => new SelectListItem {Text = album.Title, Value = album.AlbumID.ToString() });


            return View("Add", addPlaylist);
        }

        [HttpPost]
        public ActionResult Add(AddAlbumPlaylistViewModel addPlaylist)
        {
            Playlist playlist = (Playlist)db.Playlist.Where(a => a.PlaylistID == addPlaylist.playlistID).FirstOrDefault();
            Album album = (Album)db.Albums.Where(a => a.AlbumID.ToString() == addPlaylist.albumID).FirstOrDefault();

            playlist.AlbumIDs.Add(album.AlbumID);


           

            db.Entry(playlist).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");



        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                Playlist playlist = db.Playlist.Where(a => a.PlaylistID == id).FirstOrDefault();

                if (playlist == null)
                {
                    return HttpNotFound();
                }
                return View("Details", playlist);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}