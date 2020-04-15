# Overview of Entity Framework and Linq
## 1. Create and Use EDM (Entity Data Models)
### ADO.NET Entity Framework and Entity Data Model Tools
- C# classes (the **model** classes)
- SQL Tables (the **database** objects)
#### The ADO.NET **Entity Framework**:
- Provides **EDM**s: Models to map **database tables** and **queries** to .NET framework **objects**.
- Provides **Entity SQL**: Storage-independent query language to query and manipulate EDM constructs.
- Provides **Object Services**: Services to work with CLR objects in a conceptual model.
- Supports Writing code against a **Conceptual model**.
- Supports **easy updating** of apps to a **different data source**.
- Supports writing code **independent** fromt the **storage system**.
- Supports writing **data access code** supporting **Compile-Time, Type-Checking** and **Syntax-Checking**.
#### The ADO.NET **Entity Data Model Tools**:
- Support **Database-First** Design by using the **Entity Data Model Wizard**.
- Support **Code-First** Design by using the **Generate Database Wizard**.
- Include the **Entity Data Model Designer**: for **graphically creating** and relating entities in a model.

|              Wizard               |  Description  |
| --------------------------------- |-------------------------------------------------------------------------------------------------------|
|   **Entity Data Model Wizard**    |  Generate **new conceptual model** from existing data source by using the **database-first** design method.|
|      **Update Model Wizard**      |  Update **existing conceptual model** with changes made to the data source where it's based. |
|   **Generate Database Wizard**    |  Generate database from conceptual model designed in the Entity Data Model Designer by using the **code-first** design method. |
### Customize Generated Classes
- When using the EDM Wizard to create a model, it automatically generates classes exposing entities in the model to your app code.
- **DO NOT** Modify the automatically generated classes in a model.
1. Code will be **Overwritten** as classes being **regenerated** when you run the Update Model Wizard.
2. The generated classes are defined as **partial** classes, therefore, you may extend them to add custom functionalities.
3. Use partial classes and partial methods to add business functionality to the generated classes.
### Read and Modify Data using EF
- **System.Data.Entity.DbContext** class:
1. **Read** Data: **DbSet(TEntity)** class implements the **IEnumerable** interface.
```cs
            FourthCoffeeEntities myDBContext = new FourthCoffeeEntities();
            foreach(Employee item in myDBContext.Employees)
            {
                Console.WriteLine(item.FirstName);
                Console.WriteLine(item.LastName);
                Console.WriteLine(item.JobTitle);
                Console.WriteLine("====================");
                
            }

            foreach (var item in myDBContext.JobTitles)
            {
                Console.WriteLine(item.Job);
                Console.WriteLine(item.JobTitleId);
                Console.WriteLine("====================");
            }
```
2. **Modify** Data: **Explicitly** apply changes. **Note: DBContext.SaveChanges();**
```cs
            var employeeToChange = myDBContext.Employees.First(emp => emp.LastName == "Adams");
            if (employeeToChange != null)
            {
                employeeToChange.FirstName = "Xingyi";
                employeeToChange.LastName = "Zhang";
                myDBContext.SaveChanges();
            }
```
## 2. Query Data by using LINQ (Language-Integrated Query)
### Query Data
- LINQ is an **alternative** to using the EF for querying data, it supports **Complile-Time Syntax-Checking and Type-Checking**.
- Use LINQ to:
1. Query a **range of data sources**, inc. .NET Framework collections, SQL Server Databases, ADO.NET Data Sets, XML docs
2. Query **ANY data source that implements the IEnumerable interface**, syntax does not change regardless of type of the data sources.
3. Select Data; Filter Data by Row / Column.
```cs
        IQueryable<Employee> myself = from emp in myDBContext.Employees
                                      where emp.FirstName=="Alex"
                                      select emp;
        Console.WriteLine("all employees with first name alex:");
        foreach(var emp in myself)
            Console.WriteLine(emp.FirstName + " " + emp.LastName);


        IQueryable<TwoColumns> selectSomeColumns = from emp in myDBContext.Employees
                        select new TwoColumns() { DOB = emp.DateOfBirth, FirstName = emp.FirstName };
        foreach(var item in selectSomeColumns)
            Console.WriteLine(item.DOB + " " + item.FirstName);
```
- Query Data using **Anonymous** Types to:
1. Filter data by Column;
2. Group Data;
3. Aggregate Data;
4. Navigating Data.
```cs
            var selectSomeColumns2 = from emp in myDBContext.Employees
                                     select new { DOB3 = emp.DateOfBirth,  emp.FirstName };
            /////////////////////////////////////////////////////////
            foreach (var item in selectSomeColumns2)
                Console.WriteLine(item.DOB3 + " " + item.FirstName);


            int numberOfEmployees = (from emp in myDBContext.Employees
                                         select emp).Count();
```
### Query Execution
- **Deferred** Query Execution (Default behavior for most queries)
1. Do **NOT run till user try to use** returned data.
2. Whenever it is executed, it will return the **Latest Information**.
- **Immediate** Query Execution (Default for queries that return a Singleton Value)
\** When defining a LINQ query that returns a **Singleton value** (ave, count, max...) \**
- **Forced** Query Execution (Overrides deferred query execution)
\** .ToArray()/ .ToDictionary()/ .ToList() \**
```cs
            IList<Employee> emp = (from e in FCEntities.Employees
                                   orderby e.LastName
                                   select e).ToList();
```
