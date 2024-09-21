using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClgAdmission
{
    public class DepartmentDetails
    {
        private static int s_department_id = 100;

        public string DepartmentName { get; set; }
        public int NumberOfSeats { get; set; }
        public string DepartmentId { get; set; }

        public DepartmentDetails(string departmentName, int numberOfSeats)
        {
            DepartmentId = "DID" + ++s_department_id;
            DepartmentName = departmentName;
            NumberOfSeats = numberOfSeats;
        }


    }
}