using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProject.Models
{ 
    public partial class  Pharmacy
    {   
        public string Name { get; set; }
        public int Id { get; }
        private int _counter = 0;
       private List<Drug> _drugs;
        private List<DrugType> _drugsType;
        public Pharmacy()
        {
            _counter++;
            Id = _counter;
            _drugs = new List<Drug>();
            _drugsType = new List<DrugType>();
        }
        public Pharmacy(string name):this()
        {
            Name = name;          
        }      
        public override string ToString()
        {
            return  Name;
        }
    }
}
