using System;
using System.Collections.Generic;
using System.Linq;
using DalApi;
using DO;

namespace Dal
{
    sealed class DalXml : IDal
    {
        public static DalXml Instance { get; } = new DalXml();
        private DalXml() { }
    }
}
