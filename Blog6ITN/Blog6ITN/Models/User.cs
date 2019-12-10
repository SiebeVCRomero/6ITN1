using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog6ITN.Models
{
    public class User
    {
        [Key()]
        public int Id { get; set; }


        /// <summary>
        /// Voornaam van de persoon
        /// </summary>
        public string Voornaam { get; set; }

        /// <summary>
        /// Familienaam van de persoon
        /// </summary>
        public string Familienaam { get; set; }

        /// <summary>
        /// email van de persoon lln of lkr
        /// </summary>

        [EmailAddress()]
        public string Email { get; set; }

        public string Rol { get; set; }
    }
}