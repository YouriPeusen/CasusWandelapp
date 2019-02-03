using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using static CasusWandelapp.BU.MapPageCS;

namespace CasusWandelapp.BU
{
    class CustomPin : Pin
    {
        public string Url { get; set; }
    }
}
