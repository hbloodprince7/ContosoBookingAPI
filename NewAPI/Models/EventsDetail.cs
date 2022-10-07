using System;
using System.Collections.Generic;

namespace NewAPI.Models
{
    public partial class EventsDetail
    {
        public EventsDetail()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; } = null!;
        public string EventType { get; set; } = null!;
        public string? EventLocation { get; set; }
        public string EventStartdate { get; set; } = null!;
        public string EventEnddate { get; set; } = null!;

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
