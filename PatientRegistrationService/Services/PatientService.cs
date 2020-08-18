using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PatientRegistrationService.Helpers;
using PatientRegistrationService.Models;
using PatientRegistrationService.Services;

namespace PatientRegistrationService.Services
{
    public class PatientService
    {
        string dbName = ConfigurationManager.AppSettings["DatabaseName"].ToString();
        string tableName = ConfigurationManager.AppSettings["TableName"].ToString();

        private List<PatientTbl> patientList = new List<PatientTbl>();
        //Read Patients info from text file then insert new Or update exsiting into PatientTble db table
        public void ReadPatientInfo(ServiceConfiguration configSettings)
        {
            try
            {
                //Read data from text file and insert into data table
                var tbl = ConvertHelper.ConvertToDataTable(configSettings.FolderLocation);

                if (tbl.Rows.Count == 0)
                    return;

                DBService _dbService = new DBService();

                List<string> colunm = new List<string>();
                foreach (var col in tbl.Columns)
                {
                    var removeSpaceBetweenWords = Regex.Replace(col.ToString(), @"\s", "");
                    colunm.Add(removeSpaceBetweenWords);
                }

                //Convert data table Patient Info into PatientTbl Class list
                patientList = ConvertHelper.ConvertDataTableToList<PatientTbl>(tbl);

                Helper.WriteToFile("...Data Entry Started");
                foreach (var row in patientList)
                {
                    //Inert or Update info into Database
                    //I have consider MRN as unique value for to check info in database
                    _dbService.InsertOrUpdate(dbName, tableName, "MRN", colunm, row);
                }
                Helper.WriteToFile("...Data Entry Finished");

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
