using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    public class CaseInfo
    {
        public string CaseName { get; set; }

        public string Description { get; set; }

        public int CaseTypeId { get; set; }

        public long PartId { get; set; }

        public int Id { get; set; }

        public long CompanyId { get; set; }

        public string PartName { get; set; }

        public string CompanyName { get; set; }

        public DateTime CreateDate { get; set; }

        public string FilePath { get; set; }

        public string CaseTypeName { get; set; }
    }
}
