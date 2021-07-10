using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Models
{
   
    //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class OBD_Root
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
