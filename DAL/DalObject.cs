using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DO;

namespace Dal
{
    sealed class DalObject : IDal
    {
        public static DalObject Instance { get; } = new DalObject();
        private DalObject() => DataSource.Initialize();
    }
}
