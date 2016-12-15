using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music.ViewModel
{
    
    public class AddAlbumPlaylistViewModel
    {
        public int playlistID { get; set; }
        public string ownerID { get; set; }
        public string playlistName { get; set; }
        public string albumID { get; set; }
        
    } 
        
}