using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SummonersHQ
{
    public class BanList
    {
        [JsonProperty("groups")]
        public BanChampion[] groups { get; set; }
    }

    public class BanChampion
    {
        public string name { get; set; }
        public string image { get; set; }
        public string url { get; set; }
        public float[] values { get; set; }

        [JsonProperty("colors")]
        public Colors colors { get; set; }

        [JsonProperty("hover")]
        public Hover hover { get; set; }

        public string GetTotalBanPercentage
        {
            get
            {
                float value = 0;
                foreach (float f in values)
                {
                    value += f;
                }

                return (value.ToString("0.00") + " % of all rank games");
            }
        }
    }

    public class Colors
    {
        public string[] normal { get; set; }
        public string[] hover { get; set; }
    }

    public class Hover
    {
        public string[] text { get; set; }
        public float[] values { get; set; }
    }

}
