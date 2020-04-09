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

```
2. Manipulating Files, Directories, File & Directory Paths
3. .Net Framework provides **classes** to interact with **files, directories, and paths**:
``` File; FileInfo; Directory; DirectoryInfo; Path ```
## Serializing and Deserializing Data
## Performing I/O by Using Streams
