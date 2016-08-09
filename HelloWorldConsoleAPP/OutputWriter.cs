using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldConsoleAPP
{
    abstract class OutputWriter
    {
        public abstract void WriteMessage(string msg);
    }

    class OutputWriterToConsole: OutputWriter
    {
        public override void WriteMessage(string msg)
        {
            Console.WriteLine("writing to console: " + msg);
            Console.ReadLine();
        }
    }

    class OutputWriterToDB : OutputWriter
    {
        public override void WriteMessage(string msg)
        {
            Console.WriteLine("writing to DB: " + msg);
            Console.ReadLine();
        }
    }


}
