using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAGAZA.Models
{
    public class Magaza
    {
        public int Id { get; set; }
        public string urungorsel { get; set; }
        public string urunturu { get; set; }
        public string urunad { get; set; }
        public string urunaciklama { get; set; }
        public int fiyat { get; set; }


    }
}