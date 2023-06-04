using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.ComponentModel;

namespace SabSath.Core.Models
{
    public class ListtoDataTableConverter
    {
        public DataTable ConvertToDataTabble(ApplicantInformation objApplicantInformation)
        {
            PropertyDescriptorCollection props =  TypeDescriptor.GetProperties(objApplicantInformation);
            DataTable dt = new DataTable();
            foreach (PropertyDescriptor p in props)
            {
                dt.Columns.Add(p.Name, p.PropertyType);
            }
            DataRow newRow = dt.NewRow();
            foreach (PropertyInfo property in objApplicantInformation.GetType().GetProperties())
            {
                newRow[property.Name] = objApplicantInformation.GetType().GetProperty(property.Name).GetValue(objApplicantInformation, null);
            }
            dt.Rows.Add(newRow);
            return dt;
        }
      

    }
}
