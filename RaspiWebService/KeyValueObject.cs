using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaspiWebService
{
    public class KeyValueObject
    {
        public KeyValueObject(string key,string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public KeyValueObject() { }

        public string Key { get; set; }

        public string Value { get; set; }       
    }
}