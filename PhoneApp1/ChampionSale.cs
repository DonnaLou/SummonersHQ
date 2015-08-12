using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SummonersHQ
{
    #region Wiki Json Parsing Model Classes
    public class WikiSales
    {
        [JsonProperty("query")]
        public Query query { get; set; }
    }

    public class Query
    {
        [JsonProperty("normalized")]
        public normalized[] normal { get; set; }

        [JsonProperty("pages")]
        public pages pages { get; set; }
    }

    public class normalized
    {
        [JsonProperty("from")]
        public string from { get; set; }
        [JsonProperty("to")]
        public string to { get; set; }
    }

    public class pages
    {
        [JsonProperty("67180")]
        public pageDetail pageDetails { get; set; } 
        
    }

    public class pageDetail
    {
        [JsonProperty("pageid")]
        public string pageid { get; set; }
        [JsonProperty("ns")]
        public string ns { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("revisions")]
        public revisions[] revisions { get; set; }
    }

    public class revisions
    {
        [JsonProperty("parsetree")]
        public string parsetree { get; set; }
        [JsonProperty("*")]
        public string other { get; set; }
    }

    #endregion

    public class ChampionSale
    {
        public string Name { get; set; }
        public string IpPrice { get; set; }
        public string RpPrice { get; set; }
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public ChampionSale() { }

        public bool hasData()
        {
            if (String.IsNullOrEmpty(Name) && String.IsNullOrEmpty(IpPrice) && String.IsNullOrEmpty(RpPrice))
            {
                return true;
            }

            return false;
        }
    }

    public class SkinSale
    {
        public string ChampName { get; set; }
        public string SkinName { get; set; }
        public string RpPrice { get; set; }
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public SkinSale() { }

        public bool hasData()
        {
            if (String.IsNullOrEmpty(ChampName) && String.IsNullOrEmpty(SkinName) && String.IsNullOrEmpty(RpPrice))
            {
                return true;
            }

            return false;
        }
    }

    public class SaleItem
    {
        public bool champSale;
        public bool skinSale;
        public string champName;
        public string skinName;
        public string ipPrice;
        public string rpPrice;
        public int champId;
    }

    public class SalesList
    {
        public string startdate;
        public string enddate;
        public List<ChampionSale> championsOnSale = new List<ChampionSale>();
        public List<SkinSale> skinsOnSale = new List<SkinSale>();

        public void Import(List<SaleItem> unsortedSales)
        {
            foreach (SaleItem item in unsortedSales)
            {
                if (item.skinSale)
                {
                    SkinSale skinItem = new SkinSale()
                    {
                        ChampName = item.champName,
                        SkinName = item.skinName + " " + item.champName,
                        RpPrice = GetReducedPrice(item.rpPrice),
                        Id = item.champId,
                        ImagePath = this.GetChampThumb(item.champName)
                    };
                    skinsOnSale.Add(skinItem);
                }
                else
                {
                    ChampionSale champItem = new ChampionSale()
                    {
                        Id = item.champId,
                        Name = item.champName,
                        RpPrice = GetReducedPrice(item.rpPrice),
                        IpPrice = item.ipPrice,
                        ImagePath = this.GetChampThumb(item.champName)
                    };
                    championsOnSale.Add(champItem);
                }
            }
        }

        private string GetReducedPrice(string price)
        {
            int priceInt = int.Parse(price);
            int reducedPrice = priceInt / 2;
            return reducedPrice.ToString();
        }

        private string GetChampThumb(string champName)
        {
            return "ChampionSquare120/" + champName + "_Square_0.png";
        }
    }
}
