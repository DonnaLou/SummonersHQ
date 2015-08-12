
namespace SummonersHQ
{
    public class Group
    {
        public string name {get; set;}
        public string city { get; set; }
        public string description { get; set; }
        public long memberCount { get; set; }
        public string uri { get; set; }
        public string country { get; set; }
        public string location
        {
            get { return this.city + ", " + this.country; }
        }
        public string logoUri { get; set; }

        public Group()
        {
        }

        public Group(string name, string city)
        {
            this.name = name;
            this.city = city;
        }

    }
}
