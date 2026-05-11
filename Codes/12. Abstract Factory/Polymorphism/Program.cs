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

            public string Name
            {
                get
                {
                    return _sName;
                }
            }
            public double BasicSalary
            {
                get
                {
                    return _nBasicSalary;
                }
            }
            public abstract double getHouseRent();
            public abstract double getConveyance();
            public virtual double getHouseRentConveyance()
            {
                return _nBasicSalary + getHouseRent() + getConveyance();
            }
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

        public class clsGradeD : clsGrade
        {
            public clsGradeD(double nBSalary)
            {
                _sName = "Grade D";
                _nBasicSalary = nBSalary;
            }

            public override double getHouseRent()
            {
                return _nBasicSalary * 0.05;
            }
            public override double getConveyance()
            {
                return _nBasicSalary * 0.02;
            }
        }

        // --- Appointment hierarchy (abstract product) ---
        public abstract class clsAppointmentType
        {
            protected double _nBonusPercent = 0.0;
            public abstract double getBonusPercent();
        }

        public class clsPublicPermanent : clsAppointmentType
        {
            public clsPublicPermanent()
            {
                _nBonusPercent = 1.0;
            }
            public override double getBonusPercent()
            {
                return _nBonusPercent;
            }
        }

        public class clsPublicTemporary : clsAppointmentType
        {
            public clsPublicTemporary()
            {
                _nBonusPercent = 0.5;
            }
            public override double getBonusPercent()
            {
                return _nBonusPercent;
            }
        }

        public class clsPublicCasual : clsAppointmentType
        {
            public clsPublicCasual()
            {
                _nBonusPercent = 0.1;
            }
            public override double getBonusPercent()
            {
                return _nBonusPercent;
            }
        }

        public class clsPrivatePermanent : clsAppointmentType
        {
            public clsPrivatePermanent()
            {
                _nBonusPercent = 0.6;
            }
            public override double getBonusPercent()
            {
                return _nBonusPercent;
            }
        }

        public class clsPrivateTemporary : clsAppointmentType
        {
            public clsPrivateTemporary()
            {
                _nBonusPercent = 0.4;
            }
            public override double getBonusPercent()
            {
                return _nBonusPercent;
            }
        }

        public class clsPrivateCasual : clsAppointmentType
        {
            public clsPrivateCasual()
            {
                _nBonusPercent = 0.15;
            }
            public override double getBonusPercent()
            {
                return _nBonusPercent;
            }
        }

        // --- Salary calculator (uses an appointment product) ---
        public class clsSalaryCalculator
        {
            private double _nBasicSalary = 0.0;
            private clsAppointmentType _oAppointmentType;

            public clsSalaryCalculator(double nBSalary, clsAppointmentType oAppointmentType)
            {
                _nBasicSalary = nBSalary;
                _oAppointmentType = oAppointmentType;
            }

            public double getBonus()
            {
                return _nBasicSalary * _oAppointmentType.getBonusPercent();
            }
        }

        // --- Abstract Factory ---
        public abstract class clsUniversityFactory
        {
            public abstract clsGrade CreateGrade(string gradeCode, double basicSalary);
            public abstract clsAppointmentType CreateAppointment(string appointmentCode);
        }

        // Public university factory (creates public-family products)
        public class Public_UniversityFactory : clsUniversityFactory
        {
            public override clsGrade CreateGrade(string gradeCode, double basicSalary)
            {
                switch ((gradeCode ?? string.Empty).Trim().ToUpper())
                {
                    case "A": return new clsGradeA(basicSalary);
                    case "B": return new clsGradeB(basicSalary);
                    case "C": return new clsGradeC(basicSalary);
                    case "D": return new clsGradeD(basicSalary);
                    default:  return new clsGradeD(basicSalary);
                }
            }

            public override clsAppointmentType CreateAppointment(string appointmentCode)
            {
                switch ((appointmentCode ?? string.Empty).Trim().ToUpper())
                {
                    case "PERM": return new clsPublicPermanent();
                    case "TEMP": return new clsPublicTemporary();
                    case "CAS":  return new clsPublicCasual();
                    default:     return new clsPublicCasual();
                }
            }
        }

        // Private university factory (creates private-family products)
        public class Private_UniversityFactory : clsUniversityFactory
        {
            public override clsGrade CreateGrade(string gradeCode, double basicSalary)
            {
                switch ((gradeCode ?? string.Empty).Trim().ToUpper())
                {
                    case "A": return new clsGradeA(basicSalary);
                    case "B": return new clsGradeB(basicSalary);
                    case "C": return new clsGradeC(basicSalary);
                    case "D": return new clsGradeD(basicSalary);
                    default:  return new clsGradeD(basicSalary);
                }
            }

            public override clsAppointmentType CreateAppointment(string appointmentCode)
            {
                switch ((appointmentCode ?? string.Empty).Trim().ToUpper())
                {
                    case "PERM": return new clsPrivatePermanent();
                    case "TEMP": return new clsPrivateTemporary();
                    case "CAS":  return new clsPrivateCasual();
                    default:     return new clsPrivateCasual();
                }
            }
        }

        // --- Employee hierarchy (uses factory to obtain grade and appointment products) ---
        public abstract class clsEmployee
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
            private clsAppointmentType _oAppointment;

            public clsEmployee()
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

            // Convenience constructor: build grade and appointment via factory
            public clsEmployee(clsUniversityFactory factory, double basicSalary, string appointmentCode) : this()
            {
                _nBasicSalary = basicSalary;
                var gradeCode = DetermineGrade(basicSalary);
                _oGrade       = factory.CreateGrade(gradeCode, basicSalary);
                _oAppointment = factory.CreateAppointment(appointmentCode);
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
            public clsAppointmentType Appointment
            {
                get
                {
                    return _oAppointment;
                }
                set
                {
                    _oAppointment = value;
                }
            }

            public double GetBonus()
            {
                return new clsSalaryCalculator(_nBasicSalary, _oAppointment).getBonus();
            }

            public abstract void WriteInfo();

            // Determine grade code from salary ranges
            protected static string DetermineGrade(double basicSalary)
            {
                if (basicSalary >= 100000) return "A";
                if (basicSalary >= 80000)  return "B";
                if (basicSalary >= 50000)  return "C";
                return "D";
            }
        }

        public class clsTeacher : clsEmployee
        {
            private int _nDepartmentID;
            private int _nPapers;
            private clsDepartment _oDepartment;
            List<clsEmployee> oEmployeeList;

            public clsTeacher() : base()
            {
                _nDepartmentID = 0;
                _nPapers = 0;
                oEmployeeList = new List<clsEmployee>();
            }

            // Construct via factory
            public clsTeacher(clsUniversityFactory factory, double basicSalary, string appointmentCode) : base(factory, basicSalary, appointmentCode)
            {
                oEmployeeList = new List<clsEmployee>();
            }

            public void Add(clsEmployee oEmployee)
            {
                oEmployeeList.Add(oEmployee);
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

            private void getTotalSubordinateSalaries()
            {
                double nTotalSalary = 0.0;
                foreach (clsEmployee oEmployee in oEmployeeList)
                {
                    nTotalSalary += oEmployee.Grade.getHouseRentConveyance();
                }
                Console.WriteLine("Sub Sal WO Bonus:  " + nTotalSalary);
            }

            public override void WriteInfo()
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

                getTotalSubordinateSalaries();

                Console.WriteLine("Basic Salary:      " + this.BasicSalary);
                Console.WriteLine("House Rent + Conv: " + this.Grade.getHouseRentConveyance());
            }
        }

        public class clsOfficer : clsEmployee
        {
            private string _sOffice;
            private bool _bAssoMember;

            public clsOfficer() : base()
            {
                _sOffice = "";
                _bAssoMember = false;
            }

            public clsOfficer(clsUniversityFactory factory, double basicSalary, string appointmentCode) : base(factory, basicSalary, appointmentCode) { }

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

            public override void WriteInfo()
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
            }
        }

        public class clsStaff : clsEmployee
        {
            private double _nOverTime;

            public clsStaff() : base() { _nOverTime = 0; }
            public clsStaff(clsUniversityFactory factory, double basicSalary, string appointmentCode) : base(factory, basicSalary, appointmentCode) { }

            public double OverTime { get { return _nOverTime; } set { _nOverTime = value; } }

            public override void WriteInfo()
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
            }
        }

        static void Main(string[] args)
        {
            clsUniversityFactory publicFactory = new Public_UniversityFactory();
            clsUniversityFactory privateFactory = new Private_UniversityFactory();

            // arrays similar to legacy demo
            clsEmployee[] oEmployees = new clsEmployee[4];
            clsSalaryCalculator[] oSCalcs = new clsSalaryCalculator[4];

            // Teacher1 - use public factory, salary 100000, permanent
            clsTeacher oTeacher1 = new clsTeacher(publicFactory, 100000, "PERM");
            oTeacher1.Name = "Nasim";
            oTeacher1.DateofBirth = Convert.ToDateTime("01/01/1979");
            oTeacher1.Sex = 'M';
            oTeacher1.ParmanentAddress = "Magura";
            oTeacher1.CurrentAddress = "Mirpur";
            oTeacher1.Phone = "01730016854";
            oTeacher1.Designation = "Assistant Director";
            oTeacher1.DepartmentID = 1;
            oTeacher1.Papers = 2;

            oEmployees[0] = oTeacher1;
            oSCalcs[0] = new clsSalaryCalculator(oTeacher1.BasicSalary, oTeacher1.Appointment);

            // Teacher2 - use public factory, salary 100000, temporary
            clsTeacher oTeacher2 = new clsTeacher(publicFactory, 100000, "TEMP");
            oTeacher2.Name = "Rahman";
            oTeacher2.DateofBirth = Convert.ToDateTime("01/01/1979");
            oTeacher2.Sex = 'M';
            oTeacher2.ParmanentAddress = "Magura";
            oTeacher2.CurrentAddress = "Mirpur";
            oTeacher2.Phone = "01730016854";
            oTeacher2.Designation = "Lecturer";
            oTeacher2.DepartmentID = 2;
            oTeacher2.Papers = 2;

            oEmployees[1] = oTeacher2;
            oSCalcs[1] = new clsSalaryCalculator(oTeacher2.BasicSalary, oTeacher2.Appointment);

            // Officer - use private factory, salary 100000, casual
            clsOfficer oOfficer = new clsOfficer(privateFactory, 100000, "CAS");
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
            oSCalcs[2] = new clsSalaryCalculator(oOfficer.BasicSalary, oOfficer.Appointment);

            // Staff - use private factory, salary 50000, permanent
            clsStaff oStaff = new clsStaff(privateFactory, 50000, "PERM");
            oStaff.Name = "Kuddus";
            oStaff.DateofBirth = Convert.ToDateTime("01/01/1980");
            oStaff.Sex = 'M';
            oStaff.ParmanentAddress = "Dinajpur";
            oStaff.CurrentAddress = "Kalyanpur";
            oStaff.Phone = "01712345678";
            oStaff.Designation = "Sweeper";
            oStaff.OverTime = 10.75;

            oEmployees[3] = oStaff;
            oSCalcs[3] = new clsSalaryCalculator(oStaff.BasicSalary, oStaff.Appointment);

            // demonstrate
            for (int i = 0; i < 4; i++)
            {
                oEmployees[i].WriteInfo();
                Console.WriteLine("Bonus Salary:      " + oSCalcs[i].getBonus());
                double nTotalSalary = oEmployees[i].BasicSalary + oEmployees[i].Grade.getHouseRentConveyance() + oSCalcs[i].getBonus();
                Console.WriteLine("Total Salary:      " + nTotalSalary);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
