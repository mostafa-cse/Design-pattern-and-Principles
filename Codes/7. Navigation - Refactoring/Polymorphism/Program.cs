using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    class Program
    {
        public class clsDepartment
        {
            private int _nDepartmentID;
            private string _sName;

            public clsDepartment()
            {
                _nDepartmentID = 0;
                _sName = "";
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

            public string Name
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

        }

        public class clsAppointmentType
        {
            // Why not Abstract or Interface???

            protected double _nBonusPercent = 0.0;

            public virtual double getBonusPercent()
            {
                return _nBonusPercent;
            }   
        }

        public class clsPermanent : clsAppointmentType
        {
            public clsPermanent()
            {
                _nBonusPercent = 1.0;
            }

            public override double getBonusPercent()
            {
                return _nBonusPercent;
            }
        }

        public class clsTemporary : clsAppointmentType
        {
            public clsTemporary()
            {
                _nBonusPercent = 0.5;
            }

            public override double getBonusPercent()
            {
                return _nBonusPercent;
            }
        }

        public class clsCasual : clsAppointmentType
        {
            public clsCasual()
            {
                _nBonusPercent = 0.1;
            }

            public override double getBonusPercent()
            {
                return _nBonusPercent;
            }
        }

        /*public class clsSuperCasual : clsAppointmentType
        {
            public clsSuperCasual()
            {
                _nBonusPercent = 0.05;
            }

            public override double getBonusPercent()
            {
                return _nBonusPercent;
            }
        }*/

        public class clsSalaryCalculator
        {
            private double _nBasicSalary = 0.0;

            private clsAppointmentType _oAppointmentType;

            public clsSalaryCalculator(double nBSalary, clsAppointmentType oAppointmentType)
            {
                this._nBasicSalary = nBSalary;
                this._oAppointmentType = oAppointmentType;
            }

            public double getBonus()
            {
                double nBonus = 0.0;

                nBonus = _nBasicSalary * _oAppointmentType.getBonusPercent();

                return nBonus;
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
            private double _nBasicSalary;

            public clsEmployee()        // Constructor
            {
                _sName = "";
                _dDateofBirth = DateTime.Today;
                _sSex = 'M';
                _sPAddress = "";
                _sCAddress = "";
                _sPhone = "";
                _sDesignation = "";
                _nBasicSalary = 0.0;
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

            public double BasicSalary
            {
                get
                {
                    return _nBasicSalary;
                }
                set
                {
                    _nBasicSalary = value;
                }
            }
            public abstract void WriteInfo();     //Public Method
        }

        public class clsTeacher : clsEmployee
        {
            private int _nDepartmentID;
            private int _nPapers;
            private clsDepartment _oDepartment;

            public clsTeacher()
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
                    _oDepartment = new clsDepartment();

                    if (_nDepartmentID == 1)
                    {
                        _oDepartment.DepartmentID = 1;
                        _oDepartment.Name = "CSE";
                    }
                    else if (_nDepartmentID == 2)
                    {
                        _oDepartment.DepartmentID = 2;
                        _oDepartment.Name = "EEE";
                    }
                    
                    return _oDepartment;
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
                Console.WriteLine("Department:        " + this.Department.Name);
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
                Console.WriteLine("Ocertime:          " + this.OverTime);

                //Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            clsEmployee[] oEmployees = new clsEmployee[4];
            clsSalaryCalculator[] oSCalcs = new clsSalaryCalculator[4];

            clsTeacher oTeacher1 = new clsTeacher();

            oTeacher1.Name = "Nasim";
            oTeacher1.DateofBirth =Convert.ToDateTime("01/01/1979");
            oTeacher1.Sex = 'M';
            oTeacher1.ParmanentAddress = "Magura";
            oTeacher1.CurrentAddress = "Mirpur";
            oTeacher1.Phone = "01730016854";
            oTeacher1.Designation = "Assistant Professor";
            oTeacher1.BasicSalary = 100000;
            oTeacher1.DepartmentID = 1;
            oTeacher1.Papers = 2;

            oEmployees[0] = oTeacher1;

            clsSalaryCalculator oSCalcT1 = new clsSalaryCalculator(oTeacher1.BasicSalary, new clsPermanent());
            oSCalcs[0] = oSCalcT1;

            clsTeacher oTeacher2 = new clsTeacher();

            oTeacher2.Name = "Rahman";
            oTeacher2.DateofBirth = Convert.ToDateTime("01/01/1979");
            oTeacher2.Sex = 'M';
            oTeacher2.ParmanentAddress = "Magura";
            oTeacher2.CurrentAddress = "Mirpur";
            oTeacher2.Phone = "01730016854";
            oTeacher2.Designation = "Lecturer";
            oTeacher2.BasicSalary = 100000;
            oTeacher2.DepartmentID = 2;
            oTeacher2.Papers = 2;

            oEmployees[1] = oTeacher2;

            clsSalaryCalculator oSCalcT2 = new clsSalaryCalculator(oTeacher2.BasicSalary, new clsTemporary());
            oSCalcs[1] = oSCalcT2;

            clsOfficer oOfficer = new clsOfficer();

            oOfficer.Name = "Ahdab";
            oOfficer.DateofBirth = Convert.ToDateTime("01/01/1975");
            oOfficer.Sex = 'M';
            oOfficer.ParmanentAddress = "Dinajpur";
            oOfficer.CurrentAddress = "Kalyanpur";
            oOfficer.Phone = "01712345678";
            oOfficer.Designation = "Clark (Grade-1)";
            oOfficer.BasicSalary = 100000;
            oOfficer.Office = "HR";
            oOfficer.AssociationMember = true;

            oEmployees[2] = oOfficer;

            clsSalaryCalculator oSCalcO = new clsSalaryCalculator(oOfficer.BasicSalary, new clsCasual());
            oSCalcs[2] = oSCalcO;

            clsStaff oStaff = new clsStaff();

            oStaff.Name = "Kuddus";
            oStaff.DateofBirth = Convert.ToDateTime("01/01/1980");
            oStaff.Sex = 'M';
            oStaff.ParmanentAddress = "Dinajpur";
            oStaff.CurrentAddress = "Kalyanpur";
            oStaff.Phone = "01712345678";
            oStaff.Designation = "Sweeper";
            oStaff.BasicSalary = 50000;
            oStaff.OverTime = 10.75;

            oEmployees[3] = oStaff;

            clsSalaryCalculator oSCalcS = new clsSalaryCalculator(oStaff.BasicSalary, new clsPermanent());
            oSCalcs[3] = oSCalcS;

            for (int i = 0; i < 4; i++)
            {
                oEmployees[i].WriteInfo();

                double nBonus = oSCalcs[i].getBonus();

                Console.WriteLine("-------------------");

                Console.WriteLine("Basic Salary:      " + oEmployees[i].BasicSalary);

                Console.WriteLine("Bonus:             " + nBonus);

                Console.WriteLine("Total Salary:      " + Convert.ToString(oEmployees[i].BasicSalary + nBonus));

                Console.WriteLine();
            }

            /*for (int i = 0; i < 4; i++)
            {
                oEmployees[i].WriteInfo();
                Console.WriteLine("Total Salary: " + oSCalcs[i].getTotalSalary());

                Console.WriteLine();
            }*/

            Console.ReadLine();
        }
    }
}
