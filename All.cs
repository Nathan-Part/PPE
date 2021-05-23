using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE
{
    public class All
    {   
        private static string bdd = "server=localhost;user id=Nathan;database=ppe;Pwd=azerty";
        private static string bdd2 = "server=localhost;user id=Nathan;database=ppe;Pwd=azerty";

        public static string Bdd
        {
            get { return bdd; }
            set { bdd = value; }
        }

        public static string Bdd2
        {
            get { return bdd2; }
            set { bdd2 = value; }
        }



    }
}
