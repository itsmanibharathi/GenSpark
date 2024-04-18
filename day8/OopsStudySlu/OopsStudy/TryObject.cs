using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsStudy
{
    internal class TryObject
    {
        public virtual void run()
        {
            Console.WriteLine("Try Object is running ");
        }

    }

    internal class TryObject2 : TryObject
    {
        public override void run()
        {
            Console.WriteLine("Try Object2 is running ");
        }
    }

    internal class TryObject3 : TryObject2
    {
        public override void run()
        {
            Console.WriteLine("Try Object3 is running ");
        }
    }




}
