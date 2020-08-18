# HealthCare Solutions

# Solution Include 2 Projects

<ul>
  <li>Windows Service Project</li>
  <li>Web Project</li>
<ul>
  
  
 <ol>
  <li>
    Windows Service Project
    
   Right click on Service1 file and select view code option.<br>
   Few cofiguration and services initialization on the top.<br>
   Starting point is OnStart Funtion. In this function handling the logs,interval and performing the read,insert,update cases <br>
  
  </li>
  
   <p>
       protected override void OnStart(string[] args)<br>
       {<br>
          try<br>
          {<br>
              //<br>
              Helper.WriteToFile("Starting service ...");<br>
              tmrExecutor.Elapsed += new ElapsedEventHandler(OnElapsedTime); // adding Event<br>
              tmrExecutor.Interval = configSettings.Timer; // Reading timer info from database<br><br>
              tmrExecutor.Enabled = true;<br>
              tmrExecutor.Start()<br>
              //Read Patient Info from text file and then insert or update the value<br>
              patientService.ReadPatientInfo(configSettings)<br>
          }<br>
          catch (Exception ex)<br>
          {<br>
              //Helper file manage the logs<br>
              Helper.WriteToFile(ExceptionManager.GetExceptionStackTrace(ex) + "\nStack Trace\n" + ex.StackTrace);<br>
          }<br>
        }<br>
   </p>
 
 
 </ol>
 <ol>
    <li>
    Right click on patientService.ReadPatientInfo(configSettings) and go to defination or press F12
   </li>
    In this function, 
    1- We are reading information from text file default location c:\batch_Patient_12082020
    2- Converting into data table
    3- Converting into PatientTbl list
    4- Calling generic method for to insert or update data
 
   <p>
       //Read Patients info from text file then insert new Or update exsiting into PatientTble db table
        public void ReadPatientInfo(ServiceConfiguration configSettings)
        {
            try
            {
                //Read data from text file and insert into data table
                var tbl = ConvertHelper.ReadInfoFromtxtFile(configSettings.FolderLocation);

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
    </p>
  </ol>
  




