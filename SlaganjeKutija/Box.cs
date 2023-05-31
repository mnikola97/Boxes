using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlaganjeKutija
{
    public class Box
    {
        public int height { get; }
        public int length { get; }
        
        public int width { get; }
        
        public Box(int length, int height,int width)
        {
            this.height = height;
            this.width = width;
            this.length = length;
        }

        public string ToString()
        {
            return "("+length+","+height+","+width+")";
        }
    }
}
