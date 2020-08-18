using PatientRegistrationService.DataAccess;
using PatientRegistrationService.Helpers;
using PatientRegistrationService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRegistrationService.Services
{
    public class DBService
    {
        //Generic Method for insert and update info
        public bool InsertOrUpdate(string dbName, string tableName, string findInfoKey, List<string> colunmList, dynamic rowList)
        {
            try
            {
                SQLManager manager = new SQLManager();

                string paramInsertCol = "";
                string paramInsertValues = "";

                string paramUpdate = "";

                int count = 1;
                foreach (var col in colunmList)
                {
                    if (count == colunmList.Count)
                    {
                        paramInsertCol += $"{col}";
                        paramInsertValues += $"@{col}";

                        //Params Update
                        paramUpdate += $"{col}=@{col}";
                    }
                    else
                    {
                        paramInsertCol += $"{col},";
                        paramInsertValues += $"@{col},";

                        //Params Update
                        paramUpdate += $"{col}=@{col},";

                        count++;
                    }
                }

                Dictionary<string, string> parameters = new Dictionary<string, string>();

                foreach (var col in colunmList)
                {
                    var info = rowList.GetType().GetProperty(col).GetValue(rowList);
                    parameters.Add(col, info.ToString());
                }

                var param = parameters.Where(_ => _.Key == findInfoKey).FirstOrDefault();
                var resultExistOrNot = CheckIfValueExist(dbName, tableName, param);

                //If result is true then update the value
                if (resultExistOrNot)
                {
                    string updateQuery = String.Format($"UPDATE {tableName} SET {paramUpdate} WHERE {param.Key} = {param.Value}");

                    var result = manager.InsertOrUpdateQuery(manager.GetConnectionString(dbName), updateQuery, parameters);

                    if (result)
                        Helper.WriteToFile("...Updated Successfully");

                    return result;
                }
                //else Insert new value
                else
                {
                    string insertQuery = String.Format($"INSERT INTO {tableName} ({paramInsertCol}) VALUES({paramInsertValues})");
                    var result = manager.InsertOrUpdateQuery(manager.GetConnectionString(dbName), insertQuery, parameters);

                    if (result)
                        Helper.WriteToFile("...Inserted Successfully");

                    return result;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckIfValueExist(string dbName, string tableName, dynamic obj)
        {
            try
            {
                SQLManager manager = new SQLManager();
                string query = String.Format($"Select COUNT(*) from {tableName} where {obj.Key}= {obj.Value}");

                var count = manager.Find(manager.GetConnectionString(dbName), query).Rows.Count;
                return count == 0 ? false : true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public dynamic GetConfiguration(string dbName, string tableName)
        {
            try
            {
                SQLManager manager = new SQLManager();
                string query = String.Format($"Select * from {tableName}");

                var count = manager.Find(manager.GetConnectionString(dbName), query);
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
