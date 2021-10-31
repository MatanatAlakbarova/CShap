using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProject.Models
{
    //Drug - derman classi. Name, Unikal Id, Type(DrugType tipinden), Price, Count olacaq. 
    //ToString - Id, Name, Price ve Count qaytarmalidir.
    public class Drug
    {
        public string Name { get; set; }      
        public DrugType Type { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string Information { get; set; }
        public int Id { get;}
        private int _counter = 0;
        public Drug()
        {          
            _counter++;
            Id = _counter;
        }
        public Drug(string name, DrugType type, int price, int count,string information):this()
        {
            Name = name;
            Type = type;
            Price = price;
            Count = count;
            Information = information;
        }
        public override string ToString()
        {
            return  "Name: "+Name  + " Price: "+Price + " Count:" + Count;
        }        
    }                        
}
