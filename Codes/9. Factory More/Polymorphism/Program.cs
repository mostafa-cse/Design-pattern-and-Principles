using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    class Program
    {
        public sealed class University
        {
            private static University UniversityInstance = null;
            private string sName = "Jashore University of Science and Technology";
            private string sAdress = "Ambottola, Jashore";

            public static University getUniversityInstance()
            {
                if (UniversityInstance==null)
                {
                    University oUniversity = new University();
                    UniversityInstance = oUniversity;
                }

                return UniversityInstance;
            }

            public void getUniversityInfo()
            {
                Console.WriteLine("-------------------");
                Console.WriteLine(sName+", "+sAdress);
                Console.WriteLine("-------------------");
            }
        }

        public sealed class DepartmentDB
        {
            private static List<clsDepartment> oDepartments = new List<clsDepartment>();

            static DepartmentDB()
            {
                oDepartments.Add(new clsDepartment(1, "CSE"));
                oDepartments.Add(new clsDepartment(2, "EEE"));
            }

            public static clsDepartment getDepartment(int nDepartmentID)
            {
                foreach (clsDepartment oDepartment in oDepartments)
                {
                    if (oDepartment.DepartmentID == nDepartmentID)
                    {
                        return oDepartment;
                    }
                }
                return new clsDepartment(0, "Department Name Not Found");
                // Null Object Pattern
            }
        }

        public class clsDepartment
        {
            private int _nDepartmentID;
            private string _sDepartmentName;

            public clsDepartment()
            {
                _nDepartmentID = 0;
                _sDepartmentName = "";
            }

            public clsDepartment(int nDepartmentID,string sDepartmentName)
            {
                _nDepartmentID = nDepartmentID;
                _sDepartmentName = sDepartmentName;
            }

            public int DepartmentID
            {
                get
                {
                    return _nDepartmentID;
                }
                set
                {
                    _nDepartmentID = value;
                }
            }

            public string DepartmentName
            {
                get
                {
                    return _sDepartmentName;
                }
                set
                {
                    _sDepartmentName = value;
                }
            }

        }

        public abstract class clsEmployee        // Declare a class
        {
            private string _sName;
            private DateTime _dDateofBirth;
            private char _sSex;
            private string _sPAddress;
            private string _sCAddress;
            private string _sPhone;
            private string _sDesignation;

            protected clsEmployee()        // Constructor
            {
                _sName = "";
                _dDateofBirth = DateTime.Today;
                _sSex = 'M';
                _sPAddress = "";
                _sCAddress = "";
                _sPhone = "";
                _sDesignation = "";
            }

            public string Name         // Properties
            {
                get
                {
                    return _sName;
                }
                set
                {
                    _sName = value;
                }
            }

            public DateTime DateofBirth
            {
                get
                {
                    return _dDateofBirth;
                }
                set
                {
                    _dDateofBirth = value;
                }
            }

            public char Sex
            {
                get
                {
                    return _sSex;
                }
                set
                {
                    _sSex = value;
                }
            }

            public string ParmanentAddress
            {
                get
                {
                    return _sPAddress;
                }
                set
                {
                    _sPAddress = value;
                }
            }

            public string CurrentAddress
            {
                get
                {
                    return _sCAddress;
                }
                set
                {
                    _sCAddress = value;
                }
            }

            public string Phone
            {
                get
                {
                    return _sPhone;
                }
                set
                {
                    _sPhone = value;
                }
            }

            public string Designation
            {
                get
                {
                    return _sDesignation;
                }
                set
                {
                    _sDesignation = value;
                }
            }

            public abstract void WriteInfo();     //Public Method

            // Can we write virtual function in Abstract class? How do we access them?
            // Can we Access any method from an Abstract class??
        }

        public class clsTeacherPhD : clsEmployee
        {
            private int _nDepartmentID;
            private int _nPapers;

            public clsTeacherPhD()
                : base()        // Constructor
            {
                _nDepartmentID = 0;
                _nPapers = 0;
            }

            public int DepartmentID
            {
                get
                {
                    return _nDepartmentID;
                }
                set
                {
                    _nDepartmentID = value;
                }
            }

            public clsDepartment Department
            {
                get
                {
                    return DepartmentDB.getDepartment(_nDepartmentID);
                }
            }

            public int Papers
            {
                get
                {
                    return _nPapers;
                }
                set
                {
                    _nPapers = value;
                }
            }

            public override void WriteInfo()      //Public Method
            {
                University oUni1 = University.getUniversityInstance();
                oUni1.getUniversityInfo();

                Console.WriteLine("Teacher Info:");
                Console.WriteLine("-------------------");
                Console.WriteLine();
                Console.WriteLine("Name:              " + "Dr. " +this.Name);
                Console.WriteLine("Date of Birth:     " + this.DateofBirth);
                Console.WriteLine("Sex:               " + this.Sex);
                Console.WriteLine("Parmanent Address: " + this.ParmanentAddress);
                Console.WriteLine("Current Address:   " + this.CurrentAddress);
                Console.WriteLine("Phone:             " + this.Phone);
                Console.WriteLine("Designation:       " + this.Designation);
                Console.WriteLine("Department:        " + this.Department.DepartmentName);
                Console.WriteLine("Papers:            " + this.Papers);

                //Console.ReadLine();
            }
        }

        public class clsTeacherNonPhD : clsEmployee
        {
            private int _nDepartmentID;
            private int _nPapers;

            public clsTeacherNonPhD()
                : base()        // Constructor
            {
                _nDepartmentID = 0;
                _nPapers = 0;
            }

            public int DepartmentID
            {
                get
                {
                    return _nDepartmentID;
                }
                set
                {
                    _nDepartmentID = value;
                }
            }

            public clsDepartment Department
            {
                get
                {
                    return DepartmentDB.getDepartment(_nDepartmentID);
                }
            }

            public int Papers
            {
                get
                {
                    return _nPapers;
                }
                set
                {
                    _nPapers = value;
                }
            }

            public override void WriteInfo()      //Public Method
            {
                University oUni2 = University.getUniversityInstance();
                oUni2.getUniversityInfo();

                Console.WriteLine("Teacher Info:");
                Console.WriteLine("-------------------");
                Console.WriteLine();
                Console.WriteLine("Name:              " + "Mr." + this.Name);
                Console.WriteLine("Date of Birth:     " + this.DateofBirth);
                Console.WriteLine("Sex:               " + this.Sex);
                Console.WriteLine("Parmanent Address: " + this.ParmanentAddress);
                Console.WriteLine("Current Address:   " + this.CurrentAddress);
                Console.WriteLine("Phone:             " + this.Phone);
                Console.WriteLine("Designation:       " + this.Designation);
                Console.WriteLine("Department:        " + this.Department.DepartmentName);
                Console.WriteLine("Papers:            " + this.Papers);

                //Console.ReadLine();
            }
        }

        public class clsOfficer : clsEmployee
        {
            private string _sOffice;
            private bool _bAssoMember;

            public clsOfficer()
                : base()        // Constructor
            {
                _sOffice = "";
                _bAssoMember = false;
            }

            public string Office
            {
                get
                {
                    return _sOffice;
                }
                set
                {
                    _sOffice = value;
                }
            }

            public bool AssociationMember
            {
                get
                {
                    return _bAssoMember;
                }
                set
                {
                    _bAssoMember = value;
                }
            }

            public override void WriteInfo()      //Public Method
            {
                University oUni3 = University.getUniversityInstance();
                oUni3.getUniversityInfo();

                Console.WriteLine("Officer Info:");
                Console.WriteLine("-------------------");
                Console.WriteLine();
                Console.WriteLine("Name:              " + this.Name);
                Console.WriteLine("Date of Birth:     " + this.DateofBirth);
                Console.WriteLine("Sex:               " + this.Sex);
                Console.WriteLine("Parmanent Address: " + this.ParmanentAddress);
                Console.WriteLine("Current Address:   " + this.CurrentAddress);
                Console.WriteLine("Phone:             " + this.Phone);
                Console.WriteLine("Designation:       " + this.Designation);
                Console.WriteLine("Office:            " + this.Office);
                Console.WriteLine("Association:       " + this.AssociationMember);

                //Console.ReadLine();
            }
        }

        public class clsStaff : clsEmployee
        {
            private double _nOverTime;

            public clsStaff()
                : base()        // Constructor
            {
                _nOverTime = 0;
            }

            public double OverTime
            {
                get
                {
                    return _nOverTime;
                }
                set
                {
                    _nOverTime = value;
                }
            }

            public override void WriteInfo()      //Public Method
            {
                University oUni4 = University.getUniversityInstance();
                oUni4.getUniversityInfo();

                Console.WriteLine("Staff Info:");
                Console.WriteLine("-------------------");
                Console.WriteLine();
                Console.WriteLine("Name:              " + this.Name);
                Console.WriteLine("Date of Birth:     " + this.DateofBirth);
                Console.WriteLine("Sex:               " + this.Sex);
                Console.WriteLine("Parmanent Address: " + this.ParmanentAddress);
                Console.WriteLine("Current Address:   " + this.CurrentAddress);
                Console.WriteLine("Phone:             " + this.Phone);
                Console.WriteLine("Designation:       " + this.Designation);
                Console.WriteLine("Overtime:        " + this.OverTime);

                //Console.ReadLine();
            }
        }

        public class clsFacultyFactory
        {
            public clsEmployee getTeacher(string sQualification)
            {
                if (sQualification == "PhD")
                {
                    clsTeacherPhD oTeacher = new clsTeacherPhD();

                    oTeacher.Name = "Nasim";
                    oTeacher.DateofBirth = Convert.ToDateTime("01/01/1979");
                    oTeacher.Sex = 'M';
                    oTeacher.ParmanentAddress = "Jhenaidah";
                    oTeacher.CurrentAddress = "Jashore";
                    oTeacher.Phone = "01708524079";
                    oTeacher.Designation = "Assistant Professor";
                    oTeacher.DepartmentID = 1;
                    oTeacher.Papers = 20;
                    return oTeacher;
                }
                else if (sQualification == "MSc")
                {
                    clsTeacherNonPhD oTeacher = new clsTeacherNonPhD();

                    oTeacher.Name = "Imran";
                    oTeacher.DateofBirth = Convert.ToDateTime("01/01/1979");
                    oTeacher.Sex = 'M';
                    oTeacher.ParmanentAddress = "Khulna";
                    oTeacher.CurrentAddress = "Jashore";
                    oTeacher.Phone = "01712345678";
                    oTeacher.Designation = "Lecturer";
                    oTeacher.DepartmentID = 2;
                    oTeacher.Papers = 2;
                    return oTeacher;
                }
                return null;
            }
        }

        static void Main(string[] args)
        {
            clsEmployee[] oEmployees = new clsEmployee[4];

            clsFacultyFactory oFacultyFactory = new clsFacultyFactory();

            oEmployees[0] = oFacultyFactory.getTeacher("PhD");
            oEmployees[1] = oFacultyFactory.getTeacher("MSc");

            clsOfficer oOfficer = new clsOfficer();

            oOfficer.Name = "Ahdab";
            oOfficer.DateofBirth = Convert.ToDateTime("01/01/1975");
            oOfficer.Sex = 'M';
            oOfficer.ParmanentAddress = "Dinajpur";
            oOfficer.CurrentAddress = "Kalyanpur";
            oOfficer.Phone = "01712345678";
            oOfficer.Designation = "Clark (Grade-1)";
            oOfficer.Office = "HR";
            oOfficer.AssociationMember = true;

            oEmployees[2] = oOfficer;

            clsStaff oStaff = new clsStaff();

            oStaff.Name = "Kuddus";
            oStaff.DateofBirth = Convert.ToDateTime("01/01/1980");
            oStaff.Sex = 'M';
            oStaff.ParmanentAddress = "Dinajpur";
            oStaff.CurrentAddress = "Kalyanpur";
            oStaff.Phone = "01712345678";
            oStaff.Designation = "Sweeper";
            oStaff.OverTime = 10.75;

            oEmployees[3] = oStaff;

            for (int i = 0; i < 4; i++)
            {
                oEmployees[i].WriteInfo();
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
