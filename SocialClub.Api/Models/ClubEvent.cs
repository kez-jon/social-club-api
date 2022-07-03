using System;
using System.Collections.Generic;

namespace SocialClub.Api.Models
{
    public partial class ClubEvent
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Venue { get; set; }
        public string HostName { get; set; }
        public string EventStatus { get; set; }
        public string EventDescription { get; set; }
    }
}
