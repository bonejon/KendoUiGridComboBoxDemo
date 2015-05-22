using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikMvcApp1.Models
{
    public class StuffViewModel
    {
        public int StuffId
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public ThingViewModel Thing
        {
            get;
            set;
        }
    }
}