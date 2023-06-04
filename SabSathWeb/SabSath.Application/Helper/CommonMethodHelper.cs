using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using SabSath.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;

namespace SabSath.Application.Helper
{
    public class CommonMethodHelper
    {
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }



        public static List<DocumentAttachmentContext.CommonTableDocumentAttachment> UploadDocument(List<IFormFile> Files, IHostingEnvironment hostingEnvironment, string FolderPath = "/wwwroot/UploadImages/")
        {
            List<DocumentAttachmentContext.CommonTableDocumentAttachment> _ListData = new List<DocumentAttachmentContext.CommonTableDocumentAttachment>();

            string datestring = DateTime.Now.ToString("ddMMyyyyhhmmssmm") + Guid.NewGuid().ToString();
            if (Files != null && Files.Count > 0)
            {
                foreach (var file in Files)
                {
                    DocumentAttachmentContext.CommonTableDocumentAttachment data = new DocumentAttachmentContext.CommonTableDocumentAttachment();
                    if (file.FileName != "NoFile.txt")
                    {

                        //var FileSave = Path.Combine("", Directory.GetCurrentDirectory() + "/wwwroot/UploadImages/" + file.FileName);
                        var FileSave = Path.Combine("", hostingEnvironment.ContentRootPath + FolderPath + file.FileName);
                        var renamefilepath = Path.Combine("", Directory.GetCurrentDirectory() + FolderPath);
                        using (var stream = new FileStream(FileSave, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        System.IO.File.Copy(FileSave, renamefilepath + datestring + "_" + file.FileName);
                        System.IO.File.Delete(FileSave);

                    }

                    data.DocAttachmentPath = FolderPath.Replace("/wwwroot/","");//hostingEnvironment.ContentRootPath + FolderPath;
                    data.DocTypeId = null;
                    data.FileGeneratedName = datestring + "_" + file.FileName;
                    data.FileName = file.FileName;
                    data.RelationId = null;
                    _ListData.Add(data);

                }

                
            }

            return _ListData;

        }

        public static DataTable DynamicListToDataTable(List<dynamic> data)
        {
            var json = JsonConvert.SerializeObject(data);
            DataTable dataTable = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            return dataTable;
        }

        public static DataTable ConvertToDataTabble(dynamic obj)
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
