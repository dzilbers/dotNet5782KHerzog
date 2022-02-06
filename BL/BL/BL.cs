using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;
using DalApi;

namespace BL
{
    sealed class BL : IBl
    {
        IDal dal;
        public static BL Instance { get; } = new BL();
        private BL()
        {
            //dal = Dal.DalObject.Instance;
            //dal = Dal.DalXml.Instance;
            dal = DalFactory.GetDal();
        }
    }
}
