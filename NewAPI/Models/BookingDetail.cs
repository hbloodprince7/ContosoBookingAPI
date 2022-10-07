using System;
using System.Collections.Generic;

namespace NewAPI.Models
{
    public partial class BookingDetail
    {
        public int BookingId { get; set; }
        public int? BookingEventId { get; set; }
        public string? BookingEvent { get; set; }
        public int? BookingUserId { get; set; }
        public string? BookingTicketCatagory { get; set; }
        public int BookingNumberofTickets { get; set; }

        public virtual EventsDetail? BookingEventNavigation { get; set; }
    }
}
