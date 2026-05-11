Detailed breakdown of all types in this file:

Program.cs

**Overall Design Intent**
1. The code models salary rules as interchangeable policy families.
2. A factory picks a consistent family (Public or Private).
3. Employee objects use those policies without knowing concrete classes.

**1) Program**
Role:
1. Container class for all nested types and Main entry point.

Can do:
1. Run demo flow in Main:
2. Create factories
3. Create employee objects
4. Print salary-related output

Relationships:
1. Has-a: none as instance fields
2. Is-a: normal class (not inheriting custom base type)

**2) IGradePolicy (interface)**
Role:
1. Contract for grade-based allowance rules.

Properties:
1. GradeName: string, read-only label for grade family.

Methods:
1. GetHouseRent(basicSalary): returns house rent amount.
2. GetConveyance(basicSalary): returns conveyance amount.

Can do:
1. Define what every grade policy implementation must provide.

Relationships:
1. Is-a parent abstraction for PublicGradePolicy and PrivateGradePolicy.
2. Used by clsEmployee through composition.

**3) IAppointmentPolicy (interface)**
Role:
1. Contract for appointment-based bonus rule.

Properties:
1. PolicyName: string, read-only appointment label.

Methods:
1. GetBonus(basicSalary): returns bonus amount.

Can do:
1. Define what every appointment policy implementation must provide.

Relationships:
1. Is-a parent abstraction for PublicAppointmentPolicy and PrivateAppointmentPolicy.
2. Used by clsEmployee through composition.

**4) PublicGradePolicy**
Role:
1. Concrete grade policy for public university family.

Properties:
1. GradeName returns Public University Grade.

Methods:
1. GetHouseRent: 50% of basic salary.
2. GetConveyance: 10% of basic salary.

Can do:
1. Calculate public grade allowances.

Relationships:
1. Is-a IGradePolicy.
2. Selected by PublicUniversityFactory.

**5) PrivateGradePolicy**
Role:
1. Concrete grade policy for private university family.

Properties:
1. GradeName returns Private University Grade.

Methods:
1. GetHouseRent: 35% of basic salary.
2. GetConveyance: 8% of basic salary.

Can do:
1. Calculate private grade allowances.

Relationships:
1. Is-a IGradePolicy.
2. Selected by PrivateUniversityFactory.

**6) PublicAppointmentPolicy**
Role:
1. Concrete appointment policy for public family.

Properties:
1. PolicyName returns Government Appointment.

Methods:
1. GetBonus: 100% of basic salary.

Can do:
1. Calculate public bonus.

Relationships:
1. Is-a IAppointmentPolicy.
2. Selected by PublicUniversityFactory.

**7) PrivateAppointmentPolicy**
Role:
1. Concrete appointment policy for private family.

Properties:
1. PolicyName returns Contract Appointment.

Methods:
1. GetBonus: 60% of basic salary.

Can do:
1. Calculate private bonus.

Relationships:
1. Is-a IAppointmentPolicy.
2. Selected by PrivateUniversityFactory.

**8) IUniversityFactory (Abstract Factory interface)**
Role:
1. Defines creation of a related product family.

Methods:
1. CreateGradePolicy(): returns IGradePolicy.
2. CreateAppointmentPolicy(): returns IAppointmentPolicy.

Can do:
1. Ensure client receives matching policy pair from one family.

Relationships:
1. Is-a parent abstraction for PublicUniversityFactory and PrivateUniversityFactory.
2. Consumed by clsEmployee constructor.

**9) PublicUniversityFactory**
Role:
1. Concrete factory for public family.

Methods:
1. CreateGradePolicy returns PublicGradePolicy.
2. CreateAppointmentPolicy returns PublicAppointmentPolicy.

Can do:
1. Produce public-consistent policy set.

Relationships:
1. Is-a IUniversityFactory.
2. Creates concrete products in public family.

**10) PrivateUniversityFactory**
Role:
1. Concrete factory for private family.

Methods:
1. CreateGradePolicy returns PrivateGradePolicy.
2. CreateAppointmentPolicy returns PrivateAppointmentPolicy.

Can do:
1. Produce private-consistent policy set.

Relationships:
1. Is-a IUniversityFactory.
2. Creates concrete products in private family.

**11) clsEmployee (abstract base class)**
Role:
1. Base domain model for employee salary behavior.

Properties:
1. Name: string
2. Designation: string
3. BasicSalary: double

Fields:
1. _gradePolicy: IGradePolicy, readonly
2. _appointmentPolicy: IAppointmentPolicy, readonly

Constructor:
1. Receives IUniversityFactory.
2. Creates and stores both policy objects via factory.

Methods:
1. GetHouseRent: delegates to _gradePolicy.
2. GetConveyance: delegates to _gradePolicy.
3. GetBonus: delegates to _appointmentPolicy.
4. GetTotalSalary: BasicSalary + house rent + conveyance + bonus.
5. WriteInfo: abstract, must be implemented by subclasses.

Can do:
1. Centralize salary logic while allowing role-specific display behavior.

Relationships:
1. Has-a IGradePolicy.
2. Has-a IAppointmentPolicy.
3. Is-a parent of clsTeacher and clsOfficer.

**12) clsTeacher**
Role:
1. Teacher-specific employee type.

Properties:
1. Department: string
2. Papers: int

Constructor:
1. Takes IUniversityFactory and passes to base class.

Methods:
1. WriteInfo override: prints teacher details and computed salary breakdown.

Can do:
1. Represent teacher data plus policy-driven salary output.

Relationships:
1. Is-a clsEmployee.
2. Inherits salary operations from clsEmployee.

**13) clsOfficer**
Role:
1. Officer-specific employee type.

Properties:
1. Office: string

Constructor:
1. Takes IUniversityFactory and passes to base class.

Methods:
1. WriteInfo override: prints officer details and computed salary breakdown.

Can do:
1. Represent officer data plus policy-driven salary output.

Relationships:
1. Is-a clsEmployee.
2. Inherits salary operations from clsEmployee.

**14) Main method execution flow**
Can do sequence:
1. Create two factories: PublicUniversityFactory and PrivateUniversityFactory.
2. Create one clsTeacher using public factory.
3. Create one clsOfficer using private factory.
4. Call WriteInfo on each object.

Resulting behavior:
1. Teacher uses public policy pair.
2. Officer uses private policy pair.
3. Same employee base logic, different outcomes from factory-selected family.

**Relationship Summary (quick map)**
Is-a:
1. PublicGradePolicy is-a IGradePolicy
2. PrivateGradePolicy is-a IGradePolicy
3. PublicAppointmentPolicy is-a IAppointmentPolicy
4. PrivateAppointmentPolicy is-a IAppointmentPolicy
5. PublicUniversityFactory is-a IUniversityFactory
6. PrivateUniversityFactory is-a IUniversityFactory
7. clsTeacher is-a clsEmployee
8. clsOfficer is-a clsEmployee

Has-a:
1. clsEmployee has-a IGradePolicy
2. clsEmployee has-a IAppointmentPolicy
3. Program Main has local references to factories and employees

Can-do operations by layer:
1. Policy interfaces/classes can calculate allowance and bonus rules
2. Factory interface/classes can create matched policy families
3. Employee base can compute salary totals using injected policies
4. Concrete employees can present role-specific info
5. Main can wire families to employees and run the scenario

If you want, I can also provide this as a simple UML class diagram (text format) for your lab report.
