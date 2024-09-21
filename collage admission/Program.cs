using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;

namespace ClgAdmission
{


    class Program
    {
        static List<StudentDetails> studentDetaillist = new List<StudentDetails>();
        static List<DepartmentDetails> departmentDetailslist = new List<DepartmentDetails>();
        static List<AdmissionDetails> admissionDetailslist = new List<AdmissionDetails>();
        static StudentDetails Details;

        public static void Main()
        {
            DefaultValues();
            Console.WriteLine("SF Collage of Engineering and Technology");
            Console.WriteLine();
            string choice = "yes";
            do
            {
                Console.WriteLine("1.Student Registration ");
                Console.WriteLine("2.Student Login");
                Console.WriteLine("3.Department wise seat availability");
                Console.WriteLine("4.Exit");
                Console.WriteLine("Enter the option ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        {
                            Registration();
                            break;
                        }
                    case "2":
                        {
                            Login();
                            break;
                        }
                    case "3":
                        {
                            SeatAvailablity();
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Exit Successfully ");
                            choice = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("You have entred an invalid key !");
                            break;
                        }
                }
            } while (choice == "yes");
        }
        public static void DefaultValues()
        {
            StudentDetails studentDetails = new StudentDetails("Ravichandran E", "Ettapparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            StudentDetails studentDetail1 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            studentDetaillist.Add(studentDetails);
            studentDetaillist.Add(studentDetail1);

            DepartmentDetails details = new DepartmentDetails("EEE", 29);
            DepartmentDetails details1 = new DepartmentDetails("CSC", 29);
            DepartmentDetails details2 = new DepartmentDetails("MECH", 30);
            DepartmentDetails details3 = new DepartmentDetails("ECE", 30);
            departmentDetailslist.Add(details);
            departmentDetailslist.Add(details1);
            departmentDetailslist.Add(details2);
            departmentDetailslist.Add(details3);

            AdmissionDetails details4 = new AdmissionDetails("SF3001", "DID101", new DateTime(2022, 05, 11), Admissionstatus.Admitted);
            AdmissionDetails details5 = new AdmissionDetails("SF3002", "DID102", new DateTime(2022, 05, 12), Admissionstatus.Admitted);
            admissionDetailslist.Add(details4);
            admissionDetailslist.Add(details5);
        }
        public static void Registration()
        {
            Console.WriteLine("You have choose the Registration");
            Console.WriteLine("");
            Console.WriteLine("Enter your name :");
            string StundentName = Console.ReadLine();
            Console.WriteLine("Enter your father name ");
            string FatherName = Console.ReadLine();
            Console.WriteLine("Enter your date of birth in the formate mm/dd/yyyy");
            DateTime DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter your gender ");
            Gender Gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.WriteLine("Enter your phy mark ");
            int Physics = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter you chemistry mark");
            int Chemistry = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your maths mark ");
            int Math = int.Parse(Console.ReadLine());

            StudentDetails details = new StudentDetails(StundentName, FatherName, DateOfBirth, Gender, Physics, Chemistry, Math);
            studentDetaillist.Add(details);
            Console.WriteLine("Thank you for Registration ");
            Console.WriteLine("Your student id is " + details.StudentId);
        }
        public static void Login()
        {
            Console.WriteLine("Enter your student id ");
            string studentid = Console.ReadLine();

            bool check = false;
            string choice1 = "yes";
            foreach (StudentDetails studentDetails in studentDetaillist)
            {
                Details = studentDetails;

                if (studentid == studentDetails.StudentId)
                {
                    check = true;
                    do
                    {
                        Console.WriteLine("Sub Menu");
                        Console.WriteLine("a.Check Eligibility");
                        Console.WriteLine("b.show details");
                        Console.WriteLine("c.Take Addmission");
                        Console.WriteLine("d.cancel Student");
                        Console.WriteLine("e.Show Student details");
                        Console.WriteLine("f.exit");
                        string option1 = Console.ReadLine();
                        switch (option1)
                        {
                            case "a":
                                {
                                    CheckEligibility();
                                    break;
                                }
                            case "b":
                                {
                                    ShowDetails();
                                    break;
                                }
                            case "c":
                                {
                                    TakeAdmission();
                                    break;
                                }
                            case "d":
                                {
                                    CancelAdmission();
                                    break;
                                }
                            case "e":
                                {
                                    ShowAdmissionDetails();
                                    break;
                                }

                            case "f":
                                {
                                    Console.WriteLine("Exit Successful");
                                    choice1 = "no";
                                    break;
                                }

                            default:
                                {
                                    Console.WriteLine("You have entred an invalid key !");
                                    break;
                                }
                        }

                    } while (choice1 == "yes");
                }
            }
            if (!check)
            {
                Console.WriteLine("You have entred an invalid Id !");


            }
        }
        public static void CheckEligibility()
        {

            double average = (Details.Chemistry + Details.Math + Details.Physics) / 3;
            if (average > 75)
            {
                Console.WriteLine("Student is Eligible");

            }
            else
            {
                Console.WriteLine("Student is not Eligible");
            }

        }
        public static void ShowDetails()
        {
            Console.WriteLine("DETIALS");
            Console.WriteLine("");
            Console.WriteLine("Name        : " + Details.StudentName);
            Console.WriteLine("Father Name : " + Details.FatherName);
            Console.WriteLine("DOB         : " + Details.DateOfBirth.ToString("dd/MM/yyyy"));
            Console.WriteLine("Gender      : " + Details.Gender);
            Console.WriteLine("Physics     : " + Details.Physics);
            Console.WriteLine("Chemistry   : " + Details.Chemistry);
            Console.WriteLine("Maths       : " + Details.Math);
        }
        public static void TakeAdmission()
        {
            foreach (DepartmentDetails departmentDetails in departmentDetailslist)
            {
                Console.WriteLine("DepartmentID : " + departmentDetails.DepartmentId);
                Console.WriteLine("Department Name : " + departmentDetails.DepartmentName);
                Console.WriteLine("No of seats : " + departmentDetails.NumberOfSeats);
                Console.WriteLine("");
            }
            Console.WriteLine("Choost the department using department id ");
            string departmentid = Console.ReadLine();
            bool check2 = false;
            bool check1 = false;

            foreach (DepartmentDetails departmentDetails1 in departmentDetailslist)
            {
                if (departmentid == departmentDetails1.DepartmentId)

                {
                    check1 = true;
                    if ((Details.Chemistry + Details.Physics + Details.Math / 3) > 75)
                    {
                        check2 = true;
                        if (departmentDetails1.NumberOfSeats > 0)

                        {
                            bool check4=false;
                            foreach (AdmissionDetails admissionDetails in admissionDetailslist)
                            {
                                
                                if (Details.StudentId == admissionDetails.StudentId && admissionDetails.Admissionstatus == Admissionstatus.Admitted)
                                {
                                    check4=true;
                                    Console.WriteLine("Your already admitted !");
                                    break;


                                }


                            }
                                if(check4==false)
                                {
                                    departmentDetails1.NumberOfSeats--;
                                    
                                    AdmissionDetails details9 = new AdmissionDetails(Details.StudentId, departmentid, DateTime.Now, Admissionstatus.Admitted);
                                    admissionDetailslist.Add(details9);
                                    Console.WriteLine("Admission Successful ! your admission id is " + details9.AdId);
                                    break;
                                }
                             
                        }
                        else
                        {
                            Console.WriteLine("Sorry the department was not available !");
                            break;
                        }
                    }
                    if (!check2)
                    {
                        Console.WriteLine("Student is not eligible for this admission");
                        break;

                    }
                }

            }

            if (!check1)
            {
                Console.WriteLine("invalid Department ID ! try again");
            }


        }
        public static void CancelAdmission()
        {
            bool check = false;
            foreach (AdmissionDetails admissionDetails in admissionDetailslist)
            {
                if (Details.StudentId == admissionDetails.StudentId && admissionDetails.Admissionstatus == Admissionstatus.Admitted)
                {
                    check = true;
                    admissionDetails.Admissionstatus = Admissionstatus.cancelled;
                    foreach (DepartmentDetails departmentDetails in departmentDetailslist)
                    {

                        departmentDetails.NumberOfSeats++;
                        Console.WriteLine("Admission cancel successfully !");
                        break;
                    }
                }
            }
            if (!check)

            {
                Console.WriteLine("You have not admitted so you will not cancel the admission");
            }
        }
        public static void ShowAdmissionDetails()
        {
            foreach (AdmissionDetails admissionDetails in admissionDetailslist)
            {
                if (Details.StudentId == admissionDetails.StudentId)
                {
                    Console.WriteLine("Admission details ");
                    Console.WriteLine("");
                    Console.WriteLine("Admission ID     : " + admissionDetails.AdId);
                    Console.WriteLine("Student ID       : " + admissionDetails.StudentId);
                    Console.WriteLine("DepartMent ID    : " + admissionDetails.DepartId);
                    Console.WriteLine("Admission Date   : " + admissionDetails.Admissiondate.ToString("dd/MM/yyyy"));
                    Console.WriteLine("Admission Status : " + admissionDetails.Admissionstatus);
                }
            }
        }
        public static void SeatAvailablity()
        {
            foreach (DepartmentDetails departmentDetails in departmentDetailslist)
            {
                Console.WriteLine("SEAT AVAILABLITY");
                Console.WriteLine("");
                Console.WriteLine("Department Name : " + departmentDetails.DepartmentName);
                Console.WriteLine("No of Seats     : " + departmentDetails.NumberOfSeats);
                Console.WriteLine("");

            }
        }

    }
}











