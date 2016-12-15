using System.ComponentModel.DataAnnotations;
using System;
namespace Music.Models
{

    // GET: PlaylistAlbums
    public class PlaylistAlbums
        {
            public int AlbumID { get; set; }
            public Album Album { get; set; }
            [Key]
            public int PlaylistID { get; set; }
            public Playlist Playlist { get; set; }
        }

   
    }


    
    
