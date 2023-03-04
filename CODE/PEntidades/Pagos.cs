using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEntidades
{
    public class Pagos
    {

        public Pagos(String AUGBL1)
        {
            this.AUGBL1 = AUGBL1;
        }
        public String AUGBL1 { get; set; }
        public String BELNR1 { get; set; }
        public String BUKRS { get; set; }
        public String GJAHR { get; set; }
    }
}
