using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeMarket.Controller
{
    public class Utility
    {
        public static object IsNull(object argObject, object argChangeValue)
        {
            return argObject == null? argChangeValue : argObject;
        }
    }
}
