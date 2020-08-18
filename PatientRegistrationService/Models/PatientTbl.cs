using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRegistrationService.Models
{

    public class PatientTbl
    {
        #region PatientTbl Properties

        public Int32 PatientID { get; set; }

        public String Patient { get; set; }

        public Int64 MRN { get; set; }

        public Int64 CSN { get; set; }

        public String Gender { get; set; }

        public String HomePhone { get; set; }

        public String SSN { get; set; }

        public String PassportNo { get; set; }

        public String LocationCode { get; set; }

        public Int64 LocationID { get; set; }

        public String DOB { get; set; }

        public String UpdateDateTime { get; set; }

        #endregion PatientTbl Properties
    }




}
