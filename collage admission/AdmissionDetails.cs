using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClgAdmission
{
    public enum Admissionstatus{Selected,cancelled,Admitted}
    
    public class AdmissionDetails
    {
        private static int admissionid=1000;
        public  string StudentId {get; set;}
         public  string DepartId {get; set;}

         public DateTime Admissiondate {get;set;}
         public Admissionstatus Admissionstatus {get; set;}
         public string AdId {get ; set ;}


         public AdmissionDetails(string studentId,string departId,DateTime admissiondate , Admissionstatus admissionstatus)
         {
            AdId = "AID"+ ++admissionid;
            StudentId=studentId;
            DepartId=departId;
            Admissiondate=admissiondate;
            Admissionstatus=admissionstatus;
         }
            

    }
}