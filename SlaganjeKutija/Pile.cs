using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlaganjeKutija
{
    public class Pile
    {
        public List<Box> boxes;

        public Pile() {
        this.boxes = new List<Box>();
        }

        public int ReturnHeightOfPile()
        {
            return this.boxes.Sum(b => b.height);
        }

        public void AddToPile(Box box)
        {
            this.boxes.Add(box);
        }

        public string ToString()
        {
            string s = "{";
            foreach (Box box in this.boxes) {
                s += box.ToString();
            }
            s += "}";
            return s;
        }
    }
}
