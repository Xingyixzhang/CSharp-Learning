using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace IntegrateWithUnmanagedCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // C# is a Strongly Typed language, use compile time checks to help users catch # of errors before runtime.:
            int x = 20;     // x = "MSSA";
            var y = 20;     // y = "MSSA";

            // Dynmic objects: (ex. ViewBag)
            dynamic z = 20;
            z = "MSSA";
            z.MSSA = 3;

            /*
             * Compile time VS Runtime:
             * 
             * Compile time: error indicated before running the code.
             * Runtime time: error when running the code.
             */

            // Add reference for microsoft.office.interop.word and namespace
            // View -> Object browser -> microsoft.office.interop.word -> applicationevent2

            dynamic words = new Application();
            dynamic doc = words.Document.Open(".\\C:\\Users\\xingy\\OneDrive\\Desktop\\MSSA Learning\\Amazon_Leadership_Principles");

            Random rand = new Random();
            int die = rand.Next(1, 7);


            // EXPLICITLY invoke the Dispose Method:
            var word1 = default(ManagedWord);
            try
            {
                word1 = new ManagedWord();
                // Code to use the ManagedWord obj.
            }
            finally
            {
                if (word1 != null) word1.Dispose();
            }

            // IMPLICITLY invoke the Dispose Method:
            /*
             * using statement autometically implement the Dispose method at the end.
             */
            using (var word2 = default(ManagedWord))
            {
                // Code to use the ManagedWord obj.
            }
        }

        class Student
        {
            public Student()
            {
                Console.WriteLine("Student Constructor is called.");
            }
            ~Student()  // Finalizer
            {
                Console.WriteLine("Student Destructor is called.");
            }
        }

        class GraduateStudent: Student
        {
            public GraduateStudent()
            {
                Console.WriteLine("Graduate Student Constructor is called.");
            }
            ~GraduateStudent()
            {
                Console.WriteLine("Graduate Student Destructor is called.");
            }
        }

        public class ManagedWord : IDisposable
        {
            bool _isDisposed;
            public void OpenWordDoc(string filePath)
            {
                if (this._isDisposed)
                    throw new ObjectDisposedException("ManagedWord");
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool isDisposing)
            {
                if (_isDisposed) return;
                if (isDisposing)
                {
                    // Release Only Managed Resources.
                    // ...
                }

                // Always release unmanaged resources.
                // ...

                // Indicate that the obj has been disposed.
                _isDisposed = true;
            }

            // Destructor/ Finalizer:
            ~ManagedWord()
            {
                Dispose(false);
            }
        }
    }
}
