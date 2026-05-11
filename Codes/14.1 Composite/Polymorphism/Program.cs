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
            private string _sDepartmentName;

            public clsDepartment()
            {
                _nDepartmentID = 0;
                _sDepartmentName = "";
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

        public abstract class clsGrade
        {
            protected string _sName;
            protected double _nBasicSalary;

            public string Name         // Properties
            {
                get
                {
                    return _sName;
                }
            }

            public abstract double getHouseRent();
            public abstract double getConveyance();

            public virtual double getHouseRentConveyance()
            {
                return getHouseRent() + getConveyance();
            }

            /*public double getHouseRentConveyanceTest()
            {
                return getHouseRent() + getConveyance();
            }*/
        }

        public class clsGradeA : clsGrade
        {

            public clsGradeA(double nBSalary)
            {
                _sName = "Grade A";
                _nBasicSalary = nBSalary;
            }

            public override double getHouseRent()
            {
                return _nBasicSalary * 0.5;
            }

            public override double getConveyance()
            {
                return _nBasicSalary * 0.5;
            }
        }

        public class clsGradeB : clsGrade
        {

            public clsGradeB(double nBSalary)
            {
                _sName = "Grade B";
                _nBasicSalary = nBSalary;
            }

            public override double getHouseRent()
            {
                return _nBasicSalary * 0.3;
            }

            public override double getConveyance()
            {
                return _nBasicSalary * 0.3;
            }
        }

        public class clsGradeC : clsGrade
        {

            public clsGradeC(double nBSalary)
            {
                _sName = "Grade C";
                _nBasicSalary = nBSalary;
            }

            public override double getHouseRent()
            {
                return _nBasicSalary * 0.1;
            }

            public override double getConveyance()
            {
                return _nBasicSalary * 0.1;
            }
        }

        public abstract class clsAppointmentType
        {
            protected double _nBasicSalary;

            protected double _nBonusPercent = 0.0;

            public abstract double getBonusPercent();

            public virtual double getBonus()
            {
                return _nBasicSalary * _nBonusPercent;
            }
        }

        public class clsPermanent : clsAppointmentType
        {
            public clsPermanent(double nBSalary)
            {
                _nBasicSalary = nBSalary;
                _nBonusPercent = 1.0;
            }

            public override double getBonusPercent()
            {
                return _nBonusPercent;
            }
        }

        public class clsTemporary : clsAppointmentType
        {
            public clsTemporary(double nBSalary)
            {
                _nBasicSalary = nBSalary;
                _nBonusPercent = 0.5;
            }

            public override double getBonusPercent()
            {
                return _nBonusPercent;
            }
        }

        public class clsCasual : clsAppointmentType
        {
            public clsCasual(double nBSalary)
            {
                _nBasicSalary = nBSalary;
                _nBonusPercent = 0.1;
            }

            public override double getBonusPercent()
            {
                return _nBonusPercent;
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

            private clsGrade _oGrade;
            private clsAppointmentType _oAppointmentType;
            private List<clsEmployee> _oEmployeeList;

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

                _oEmployeeList = new List<clsEmployee>();
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

            public clsGrade Grade
            {
                get
                {
                    return _oGrade;
                }
                set
                {
                    _oGrade = value;
                }
            }

            public clsAppointmentType AppointmentType
            {
                get
                {
                    return _oAppointmentType;
                }
                set
                {
                    _oAppointmentType = value;
                }
            }

            public void Add(clsEmployee oEmployee)
            {
                _oEmployeeList.Add(oEmployee);
            }

            public virtual double getTotalSubordinateSalaries()
            {
                double nTotalSalary = 0.0;

                foreach (clsEmployee oEmployee in _oEmployeeList)
                {
                    nTotalSalary = nTotalSalary + oEmployee.BasicSalary + oEmployee.Grade.getHouseRentConveyance() + oEmployee.AppointmentType.getBonus();
                }

                return nTotalSalary;
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
                        _oDepartment.DepartmentName = "CSE";
                    }
                    else if (_nDepartmentID == 2)
                    {
                        _oDepartment.DepartmentID = 2;
                        _oDepartment.DepartmentName = "EEE";
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
                Console.WriteLine("Department:        " + this.Department.DepartmentName);
                Console.WriteLine("Papers:            " + this.Papers);
                Console.WriteLine("Grade:             " + this.Grade.Name);

                Console.WriteLine("Basic Salary:      " + this.BasicSalary);

                Console.WriteLine("House Rent + Conv: " + this.Grade.getHouseRentConveyance());

                Console.WriteLine("Bonus            : " + this.AppointmentType.getBonus());

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
                Console.WriteLine("Grade:             " + this.Grade.Name);
                Console.WriteLine("Basic Salary:      " + this.BasicSalary);
                Console.WriteLine("House Rent + Conv: " + this.Grade.getHouseRentConveyance());
                Console.WriteLine("Bonus            : " + this.AppointmentType.getBonus());

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
                Console.WriteLine("Overtime:          " + this.OverTime);
                Console.WriteLine("Grade:             " + this.Grade.Name);
                Console.WriteLine("Basic Salary:      " + this.BasicSalary);
                Console.WriteLine("House Rent + Conv: " + this.Grade.getHouseRentConveyance());
                Console.WriteLine("Bonus            : " + this.AppointmentType.getBonus());
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
            oTeacher1.Designation = "Assistant Director";
            oTeacher1.BasicSalary = 100000;
            oTeacher1.DepartmentID = 1;
            oTeacher1.Papers = 2;

            oTeacher1.Grade = new clsGradeA(oTeacher1.BasicSalary);
            oTeacher1.AppointmentType = new clsPermanent(oTeacher1.BasicSalary);

            oTeacher1.Add(oTeacher1);
            //oEmployees[0] = oTeacher1;

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

            clsGradeB oGradeBT2 = new clsGradeB(oTeacher2.BasicSalary);
            oTeacher2.Grade = oGradeBT2;

            oTeacher2.Grade = new clsGradeB(oTeacher2.BasicSalary);
            oTeacher2.AppointmentType = new clsTemporary(oTeacher2.BasicSalary);

            oEmployees[1] = oTeacher2;

            clsOfficer oOfficer = new clsOfficer();

            oOfficer.Name = "Ahdab Added";
            oOfficer.DateofBirth = Convert.ToDateTime("01/01/1975");
            oOfficer.Sex = 'M';
            oOfficer.ParmanentAddress = "Dinajpur";
            oOfficer.CurrentAddress = "Kalyanpur";
            oOfficer.Phone = "01712345678";
            oOfficer.Designation = "Clark (Grade-1)";
            oOfficer.BasicSalary = 100000;
            oOfficer.Office = "HR";
            oOfficer.AssociationMember = true;

            oOfficer.Grade = new clsGradeA(oOfficer.BasicSalary);
            oOfficer.AppointmentType = new clsCasual(oOfficer.BasicSalary);

            oEmployees[2] = oOfficer;
            oTeacher1.Add(oOfficer);

            clsStaff oStaff = new clsStaff();

            oStaff.Name = "Kuddus Added";
            oStaff.DateofBirth = Convert.ToDateTime("01/01/1980");
            oStaff.Sex = 'M';
            oStaff.ParmanentAddress = "Dinajpur";
            oStaff.CurrentAddress = "Kalyanpur";
            oStaff.Phone = "01712345678";
            oStaff.Designation = "Sweeper";
            oStaff.BasicSalary = 50000;
            oStaff.OverTime = 10.75;

            oStaff.Grade = new clsGradeC(oStaff.BasicSalary);
            oStaff.AppointmentType = new clsPermanent(oStaff.BasicSalary);

            oEmployees[3] = oStaff;
            oTeacher1.Add(oStaff);

            oEmployees[0] = oTeacher1;

            for (int i = 0; i < 4; i++)
            {
                oEmployees[i].WriteInfo();

                double nTotalSalary = oEmployees[i].BasicSalary + oEmployees[i].Grade.getHouseRentConveyance() + oEmployees[i].AppointmentType.getBonus();

                Console.WriteLine("Total Salary:      " + nTotalSalary);

                Console.WriteLine("Total Sub Salary:  " + oEmployees[i].getTotalSubordinateSalaries());

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
