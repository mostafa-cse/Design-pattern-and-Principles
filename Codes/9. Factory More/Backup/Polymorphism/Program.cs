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

        static void Main(string[] args)
        {
            clsEmployee[] oEmployees = new clsEmployee[2];

            clsTeacher oTeacher = new clsTeacher();

            oTeacher.Name = "Nasim";
            oTeacher.DateofBirth =Convert.ToDateTime("17/12/1979");
            oTeacher.Sex = 'M';
            oTeacher.ParmanentAddress = "Magura";
            oTeacher.CurrentAddress = "Mirpur";
            oTeacher.Phone = "01730016854";
            oTeacher.Designation = "Assistant Director";
            oTeacher.Department = "ITOCD";
            oTeacher.Papers = 2;

            oEmployees[0] = oTeacher;


            clsOfficer oOfficer = new clsOfficer();

            oOfficer.Name = "Ahdab";
            oOfficer.DateofBirth = Convert.ToDateTime("01/01/1975");
            oOfficer.Sex = 'M';
            oOfficer.ParmanentAddress = "Dinajpur";
            oOfficer.CurrentAddress = "Kalyanpur";
            oOfficer.Phone = "01712345678";
            oOfficer.Designation = "Clark (Grade-3)";
            oOfficer.Office = "HR";
            oOfficer.AssociationMember = true;

            oEmployees[1] = oOfficer;

            for (int i = 0; i <= 1; i++)
            {
                oEmployees[i].WriteInfo();
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
