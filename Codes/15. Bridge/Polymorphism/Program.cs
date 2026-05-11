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

        public abstract class clsTourType
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

            public abstract double getTADA();
        }

        public class clsForeignTour : clsTourType
        {

            public clsForeignTour(double nBSalary)
            {
                _sName = "Foreign Tour";
                _nBasicSalary = nBSalary;
            }

            public override double getTADA()
            {
                return _nBasicSalary * 0.5;
            }
        }

        public class clsNationalTour : clsTourType
        {

            public clsNationalTour(double nBSalary)
            {
                _sName = "National Tour";
                _nBasicSalary = nBSalary;
            }

            public override double getTADA()
            {
                return _nBasicSalary * 0.3;
            }
        }

        public class clsLocalTour : clsTourType
        {

            public clsLocalTour(double nBSalary)
            {
                _sName = "Local Tour";
                _nBasicSalary = nBSalary;
            }

            public override double getTADA()
            {
                return _nBasicSalary * 0.1;
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

            protected clsTourType _oTourType;

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

            public clsTourType TourType
            {
                set
                {
                    _oTourType = value;
                }
            }

            public abstract void getTADA();

            public abstract void WriteInfo();      //Public Method
            
            //protected void getTADA()
            //{
            //_oTourType.getTADA();
            //}

            /* public virtual void WriteInfo()      //Public Method
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
                Console.WriteLine("Basic Salary:      " + this.BasicSalary);

                //Console.ReadLine();
            }*/
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

            public override void getTADA()
            {
                Console.WriteLine("Tour Type:        " + _oTourType.Name);
                Console.WriteLine("Amount:           " + _oTourType.getTADA());
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
                Console.WriteLine("Basic Salary:      " + this.BasicSalary);

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

            public override void getTADA()
            {
                Console.WriteLine("Tour Type:        " + _oTourType.Name);
                Console.WriteLine("Amount:           " + _oTourType.getTADA());
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
                Console.WriteLine("Basic Salary:      " + this.BasicSalary);

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

            public override void getTADA()
            {
                Console.WriteLine("Tour Type:        " + _oTourType.Name);
                Console.WriteLine("Amount:           " + _oTourType.getTADA());
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
                Console.WriteLine("Overtime:        " + this.OverTime);
                Console.WriteLine("Basic Salary:      " + this.BasicSalary);

                //Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
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
            oTeacher1.Papers = 50;
            oTeacher1.TourType = new clsForeignTour(oTeacher1.BasicSalary);

            oTeacher1.WriteInfo();
            oTeacher1.getTADA();

            oTeacher1.TourType = new clsNationalTour(oTeacher1.BasicSalary);

            oTeacher1.WriteInfo();
            oTeacher1.getTADA();

            oTeacher1.TourType = new clsLocalTour(oTeacher1.BasicSalary);

            oTeacher1.WriteInfo();
            oTeacher1.getTADA();

            // What will you do if Teachers, Officers and Staffs get different rates for different tours???
            // What will you do if only Teachers get the tours???
            // How can we improve this Program?

            Console.ReadLine();
        }
    }
}