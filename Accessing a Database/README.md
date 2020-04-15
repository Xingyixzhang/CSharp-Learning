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
2. **Modify** Data: **Explicitly** apply changes. **Note: DBContext.SaveChanges();**
## 2. Query Data by using LINQ (Language-Integrated Query)
### Query Data

### Query Execution
