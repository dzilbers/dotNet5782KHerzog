using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DalApi
{
    class DalConfig
    {
        internal static string DalType;
        internal static Dictionary<string, string> DalPackages;
        static DalConfig()
        {
            XElement dalConfig = XElement.Load(@"xml\dal-config.xml");
            DalType = dalConfig.Element("type").Value;
            DalPackages = (from pkg in dalConfig.Element("dal-packages").Elements()
                           select pkg
                          ).ToDictionary(p => "" + p.Name, p => p.Value);
        }
    }

    public class DalConfigException : Exception
    {
        public DalConfigException(string msg) : base(msg) { }
        public DalConfigException(string msg, Exception inr) : base(msg, inr) { }
    }

}
