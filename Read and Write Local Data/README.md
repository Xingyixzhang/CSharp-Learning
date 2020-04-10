# Reading and Writing Local Data
## Reading and Writing Files
1. Read and Write Data by using the File class;
```cs 
using System.IO;  // containing classes for manipulating files and directories. 
namespace ReadWriteLocalData
{
    class Program{
        static void Main(string[] args){
```
- File class contains atomic read methods:
```cs
            string filePath = "C:\\inputSubdirectory\\inputSchool.txt"; // One may use '\\' or use '\' with '@' before the string.
            //        Or Use: @"C:\inputSubdirectory\inputSchool.txt";
            
            // ReadAllText(...)  -- Read entire content into memory (a string):
            string inputSchool = File.ReadAllText(filePath);
            // ReadAllLines(...) -- Read contents and store each line at a new index in a string array:
            string[] lines = File.ReadAllLines(filePath);
            // ReadAllBytes(...) -- Read contents as binary data and store data in a byte array:
            byte[] rawFile = File.ReadAllBytes(filePath);
```
- File class contains atomic write methods:
```cs
            /*
             * Writexxx: Creates a new file with the new data / Overwrites the existing file with new data.
             * Appendxxx: Creates a new file with new data / Write new data to the end of the existing file.
             */
             // WriteAllText(...): Write the contents of a string to a file, overwrite contents if the file exists.
             string setting = "companyName = Fourth Coffee";
             File.WriteAllText(filePath, setting);
             
             // WriteAllLines(...): Write contents of a string[] to a file, each entry in the string[] represents a new line in the file.
             string[] hosts = { "86.120.1.234", "133.45.32.80", "168.134.35.65" };
             File.WriteAllLines(filePath, hosts);
             
             // WriteAllBytes(...): Write contents of a byte[] to a binary file:
             byte[] rawsetting = {99,111,109,234,97,101,61,25,102,101,101,111,102,104,78};
             File.WriteAllBytes(filePath, rawsetting);
```
2. Manipulating Files, Directories, File & Directory Paths
- **File** class provides **static** members (Copy, Delete, Exists, GetCreationTime ...)
- **FileInfo** class provides **instance** members (CopyTo, Delete, Exists, Length, Extension, DirectoryName ...)
- **Directory** class provide **static** members (CreateDirectory, Delete, Exists, GetDirectories, GetFiles ...)
- **DirectoryInfo** class provides **instance** members (in-memory ...) (Create, Delete, Exists, FullName ...)
- **Path** class encapsulates **file system utility** functions (GetTempPath, HasExtension, GetExtension, GetTempFileName ...)
3. .Net Framework provides **classes** to interact with **files, directories, and paths**:
``` File; FileInfo; Directory; DirectoryInfo; Path ```
## Serializing and Deserializing Data
- Serialization: Object to Stream of Bytes
- Stream of Bytes to (File/ DB/ Memory) to Stream of Bytes
- Deserialization: Stream of bytes to Object
**1. Binary** (**Fast** and **Lightweight**)
```cs
        // Serialize:
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(AliceFile, Alice);
        // Deserialize:
            BinaryFormatter formatter1 = new BinaryFormatter();
            Student Alice1 = formatter1.Deserialize(AliceFile1) as Student;
```
- Preserve the fidelity and state of an  object between diff instances of your app.
- Commonly used when persisting and transporting objects between apps running on **same** platform.
**2. XML** 
```cs
        // Serialize:
            SoapFormatter formatter2 = new SoapFormatter();
            formatter2.Serialize(BobFile, Bob);
        // Deserialize:
            SoapFormatter formatter3 = new SoapFormatter();
            Student Bob1 = formatter3.Deserialize(BobFile1) as Student;
```
- Can be processed by any app regardless of platform.
- Does **NOT** preserve type fidelity, only allows you serialize **public members** that your type exposes.
- **Less Efficient and more Processor intensive** during the serializing, deserializing, and transporting process.
- Commonly used to serialize data that can be transported via the **SOAP** (simple object access protocol) **to and from web** services.
**3. JSON** (Lightweight, Data-interchange format)
```cs
        // Serialize:
            DataContractJsonSerializer formatter4 = new DataContractJsonSerializer(typeof(Student));
            formatter4.WriteObject(DanFile, Dan);
        // Deserialize:
            DataContractJsonSerializer formatter5 = new DataContractJsonSerializer(typeof(Student));
            Student Dan1 = formatter5.ReadObject(DanFile1) as Student;
```
- JSON is a simple text format that is readable and easy to parse by machine, irrespective of platform.
- Commonly used to transport data between Asynchronous JavaScript and XML (AJAX). Unlike XML, JSON is not limited to just communicating within the same domain.
**4.** Create your own Serialable Type.
[Serializable] + ": ISerializable" + Interface Method "GetObjectData" + Default constructor + Define public members you want to serialize.
## Performing I/O by Using Streams
1. A **stream** is a **sequence of bytes**.
