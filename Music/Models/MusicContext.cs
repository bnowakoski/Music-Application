using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using System.Collections;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Music.Models
{
    public class MusicContext : IdentityDbContext<AppUser>
    {

       
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public MusicContext() : base("name=MusicContext")
        {
        }

        public System.Data.Entity.DbSet<Music.Models.Album> Albums { get; set; }

        public System.Data.Entity.DbSet<Music.Models.Artist> Artists { get; set; }

        public System.Data.Entity.DbSet<Music.Models.Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<Music.Models.Playlist> Playlist { get; set; }

        public System.Data.Entity.DbSet<Music.Models.PlaylistAlbums> PlaylistAlbums { get; set; }




        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PlaylistAlbums>()
                .HasKey(p => new { p.AlbumID, p.PlaylistID });

            modelBuilder.Entity<PlaylistAlbums>()
                .HasOne(p => p.Album)
                .WithMany(p => p.Playlists)
                .HasForeignKey(p => p.AlbumID);

            modelBuilder.Entity<PlaylistAlbums>()
                .HasOne(p => p.Playlist)
                .WithMany(p => p.Albums)
                .HasForeignKey(p => p.PlaylistID);

        }
    }


   
}

