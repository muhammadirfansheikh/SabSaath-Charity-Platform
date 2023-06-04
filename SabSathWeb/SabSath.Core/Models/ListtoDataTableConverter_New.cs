using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Reflection;
using SabSath.Core.Models;

namespace SabSath.Core.Model
{
   public class ListtoDataTableConverter_New
    {
        public DataTable ConvertToDataTabble(PetDetail obj)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            DataTable dt = new DataTable();
            foreach (PropertyDescriptor p in props)
            {
                dt.Columns.Add(p.Name, p.PropertyType);
            }
            DataRow newRow = dt.NewRow();
            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                newRow[property.Name] = obj.GetType().GetProperty(property.Name).GetValue(obj, null);
            }
            dt.Rows.Add(newRow);
            return dt;
        }

    }
}
