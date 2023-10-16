using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Models;

[Serializable]
public class StoreKeeper : User
{
    public StoreKeeper(string userName, string password) : base(userName, password)
    {
    }
    public StoreKeeper() : base()
    {
    }

}