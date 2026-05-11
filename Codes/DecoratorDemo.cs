using System;

namespace DecoratorPattern
{
    public abstract class clsEmployee
    {
        protected string Name { get; set; }
        protected string Designation { get; set; }

        public clsEmployee()
        {
            Name = "";
            Designation = "";
        }
        public abstract void WriteInfo();
    }

    public class clsTeacherPhD : clsEmployee
    {
        public int Papers { get; set; }

        public clsTeacherPhD() : base()
        {
            Papers = 0;
        }

        public override void WriteInfo()
        {
            Console.WriteLine("Teacher Info:");
            Console.WriteLine("-------------------");
            Console.WriteLine("Name:              " + "Dr. " + this.Name);
            Console.WriteLine("Designation:       " + this.Designation);
            Console.WriteLine("Papers:            " + this.Papers);
        }
    }



    // Base Decorator
    public abstract class clsEmployeeDecorator : clsEmployee
    {
        protected clsEmployee _employee;

        // Take the component we want to decorate
        public clsEmployeeDecorator(clsEmployee employee)
        {
            _employee = employee;
        }

        public override void WriteInfo()
        {
            if (_employee != null)
            {
                _employee.WriteInfo();
            }
        }
    }

    // Concrete Decorator: Adds extra responsibilities
    public class clsAdminRoleDecorator : clsEmployeeDecorator
    {
        private string _adminRoleName;
        private double _salary;

        public clsAdminRoleDecorator(clsEmployee employee, string adminRoleName, double Salary) : base(employee)
        {
            _adminRoleName = adminRoleName;
            _salary = Salary;
        }

        public override void WriteInfo()
        {
            base.WriteInfo();

            Console.WriteLine("Added Admin Role:  " + _adminRoleName);
            Console.WriteLine("Salary:    $" + _salary);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            clsEmployee teacher = new clsTeacherPhD
            {
                Name = "Nasim",
                Designation = "Assistant Professor",
                Papers = 20
            };

            Console.WriteLine("=== Normal Base Object ===");
            teacher.WriteInfo();
            Console.WriteLine();

            // 2. Let's decorate the teacher with Head of Department duties dynamically
            clsEmployee hodTeacher = new clsAdminRoleDecorator(teacher, "Head of Department", 500.00);

            Console.WriteLine("=== Dynamically Decorated Object ===");
            hodTeacher.WriteInfo();

            // We can even heavily decorate it again! (e.g., HoD + Provost)
            clsEmployee doublyDecorated = new clsAdminRoleDecorator(hodTeacher, "Provost", 300.00);

            Console.WriteLine("\n=== Double Decorated Object ===");
            doublyDecorated.WriteInfo();
        }
    }
}
