using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Models
{
   public class DocumentAttachmentContext
    {
        public class CommonTableDocumentAttachment
        {
            
            public int? DocTypeId { get; set; }
            public string DocAttachmentPath { get; set; }
            public int? RelationId { get; set; }
           
            public string FileName { get; set; }
            public string FileGeneratedName { get; set; }
           
        }


        public class FormDataWithDocument
        {
            public string Data { get; set; }

            public List<IFormFile> AttachedFiles { get; set; }

        }

    }
}
