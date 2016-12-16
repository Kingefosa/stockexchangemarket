using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeMarket.Model.Interfaces
{
    public interface IAuthorizable
    {
        bool DoesUserHaveAccess(User argUser);
    }
}
