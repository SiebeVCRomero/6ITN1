using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog6ITN.Models
{
    public class Nieuws
    {
        [Key()]
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Inhoud { get; set; }
        public DateTime PublicatieDatum { get; set; }
        public string Auteur { get; set; }
    }
}