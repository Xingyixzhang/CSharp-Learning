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
## Performing I/O by Using Streams
