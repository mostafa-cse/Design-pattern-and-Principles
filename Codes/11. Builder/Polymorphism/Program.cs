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

        public sealed class clsDepartmentDB
        {
            private static List<clsDepartment> oDepartments = new List<clsDepartment>();

            static clsDepartmentDB()
            {
                oDepartments.Add(new clsDepartment(1, "CSE"));
                oDepartments.Add(new clsDepartment(2, "EEE"));
            }

            public clsDepartment getDepartment(int nDepartmentID)
            {
                foreach (clsDepartment oDepartment in oDepartments)
                {
                    if (oDepartment.DepartmentID == nDepartmentID)
                    {
                        return oDepartment;
                    }
                }
                return new clsDepartment(0, "Department Name Not Found"); ;
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
            protected string _sName;
            protected DateTime _dDateofBirth;
            protected char _sSex;
            protected string _sPAddress;
            protected string _sCAddress;
            protected string _sPhone;
            protected string _sDesignation;

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

            public clsTeacherPhD(string sName, DateTime dDateofBirth, char sSex, string sPAddress, string sCAddress, string sPhone, string sDesignation, int nDepartmentID, int nPapers)
                : base()        // Constructor
            {
                _sName = sName;
                _dDateofBirth = dDateofBirth;
                _sSex = sSex;
                _sPAddress = sPAddress;
                _sCAddress = sCAddress;
                _sPhone = sPhone;
                _sDesignation = sDesignation;
                _nDepartmentID = nDepartmentID;
                _nPapers = nPapers;
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
                    clsDepartmentDB oDepartments = new clsDepartmentDB();

                    return oDepartments.getDepartment(_nDepartmentID);
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

            public clsTeacherNonPhD(string sName, DateTime dDateofBirth, char sSex, string sPAddress, string sCAddress, string sPhone, string sDesignation, int nDepartmentID, int nPapers)
                : base()        // Constructor
            {
                _sName = sName;
                _dDateofBirth = dDateofBirth;
                _sSex = sSex;
                _sPAddress = sPAddress;
                _sCAddress = sCAddress;
                _sPhone = sPhone;
                _sDesignation = sDesignation;
                _nDepartmentID = nDepartmentID;
                _nPapers = nPapers;
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
                    clsDepartmentDB oDepartments = new clsDepartmentDB();

                    return oDepartments.getDepartment(_nDepartmentID);
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
                Console.WriteLine("Name:              " + "Mr. " + this.Name);
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
                Console.WriteLine("Ocertime:        " + this.OverTime);

                //Console.ReadLine();
            }
        }

        public class clsTeacherBuilder
        {
            private string _sName;
            private DateTime _dDateofBirth;
            private char _sSex;
            private string _sPAddress;
            private string _sCAddress;
            private string _sPhone;
            private string _sDesignation;
            private int _nDepartmentID;
            private int _nPapers;

            public clsTeacherBuilder()
            {
            }

            public clsTeacherBuilder setName(String sName)
            {
                this._sName = sName;
                return this;
            }

            public clsTeacherBuilder setDateofBirth(DateTime dDateofBirth)
            {
                this._dDateofBirth = dDateofBirth;
                return this;
            }

            public clsTeacherBuilder setSex(char sSex)
            {
                this._sSex = sSex;
                return this;
            }

            public clsTeacherBuilder setPAddress(String sPAddress)
            {
                this._sPAddress = sPAddress;
                return this;
            }

            public clsTeacherBuilder setCAddress(String sCAddress)
            {
                this._sCAddress = sCAddress;
                return this;
            }

            public clsTeacherBuilder setPhone(String sPhone)
            {
                this._sPhone = sPhone;
                return this;
            }

            public clsTeacherBuilder setDesignation(String sDesignation)
            {
                this._sDesignation = sDesignation;
                return this;
            }

            public clsTeacherBuilder setDepartmentID(int nDepartmentID)
            {
                this._nDepartmentID = nDepartmentID;
                return this;
            }

            public clsTeacherBuilder setPapers(int nPapers)
            {
                this._nPapers = nPapers;
                return this;
            }

            public clsTeacherPhD createTeacherPhD()
            {
                return new clsTeacherPhD(_sName, _dDateofBirth, _sSex, _sPAddress, _sCAddress, _sPhone, _sDesignation, _nDepartmentID, _nPapers);
            }

            public clsTeacherNonPhD createTeacherNonPhD()
            {
                return new clsTeacherNonPhD(_sName, _dDateofBirth, _sSex, _sPAddress, _sCAddress, _sPhone, _sDesignation, _nDepartmentID, _nPapers);
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
                    oTeacher.CurrentAddress = "Mirpur";
                    oTeacher.Phone = "01730016854";
                    oTeacher.Designation = "Assistant Professor";
                    oTeacher.DepartmentID = 1;
                    oTeacher.Papers = 2;
                    return oTeacher;
                }
                else if (sQualification == "MSc")
                {
                    clsTeacherNonPhD oTeacher = new clsTeacherNonPhD();

                    oTeacher.Name = "Imran";
                    oTeacher.DateofBirth = Convert.ToDateTime("01/01/1978");
                    oTeacher.Sex = 'M';
                    oTeacher.ParmanentAddress = "Jashore";
                    oTeacher.CurrentAddress = "Bosila";
                    oTeacher.Phone = "01730016854";
                    oTeacher.Designation = "Assistant Professor";
                    oTeacher.DepartmentID = 2;
                    oTeacher.Papers = 2;
                    return oTeacher;
                }
                return null;
            }

            public clsEmployee getTeacher(string sQualification, string sName, string sDOB, string sParmanentAddress, string sDesignation, string sDepartment)
            {
                if (sQualification == "PhD")
                {
                    int nDepartmentID = 0;

                    if (sDepartment == "CSE")
                        nDepartmentID = 1;
                    else if (sDepartment == "EEE")
                        nDepartmentID = 2;

                    clsTeacherPhD oTeacher = new clsTeacherBuilder().setName(sName).setDateofBirth(Convert.ToDateTime(sDOB)).setPAddress(sParmanentAddress).setDesignation(sDesignation).setDepartmentID(nDepartmentID).createTeacherPhD();

                    return oTeacher;
                }
                else if (sQualification == "MSc")
                {
                    int nDepartmentID = 0;

                    if (sDepartment == "CSE")
                        nDepartmentID = 1;
                    else if (sDepartment == "EEE")
                        nDepartmentID = 2;

                    clsTeacherNonPhD oTeacher = new clsTeacherBuilder().setName(sName).setDateofBirth(Convert.ToDateTime(sDOB)).setPAddress(sParmanentAddress).setDesignation(sDesignation).setDepartmentID(nDepartmentID).createTeacherNonPhD();

                    return oTeacher;
                }
                return null;
            }
        }

        public interface IEmployeeAdapter
        {
            List<clsEmployee> getEmployees();
        }

        public class clsLegacyTeachingHRSystem
        {
            public string[][] getTeachers()
            {
                string[][] sEmployees = new string[2][];

                sEmployees[0] = new string[] {"PhD", "Arif", "01/01/1979", "Jashore","Assistant Professor","CSE"};
                sEmployees[1] = new string[] {"MSc", "Rakib", "01/01/1982", "Khulna", "Lecturer", "EEE" };

                return sEmployees;
            }
        }

        public class clsLegacyOfficialHRSystem
        {
            public string[][] getOfficers()
            {
                string[][] sEmployees = new string[2][];

                sEmployees[0] = new string[] { "Reza", "01/01/1979", "Jashore", "Clark (Grade-2)", "HR" };
                sEmployees[1] = new string[] { "Hakim", "01/01/1982", "Khulna", "Clark (Grade-3)", "ACC" };

                return sEmployees;
            }
        }

        public class clsTeacherAdapter : IEmployeeAdapter
        {
            public List<clsEmployee> getEmployees()
            {
                List<clsEmployee> oEmployees = new List<clsEmployee>();

                clsLegacyTeachingHRSystem oLegacyTeachingHRSystem = new clsLegacyTeachingHRSystem();

                string[][] sEmployees = oLegacyTeachingHRSystem.getTeachers();

                foreach (string[] sEmployee in sEmployees)
                {
                    clsFacultyFactory oFacultyFactory = new clsFacultyFactory();

                    oEmployees.Add(oFacultyFactory.getTeacher(sEmployee[0], sEmployee[1], sEmployee[2], sEmployee[3], sEmployee[4], sEmployee[5]));
                }

                return oEmployees;
            }
        }

        public class clsOfficerAdapter : IEmployeeAdapter
        {
            public List<clsEmployee> getEmployees()
            {
                List<clsEmployee> oEmployees = new List<clsEmployee>();

                clsLegacyOfficialHRSystem oLegacyOfficialHRSystem = new clsLegacyOfficialHRSystem();

                string[][] sEmployees = oLegacyOfficialHRSystem.getOfficers();

                foreach (string[] sEmployee in sEmployees)
                {
                    clsOfficer oOfficer = new clsOfficer();

                    oOfficer.Name = sEmployee[0];
                    oOfficer.DateofBirth = Convert.ToDateTime(sEmployee[1]);
                    oOfficer.Sex = 'M';
                    oOfficer.ParmanentAddress = sEmployee[2];
                    oOfficer.CurrentAddress = "NA";
                    oOfficer.Phone = "NA";
                    oOfficer.Designation = sEmployee[3];
                    oOfficer.Office = sEmployee[4];
                    oOfficer.AssociationMember = true;

                    oEmployees.Add(oOfficer);
                }

                return oEmployees;
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

            IEmployeeAdapter oAdapter = new clsTeacherAdapter();

            Console.WriteLine("######### Teacher List from Legacy System ##########");

            foreach (clsEmployee oEmployee in oAdapter.getEmployees())
            {
                oEmployee.WriteInfo();
            }

            oAdapter = new clsOfficerAdapter();

            Console.WriteLine("######### Officer List from Legacy System ##########");

            foreach (clsEmployee oEmployee in oAdapter.getEmployees())
            {
                oEmployee.WriteInfo();
            }

            Console.ReadLine();
        }
    }
}
