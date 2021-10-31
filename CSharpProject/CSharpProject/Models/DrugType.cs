using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProject.Models
{
    public class DrugType
    {
        public string TypeName { get; set; }
        public int Id { get; }
        private int _counter=0;
        public DrugType()
        {
            _counter++;
            Id = _counter;
        }
        public DrugType(string typename):this()
        {
            TypeName = typename;
        }
        public override string ToString()
        {
            return TypeName;
        }          
    }
}
