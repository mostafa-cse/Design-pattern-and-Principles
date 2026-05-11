using System;

namespace DecoratorPattern
{
    public abstract class clsBaseTeacher
    {
        public string Name { get; set; }
        public DateTime DateofBirth { get; set; }
        public char Sex { get; set; }
        public string ParmanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string Phone { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public double BasicSalary { get; set; }

        protected clsBaseTeacher()
        {
            Name = string.Empty;
            ParmanentAddress = string.Empty;
            CurrentAddress = string.Empty;
            Phone = string.Empty;
            Designation = string.Empty;
            Department = string.Empty;
        }

        public abstract void WriteInfo();

        public virtual string getResponsibilities(){ return string.Empty;}

        public virtual void WriteResponsibilitySalary(){}

        public virtual double getTotalSalary()
        {
            return BasicSalary;
        }
    }

    public class clsPhDTeacher : clsBaseTeacher
    {
        public int Papers { get; set; }

        public clsPhDTeacher() 
        {
            BasicSalary = 40000;
        }

        public override void WriteInfo()
        {
            Console.WriteLine("Teacher Info (PhD):");
            Console.WriteLine("--------------------");
            Console.WriteLine("Name:               Dr. " + Name);
            Console.WriteLine("DOB:                " + DateofBirth.ToShortDateString());
            Console.WriteLine("Sex:                " + Sex);
            Console.WriteLine("Permanent Address:  " + ParmanentAddress);
            Console.WriteLine("Current Address:    " + CurrentAddress);
            Console.WriteLine("Phone:              " + Phone);
            Console.WriteLine("Designation:        " + Designation);
            Console.WriteLine("Department:         " + Department);
            Console.WriteLine("Papers:             " + Papers);
            Console.WriteLine("Basic Salary:       " + BasicSalary);
        }
    }

    public class clsNonPhDTeacher : clsBaseTeacher
    {
        public string Specialization { get; set; }

        public clsNonPhDTeacher()
        {
            BasicSalary = 20000;
            Specialization = string.Empty;
        }

        public override void WriteInfo()
        {
            Console.WriteLine("Teacher Info (Non-PhD):");
            Console.WriteLine("--------------------");
            Console.WriteLine("Name:               " + Name);
            Console.WriteLine("DOB:                " + DateofBirth.ToShortDateString());
            Console.WriteLine("Sex:                " + Sex);
            Console.WriteLine("Permanent Address:  " + ParmanentAddress);
            Console.WriteLine("Current Address:    " + CurrentAddress);
            Console.WriteLine("Phone:              " + Phone);
            Console.WriteLine("Designation:        " + Designation);
            Console.WriteLine("Department:         " + Department);
            Console.WriteLine("Specialization:     " + Specialization);
            Console.WriteLine("Basic Salary:       " + BasicSalary);
        }
    }

    public abstract class clsTeacherResponsibility : clsBaseTeacher
    {
        protected readonly clsBaseTeacher Teacher;
        protected string ResponsibilityName;
        protected double ResponsibilitySalary;

        protected clsTeacherResponsibility(clsBaseTeacher teacher)
        {
            Teacher = teacher;
            ResponsibilityName = string.Empty;
            ResponsibilitySalary = 0;
        }

        public override void WriteInfo()
        {
            Teacher.WriteInfo();
        }

        public override string getResponsibilities()
        {
            string parentResponsibilities = Teacher.getResponsibilities();
            if (string.IsNullOrWhiteSpace(parentResponsibilities))
            {
                return ResponsibilityName;
            }

            return parentResponsibilities + ", " + ResponsibilityName;
        }

        public override void WriteResponsibilitySalary()
        {
            Teacher.WriteResponsibilitySalary();
            Console.WriteLine(ResponsibilityName + " Salary: " + ResponsibilitySalary);
        }

        public override double getTotalSalary()
        {
            return Teacher.getTotalSalary() + ResponsibilitySalary;
        }
    }

    public class clsChairman : clsTeacherResponsibility
    {
        public clsChairman(clsBaseTeacher teacher)
            : base(teacher)
        {
            ResponsibilityName = "Chairman";
            ResponsibilitySalary = 40000;
        }
    }

    public class clsDean : clsTeacherResponsibility
    {
        public clsDean(clsBaseTeacher teacher)
            : base(teacher)
        {
            ResponsibilityName = "Dean";
            ResponsibilitySalary = 30000;
        }
    }

    public class clsExamController : clsTeacherResponsibility
    {
        public clsExamController(clsBaseTeacher teacher)
            : base(teacher)
        {
            ResponsibilityName = "Exam Controller";
            ResponsibilitySalary = 15000;
        }
    }

     public class clsProvost : clsTeacherResponsibility
    {
        public clsProvost(clsBaseTeacher teacher)
            : base(teacher)
        {
            ResponsibilityName = "Provost";
            ResponsibilitySalary = 5000;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            clsBaseTeacher phdTeacher = new clsPhDTeacher
            {
                Name = "Nasif Hossain Nafi",
                DateofBirth = Convert.ToDateTime("01/01/1995"),
                Sex = 'M',
                ParmanentAddress = "Jashore",
                CurrentAddress = "Dhaka",
                Phone = "01763743829",
                Designation = "Professor",
                Department = "CSE",
                Papers = 12
            };

            clsBaseTeacher phdResponsibilities = new clsExamController(new clsDean(new clsChairman(phdTeacher)));

            phdTeacher.WriteInfo();
            Console.WriteLine("Responsibilities:  " + phdResponsibilities.getResponsibilities());
            phdResponsibilities.WriteResponsibilitySalary();
            Console.WriteLine("Total Salary:      " + phdResponsibilities.getTotalSalary());
            Console.WriteLine();

            clsBaseTeacher nonPhdTeacher = new clsNonPhDTeacher
            {
                Name = "Bappy Rahman",
                DateofBirth = Convert.ToDateTime("01/01/2001"),
                Sex = 'M',
                ParmanentAddress = "Chattogram",
                CurrentAddress = "Jashore",
                Phone = "0187834738",
                Designation = "Lecturer",
                Department = "IPE",
                Specialization = "Product Management"
            };

            clsBaseTeacher nonPhdResponsibilities = new clsProvost(clsExamController(new clsDean(new clsChairman(nonPhdTeacher))));

            nonPhdTeacher.WriteInfo();
            Console.WriteLine("Responsibilities:  " + nonPhdResponsibilities.getResponsibilities());
            nonPhdResponsibilities.WriteResponsibilitySalary();
            Console.WriteLine("Total Salary:      " + nonPhdResponsibilities.getTotalSalary());

            Console.ReadLine();
        }
    }
}