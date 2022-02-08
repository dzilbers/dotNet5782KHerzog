using System;
using System.Reflection;
//using Dal;

namespace DalApi
{
    public static class DalFactory
    {
        public static IDal GetDal()
        {
            string dalType = DalConfig.DalType;
            string dalClass, dalPkg, dalNamespace = "Dal";
            dalClass = dalPkg = DalConfig.DalPackages[dalType];
            if (dalPkg == null) throw new DalConfigException("bad config");

            try { Assembly.Load(dalPkg); }
            catch (Exception e) { throw new DalConfigException("bad assembly", e); }
            Type type = Type.GetType($"{dalNamespace}.{dalClass}, {dalPkg}");
            if (type == null) throw new DalConfigException("bad class");
            IDal dal = (IDal)type.GetProperty("Instance",
                      BindingFlags.Public | BindingFlags.Static).GetValue(null);
            if (dal == null) throw new DalConfigException("bad singleton");
            return dal;

        }

        //public static IDal GetDal() => type switch
        //{
        //    "list" => DalObject.Instance,
        //    "xml" => DalXml.Instance,
        //    //"oracle" => DalOracle.Instance,
        //    _ => throw new ArgumentException("Wrong Dal type")
        //};

        //public static IDal GetDal(string type)
        //{
        //    switch (type)
        //    {
        //        case "list":
        //            return DalObject.Instance;
        //        case "xml":
        //            return DalXml.Instance;
        //        //case "oracle":
        //        //    return DalOracle.Instance;
        //        default:
        //            throw new ArgumentException("Wrong Dal type");
        //    }
        //}
    }
}
