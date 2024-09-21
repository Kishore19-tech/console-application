using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClgAdmission
{

    public enum Gender { Male, Female, Transgender }
    public class StudentDetails
    {
        private static int s_student_id = 3000;
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Math { get; set; }

        public string StudentId { get; set; }

        public StudentDetails(string studentName, string fatherName, DateTime dateOfBirth, Gender gender, int physics, int chemistry, int math)
        {


            StudentId = "SF" + ++s_student_id;

            StudentName = studentName;
            FatherName = fatherName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Physics = physics;
            Chemistry = chemistry;
            Math = math;
        }
    }
}