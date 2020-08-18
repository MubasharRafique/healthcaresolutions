using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRegistrationService.Models
{
    public class ServiceConfiguration
    {
        #region ServiceConfiguration Properties

        public Int32 ID { get; set; }

        public String FolderLocation { get; set; }

        public Int32 Timer { get; set; }

        public String DatabaseName { get; set; }

        public String LogsFilePath { get; set; }

        #endregion ServiceConfiguration Properties
    }
}
