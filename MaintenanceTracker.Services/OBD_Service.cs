using MaintenanceTracker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Services
{
    public class OBD_Service
    {
        public List<OBD_Root> LoadJson()
        {
            using (StreamReader r = new StreamReader("~/MaintenanceTrackerMVC/OBD_Codes.json"))
            {
                string json = r.ReadToEnd();
                List<OBD_Root> items = JsonConvert.DeserializeObject<List<OBD_Root>>(json);
                return items;
            }
        }

    }
}
