using System;

namespace SummonersHQ
{
    public class Events
    {
        public string name { get; set; }

        public string eventDescription { get; set; }
        public string eventURL { get; set; }
        public string howToFindUs { get; set; }
        public Venue venue { get; set; }
        public int yesRsvp { get; set; }
        public int rsvpLimit { get; set; }
        public int maybeRsvp { get; set; }
        public DateTime eventStartTime { get; set; }
        public DateTime eventEndTime { get; set; }
        public long groupId { get; set; }

        public string where
        {
            get
            {
                if (this.venue == null)
                    return "Tap for more Info";
                else
                    return venue.CityStateZip();
            }
        }

        public string when
        {
            get
            {
                if(eventStartTime.ToString().Equals(eventEndTime.ToString()))
                {
                    return eventStartTime.ToString("M/d/yy hh:mm tt");
                }
                return eventStartTime.ToString("M/d/yy hh:mm tt") + " - " + eventEndTime.ToString("hh:mm");
            }
        }

        public Events()
        {
        }

        public Events(string name, string description, Venue v)
        {
            this.name = name;
            this.eventDescription = description;
            this.venue = v;
        }

        public override string ToString()
        {
            return this.name + " on "  + this.when;
        }
    }

    public class Venue
    {
        public string address;
        public string state;
        public string zip;
        public string city;
        public string name;

        public Venue() { }

        public string CityStateZip()
        {
            return city + ", " + state + " " + zip;
        }

        public override string ToString()
        {
            if (!String.IsNullOrEmpty(this.name))
            {
                if (!String.IsNullOrEmpty(this.address))
                {
                    return this.name + " - " + this.address + ", " + this.city + " " + this.state + ". " + this.zip; 
                }
                return this.name + " - " + this.city + " " + this.state + ". " + this.zip; 
            }

            return this.address + " ," + this.city + " " + this.state + ". " + this.zip; 
        }
    }
}
