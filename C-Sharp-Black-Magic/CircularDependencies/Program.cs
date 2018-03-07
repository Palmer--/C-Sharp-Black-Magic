using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularDependencies
{
    class Program
    {
        //This code demonstrates how circular dependencies in constructors can result in wierd values.
        //These kinds of heisenbugs can be very hard track down.

        static void Main(string[] args)
        {
            //One would expect val to be 10 here, but we actually end up with 0 due to circular dependency.
            int val = Foo.A;

        }

        static class Foo
        {
            public static int A = Bar.B;
            public static int C = 10;
        }

        static class Bar
        {
            //Since we are getting C but the static constructor for Foo is already running we actually end up with C = 0
            public static int B = Foo.C;
        }
    }
}
