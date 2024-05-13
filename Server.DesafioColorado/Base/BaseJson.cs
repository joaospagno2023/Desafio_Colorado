using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Server.Entities.DesafioColorado.Base
{
    public class BaseJson
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
