using PatientRegistrationService.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PatientRegistrationService.Models
{
    public static class ConvertType
    {
        public static dynamic ConvertValue(string value, Type property)
        {
            return Convert.ChangeType(value, property);
        }
    }
    public static class ConvertHelper
    {
        //Read data from text file and convert into cols and rows datatable
        public static DataTable ReadInfoFromtxtFile(string filePath)
        {
            DataTable tbl = new DataTable();

            //First check if file exist or not
            if (!File.Exists(filePath))
            {
                Helper.WriteToFile("...File is not exist");
                return tbl;
            }
            //Read data from text file
            string[] lines = System.IO.File.ReadAllLines(filePath);

            //Read Colunms
            foreach (string line in lines.Take(1))
            {
                var cols = lines[0].Split('|');
                for (int col = 0; col < cols.Length; col++)
                    if (cols[col] != "")
                        tbl.Columns.Add(new DataColumn(cols[col].ToString()));
            }

            //Read Rows
            foreach (string line in lines.Skip(1))
            {
                var cols = line.Split('|');

                DataRow dr = tbl.NewRow();
                for (int cIndex = 0; cIndex < cols.Length; cIndex++)
                {
                    if (cols[cIndex] != "")
                        dr[cIndex] = cols[cIndex];
                }

                tbl.Rows.Add(dr);
            }

            return tbl;
        }


        public static List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                var columnName = Regex.Replace(column.ColumnName.ToString(), @"\s", "");
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == columnName)
                    {
                        PropertyInfo propertyInfo = obj.GetType().GetProperty(pro.Name);

                        pro.SetValue(obj, ConvertType.ConvertValue(dr[column.ColumnName].ToString(), propertyInfo.PropertyType), null);
                    }
                    else
                        continue;
                }
            }
            return obj;
        }


    }


}
