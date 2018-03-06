using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMemoryManipulation
{
    //This program demonstrates a funny quirk about how .NET internally handles string.
    class Program
    {
        static void Main(string[] args)
        {
            string someString = "Hello World!";
            ChangeFirstChar(someString, 'Z');
            //This will print "Zello World!" as expected.
            Console.WriteLine(someString);
            //Suprise! This one will also print "Zello World!"
            Console.Write("Hello World!");
            
            //Since the raw value "Hello World!" is used multiple times in our code, .NET will optimize create 2 references to the same object.
            //This is usually not an issue since string are immutable but by manipulating the memory directly we can
            //change the value for all "Hello World!" strings in our program.
        }

        private static unsafe void ChangeFirstChar(string value, char c)
        {
            //Use unsafe and fixed in order to manipulate the actual string in memory.
            //When manipulating string "normally" you usually end up with a new object
            //since strings are immutable. We are not doing that here.
            fixed (char* p = value)
            {
                p[0] = c;
            }
        }
    }
}
