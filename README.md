# HealthCare Solutions

# Prerequisites

- Visual studio and Sql server
- Sql server name (localdb)\MSSQLLocalDB. If wants to change the server name then update in windows service web Config file and also change in web project web config file.
- Create Database for that Run Db Script
- Copy Batch Patient file into c:\ drive otherwise in the logs it will show file not found. we can change file location from database.


# Solution Includes 2 Projects

- Windows Service Project
- Web Project

Windows Service Project
   
   - For the debugging in windows service project. I have added windows form page (debug Form). It helps in the debugging also shows logs info on the view.
   - For to test this start the service project and when form will open press start.
  
   - Go to Service project and right click on Service1 file and select view code option.
   - In this file, I have initialized few service classes on the top..
   - OnStart funtion is the starting point. 
   
   -In this function I am handling the logs,interval and performing the read,insert,update cases
   
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
  
  - Inside OnStart function right click on patientService.ReadPatientInfo(configSettings) and go to definition or press F12
   
    - PatientService class has one method  ReadPatientInfo(ServiceConfiguration configSettings)
     In this function
    - We are reading information from text file default location c:\batch_Patient_12082020
    - Converting into data table ConvertHelper.ReadInfoFromtxtFile(configSettings.FolderLocation)
    - Converting into PatientTbl list ConvertHelper.ConvertDataTableToList<PatientTbl>(tbl)
    - Calling generic method for to insert or update data _dbService.InsertOrUpdate(dbName, tableName, "MRN", colunm, row)
    
       
           public void ReadPatientInfo(ServiceConfiguration configSettings)
           {
            //Read Patients info from text file then insert new Or update exsiting into PatientTble db table
            //Read file location from databse
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
                 //After data entry delete the file
                if (File.Exists(configSettings.FolderLocation))
                {
                    File.Delete(configSettings.FolderLocation);
                    Helper.WriteToFile("...File deleted successfully");
                }
                Helper.WriteToFile("...Data Entry Finished");

            }
            catch (Exception)
            {
                throw;
            }
        }
        
     - ConvertHelper class has 2 Methods
       
      - ConvertHelper.ReadInfoFromtxtFile(configSettings.FolderLocation);
       - Using this method to read info from database and parsing into data table. It is completely generic code. It can be reused for any other scenario.
            
      - ConvertDataTableToList
       - using this method to parse data table data into specific class. This function is also generic and can be reused for other scenario.
        
      - DBService calss has 3 Methods
       - InsertOrUpdate
        - using this method to write sql query and set cols and row for query paramters and before insert or update checking in the database if value exist or not.
        - It is a generic method it can be reused for other tables
             
       - CheckIfValueExist 
        - Check if value exist or not. if exist return true if not return false
             
       - GetConfiguration
        - Get configuration settings from database like file location, timer value, logs file location etc
         
       - SQLManager class has 2 function
        - Both are generic methods using it read or write into database.can be reused for other tables
           
 ## How to deploy service
 
    1- Build Project in Release Mode
    2- Run CMD as Administrator
    3- type cd then paste C:\Windows\Microsoft.NET\Framework64\v4.0.30319 and then enter
    4- type InstallUtil.exe
    5- then go to release folder and copy path and paste
    6- copy \PatientRegistrationService.exe and paste complete path will be look like this
    C:\Windows\Microsoft.NET\Framework64\v4.0.30319>InstallUtil.exe F:\Release\PatientRegistrationService.exe and press enter
    7- It will display a message successfully installed then search on windows for services and then press p look for your service right click and press start 
