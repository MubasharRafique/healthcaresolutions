# HealthCare Solutions

# Solution Include 2 Projects


- Windows Service Project
- Web Project


require Windows Service Project
  
   - Right click on Service1 file and select view code option.
   - Few cofiguration and services initialization on the top.
   - OnStart funtion is the starting point. 
   
   -In this function handling the logs,interval and performing the read,insert,update cases
   
    protected override void OnStart(string[] args)
    {
          try
          {
              Helper.WriteToFile("Starting service ...");
              tmrExecutor.Elapsed += new ElapsedEventHandler(OnElapsedTime);
              tmrExecutor.Interval = configSettings.Timer; // Reading timer info from database
              tmrExecutor.Enabled = true;
              tmrExecutor.Start()
              //Read Patient Info from text file and then insert or update the value
              patientService.ReadPatientInfo(configSettings)
          }
          catch (Exception ex)
          {
              //Helper file manage the logs
              Helper.WriteToFile(ExceptionManager.GetExceptionStackTrace(ex) + "\nStack Trace\n" + ex.StackTrace);
          }
    }
  
   - Right click on patientService.ReadPatientInfo(configSettings) and go to defination or press F12
   
  
    In this function, 
    1- We are reading information from text file default location c:\batch_Patient_12082020
    2- Converting into data table
    3- Converting into PatientTbl list
    4- Calling generic method for to insert or update data
        //Read Patients info from text file then insert new Or update exsiting into PatientTble db table
        public void ReadPatientInfo(ServiceConfiguration configSettings)
        {
            try
            {
                //Read data from text file and insert into data table
                var tbl = ConvertHelper.ReadInfoFromtxtFile(configSettings.FolderLocation);

                if (tbl.Rows.Count == 0)
                    return;<br>

                DBService _dbService = new DBService();

                List<string> colunm = new List<string>();
                foreach (var col in tbl.Columns)
                {
                    var removeSpaceBetweenWords = Regex.Replace(col.ToString(), @"\s", "");
                    colunm.Add(removeSpaceBetweenWords);
                }

                Convert data table Patient Info into PatientTbl Class list
                patientList = ConvertHelper.ConvertDataTableToList<PatientTbl>(tbl);

                Helper.WriteToFile("...Data Entry Started");<br>
                foreach (var row in patientList)<br>
                {
                    //Inert or Update info into Database<br>
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
        
       
