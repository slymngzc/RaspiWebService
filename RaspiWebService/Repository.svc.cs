using RaspiWebService.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RaspiWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Repository : IRepository
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public bool AddValue(string key,string value)
        {
            RepositoryAppCode appCode = new RepositoryAppCode();
            return appCode.AddValue(key,value);
        }

        public KeyValueObject GetValue(string key)
        {
            RepositoryAppCode appCode = new RepositoryAppCode();
            return appCode.GetValue(key);
        }

        public List<KeyValueObject> GetAppSettings()
        {
            RepositoryAppCode appCode = new RepositoryAppCode();
            return appCode.GetAppSettings();
        }
    }
}
