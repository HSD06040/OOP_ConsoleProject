using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Item
{
    public abstract class ItemBase
    {
        public string name;
        public string description;

        public abstract void Use();
    }
}
