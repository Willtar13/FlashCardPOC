using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FlashCardPOC.Models
{
    public class FlashCard
    {

        public int ID { get; set; }
        public string category { get; set; }
        public string style { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string subCategory1 { get; set; }
        public string subCategory2 { get; set; }
        public string subCategory3 { get; set; }
        public int numAttempts { get; set; }
        public int numRight { get; set; }
        public int numWrong { get; set; }
        public decimal percentageRight { get; set; }

    }
}