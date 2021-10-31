using CSharpProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpProject.Models
{
    public partial class Pharmacy
    {
        public bool AddDrugType(DrugType drugType)
        {
            var searchedDrug = _drugsType.Find(x => x.TypeName == drugType.TypeName);
            if (searchedDrug != null)
            {               
                return true;
            }
            _drugsType.Add(drugType);
            return false;
        }
        public Drug AddDrug(Drug drug)
        {
            var searchedDrug = _drugs.Find(x => x.Name == drug.Name);
            if (searchedDrug == null)
            {
                _drugs.Add(drug);
                return drug;
            }
            searchedDrug.Count += drug.Count;
            return searchedDrug;
        }
        public List<Drug> ShowDrugItems()
        {
            if (_drugs.Count == 0)
            {
                return null;
            }
            return _drugs;         
        }
        public List<DrugType> ShowDrugTypeItems()
        {
            if (_drugsType.Count == 0)
            {
                return null;
            }
            return _drugsType;
        }
        public Drug InfoDrug(string name)
        {
            Drug searchedDrug = _drugs.Find(x => x.Name == name);
            if (searchedDrug != null)
            {
                return searchedDrug;
            }
            return null;
        }
        public ReturnType SaleDrug(string name, int count, double money) 
        {
            var drug = _drugs.Find(x => x.Name == name.ToLower());
            if (drug==null)
            {
                return ReturnType.NullError;
            }                          
            if (drug.Count<count)
            {
                return ReturnType.CountError;
            }                                           
            if (drug.Price*count>money)
            {
                return ReturnType.MoneyError;
            }
               drug.Count -= count;
               return ReturnType.Success;
        }
        public enum ReturnType
        {
            NullError,
            CountError,
            MoneyError,
            Success           
        }
    }
}
