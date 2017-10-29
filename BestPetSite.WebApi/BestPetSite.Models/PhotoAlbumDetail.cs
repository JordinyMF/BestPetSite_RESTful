using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace BestPetSite.Models
{

    [Table("[PhotoAlbumDetails]")]
    public  class PhotoAlbumDetail
    {
        public int IdPhotoAlbum { get; set; }
        public int Item { get; set; }
        public BitArray Photo { get; set;}
}
}
