using System;
using System.Collections.Generic;

namespace SocialClub.Api.Models
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
