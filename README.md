# HealthCare Solutions

# Solution Include 2 Projects

<ul>
  <li>Windows Service Project</li>
  <li>Web Project</li>
<ul>
  
  
 <ol>
  <li>
    Windows Service Project
  </li>
   <p>
     Right click on Service1 file and select view code option.<br>
     
     Few cofiguration and services initialization on the top.
     
     Starting point is OnStart Funtion
     
       protected override void OnStart(string[] args)
       {
          try
          {
              //
              Helper.WriteToFile("Starting service ...");
              tmrExecutor.Elapsed += new ElapsedEventHandler(OnElapsedTime); // adding Event
              tmrExecutor.Interval = configSettings.Timer; // Set your time here 
              tmrExecutor.Enabled = true;
              tmrExecutor.Start()
              //Read Patient Info from text file and then insert or update the value
              patientService.ReadPatientInfo(configSettings)
          }
          catch (Exception ex)
          {
              //Helper file for the logs
              Helper.WriteToFile(ExceptionManager.GetExceptionStackTrace(ex) + "\nStack Trace\n" + ex.StackTrace);
          }
        }
     
     
   </p>
 </ol>
  




