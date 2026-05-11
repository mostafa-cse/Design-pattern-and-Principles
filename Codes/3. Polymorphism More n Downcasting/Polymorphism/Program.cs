using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    class Program
    {
        public class clsEmployee        // Declare a class
        {
            private string _sName;
            private DateTime _dDateofBirth;
            private char _sSex;
            private string _sPAddress;
            private string _sCAddress;
            private string _sPhone;
            private string _sDesignation;

            public clsEmployee()        // Constructor
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

            public virtual void WriteInfo()      //Public Method
            {
                Console.WriteLine("Employee Info:");
                Console.WriteLine("-------------------");
                Console.WriteLine();
                Console.WriteLine("Name:              " + this.Name);
                Console.WriteLine("Date of Birth:     " + this.DateofBirth);
                Console.WriteLine("Sex:               " + this.Sex);
                Console.WriteLine("Parmanent Address: " + this.ParmanentAddress);
                Console.WriteLine("Current Address:   " + this.CurrentAddress);
                Console.WriteLine("Phone:             " + this.Phone);
                Console.WriteLine("Designation:       " + this.Designation);

                //Console.ReadLine();
            }
        }

        public class clsTeacher : clsEmployee
        {
            private string _sDepartment;
            private int _nPapers;

            public clsTeacher()
                : base()        // Constructor
            {
                _sDepartment = "";
                _nPapers = 0;
            }

            public string Department
             {
                get
                {
                    return _sDepartment;
                }
                set
                {
                    _sDepartment = value;
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
                Console.WriteLine("Teacher Info:");
                Console.WriteLine("-------------------");
                Console.WriteLine();
                Console.WriteLine("Name:              " + this.Name);
                Console.WriteLine("Date of Birth:     " + this.DateofBirth);
                Console.WriteLine("Sex:               " + this.Sex);
                Console.WriteLine("Parmanent Address: " + this.ParmanentAddress);
                Console.WriteLine("Current Address:   " + this.CurrentAddress);
                Console.WriteLine("Phone:             " + this.Phone);
                Console.WriteLine("Designation:       " + this.Designation);
                Console.WriteLine("Department:        " + this.Department);
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

        static void Main(string[] args)
        {
            clsEmployee[] oEmployees = new clsEmployee[4];

            clsTeacher oTeacher1 = new clsTeacher();

            oTeacher1.Name = "Nasim";
            oTeacher1.DateofBirth =Convert.ToDateTime("01/01/1979");
            oTeacher1.Sex = 'M';
            oTeacher1.ParmanentAddress = "Magura";
            oTeacher1.CurrentAddress = "Mirpur";
            oTeacher1.Phone = "01730016854";
            oTeacher1.Designation = "Assistant Professor";
            oTeacher1.Department = "CSE";
            oTeacher1.Papers = 20;

            oEmployees[0] = oTeacher1;

            clsTeacher oTeacher2 = new clsTeacher();

            oTeacher2.Name = "Abdullah";
            oTeacher2.DateofBirth = Convert.ToDateTime("01/01/1980");
            oTeacher2.Sex = 'M';
            oTeacher2.ParmanentAddress = "Dinajpur";
            oTeacher2.CurrentAddress = "Kalyanpur";
            oTeacher2.Phone = "01712345678";
            oTeacher2.Designation = "Clark (Grade-3)";
            oTeacher2.Department = "EEE";
            oTeacher2.Papers = 5;

            oEmployees[1] = oTeacher2;

            /*for (int i = 0; i <= 1; i++)
            {
                oEmployees[i].WriteInfo();
                Console.WriteLine();
            }*/

            for (int i = 0; i <= 1; i++)
            {
                clsTeacher oTeacherDC = (clsTeacher)oEmployees[i]; // Downcasting

                oTeacherDC.WriteInfo();

                //clsEmployee oEmployeeUC = (clsEmployee)oTeacherDC;

                clsEmployee oEmployeeUC = (clsEmployee)oTeacherDC;

                oEmployeeUC.WriteInfo(); // Upcasting

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
