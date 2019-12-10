using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog6ITN.Models
{
    public class Gip
    {
        [Key()]
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Intro { get; set; }
        public DateTime LaatseAanpassing { get; set; }
    }
}