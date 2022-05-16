using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _101CSharpByExemple
{
    public class Singleton
    {
        private Singleton()
        {

        }

        private static Singleton instance;

        public static Singleton Instance
        {
            get {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
           
        }

        private int test;

        public int Test
        {
            get { return test; }
            set { test = value; }
        }



    }

    public class Test
    {
        Singleton a =  Singleton.Instance;
        int b = a.Test;

    }
}
