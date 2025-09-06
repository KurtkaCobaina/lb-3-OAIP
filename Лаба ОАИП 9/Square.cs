using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Лаба_ОАИП_9
{
    public class Square : Rectagle
    {

        public Square( int w, int y, int x, string name) :  base(x, y, w, w, name)
        {
            this.Name = name;
            this.x = x;
            this.y = y;
            this.w = w;
            
        }
    }
}
