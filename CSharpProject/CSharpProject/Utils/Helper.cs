using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpProject.Models.Pharmacy;

namespace CSharpProject.Utils
{
    static class Helper
    {
        public static void Print(string text,ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
       public static IEnumerable<string> GetMenu()
        {
            foreach (var item in Enum.GetValues(typeof(Menu)))
            {
                yield return $"{(int)item}- {item} " ;
            }
        }      
        public static bool Login(string controller,string password)
        {
            string existController = "EshginKazimov";
            string existPassword = "EshginKazimov1";
            bool isAuth = false;
            if (controller.ToLower().Equals(existController.ToLower())&& password.ToLower().Equals(existPassword.ToLower()))
            {
                isAuth = true;
            }
            return isAuth;
        }    
        public enum Menu
        {
            AddPharmacy = 1,
            AddDrugType, 
            AddDrug,
            ShowDrugItems,        
            InfoDrug,
            SaleDrug,
            Exit
        }
    }
}
