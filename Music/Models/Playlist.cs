using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Playlist
    {
        [Key]
        public int PlaylistID { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        public string OwnerID { get; set; }

        public List<PlaylistAlbums> Playlists { get; set; }
    }
}