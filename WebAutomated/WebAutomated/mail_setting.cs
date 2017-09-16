using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomated
{
    public class mail_setting
    {




        public mail_setting(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jUser = jObject["mail_settings"];
            email_add = (string)jUser["email_add"];
            email_password = (string)jUser["email_password"];
            email_receipents = (string)jUser["email_receipents"];
            email_subject = (string)jUser["email_subject"];
            email_body = (string)jUser["email_body"];
           // players = jUser["players"].ToArray();
        }

        public string email_add { get; set; }
        public string email_password { get; set; }
        public string email_receipents { get; set; }
        public string email_subject { get; set; }
        public string email_body { get; set; }

       
        
    }
}
