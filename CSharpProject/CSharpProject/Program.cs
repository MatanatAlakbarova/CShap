using CSharpProject.Models;
using CSharpProject.Utils;
using System;
using System.Collections.Generic;
using static CSharpProject.Models.Pharmacy;
using static CSharpProject.Utils.Helper;

namespace CSharpProject
{
    class Program
    {       
        static void Main(string[] args)
        {
            inputAnswer:
            Helper.Print("Are you controller?yes/no", ConsoleColor.Blue);
            string areController = Console.ReadLine();
            bool isInt = int.TryParse(areController, out int answer);
            if (isInt)
            {
                Helper.Print("Choose from the answers shown", ConsoleColor.Red);
                goto inputAnswer;
            }
            if (areController.ToLower().Trim() == "yes".ToLower().Trim())
            {
            inputControllerName:
                Helper.Print("Enter your name", ConsoleColor.Blue);
                string controllerName = Console.ReadLine();
                isInt = int.TryParse(controllerName, out int name1);
                if (isInt)
                {
                    Helper.Print("Enter the letter", ConsoleColor.Red);
                    goto inputControllerName;
                }
            inputControllerPassword:
                Helper.Print("Enter your password", ConsoleColor.Blue);
                string ControllerPassword = Console.ReadLine();
                isInt = int.TryParse(ControllerPassword, out int pasword);
                if (isInt)
                {
                    Helper.Print("Enter the letter and number", ConsoleColor.Red);
                    goto inputControllerPassword;
                }
                bool isLogin = Login(controllerName, ControllerPassword);
                if (isLogin)
                {
                    Helper.Print("Welcome", ConsoleColor.Green);
                    List<Pharmacy> pharmacies = new List<Pharmacy>();
                    while (true)
                    {
                        foreach (var item in Helper.GetMenu())
                        {
                            Console.Write(item + " ");
                        }
                        string result = Console.ReadLine();
                        isInt = int.TryParse(result, out int menu);
                        if ((isInt && menu >= 1) && (isInt && menu <= 7))
                        {
                            if (menu == 7)
                                break;
                            Menu menus = (Menu)menu;
                            switch (menus)
                            {
                                case Menu.AddPharmacy:
                                    Helper.Print("Enter the name of a pharmacy", ConsoleColor.DarkBlue);
                                    string pharmacyName = Console.ReadLine();
                                    if (pharmacies.Exists(x => x.Name.ToLower().TrimEnd() == pharmacyName.ToLower().TrimEnd()))
                                    {
                                        Helper.Print($"There is a pharmacy with {pharmacyName} name.", ConsoleColor.Red);
                                        goto case Menu.AddPharmacy;
                                    }
                                    Pharmacy pharmacy = new Pharmacy(pharmacyName);
                                    pharmacies.Add(pharmacy);
                                    Helper.Print($"Pharmacy named -{pharmacyName}- was included", ConsoleColor.Green);
                                    break;
                                case Menu.AddDrugType:                                  

                                    if (pharmacies.Count == 0)
                                    {
                                        Helper.Print("Pharmacy not available", ConsoleColor.Red);
                                        goto case Menu.AddPharmacy;
                                    }
                                    inputDrugTypeName:
                                    Helper.Print("Enter Drug type name", ConsoleColor.DarkCyan);
                                    string DrugTypeName = Console.ReadLine();
                                    isInt = int.TryParse(DrugTypeName, out int typeName);
                                    if (isInt)
                                    {
                                        Helper.Print("enter correct drugTypename",ConsoleColor.Red);
                                        goto inputDrugTypeName;
                                    }
                                    DrugType drugType = new DrugType(DrugTypeName);
                                    inputPharmacyName:
                                    Helper.Print("Current pharmacy list", ConsoleColor.Gray);
                                    foreach (var item in pharmacies)
                                    {
                                        Helper.Print(item.ToString(), ConsoleColor.DarkGray);
                                    }
                                    Helper.Print("Include the name of the Pharmacy", ConsoleColor.Gray);
                                    pharmacyName = Console.ReadLine();
                                    Pharmacy existPharmacy = pharmacies.Find(x => x.Name.ToLower() == pharmacyName.ToLower());
                                    if (existPharmacy == null)
                                    {
                                        Helper.Print("Choose from available pharmacies", ConsoleColor.Red);
                                        goto inputPharmacyName;
                                    }                                   
                                    if (existPharmacy.AddDrugType(drugType))
                                    {
                                        Helper.Print("This drug type available", ConsoleColor.Red);
                                        goto inputDrugTypeName;
                                    }
                                    Helper.Print($"{drugType} drug type included", ConsoleColor.Green);
                                    break;
                                case Menu.AddDrug:
                                    if (pharmacies.Count == 0)
                                    {
                                        Helper.Print("Pharmacy not available", ConsoleColor.Red);
                                        goto case Menu.AddPharmacy;
                                    }
                                inputPharmacyName1:
                                    Helper.Print("Current pharmacy list", ConsoleColor.Gray);
                                    foreach (var item in pharmacies)
                                    {
                                        Helper.Print(item.ToString(), ConsoleColor.DarkGray);
                                    }
                                    Helper.Print("Include the name of the Pharmacy", ConsoleColor.Gray);
                                    pharmacyName = Console.ReadLine();
                                    existPharmacy = pharmacies.Find(x => x.Name.ToLower() == pharmacyName.ToLower());
                                    if (existPharmacy == null)
                                    {
                                        Helper.Print("Choose from available pharmacies", ConsoleColor.Red);
                                        goto inputPharmacyName1;
                                    }                                                                    
                                    InputDrugTypes:
                                    Helper.Print("Current DrugType list", ConsoleColor.Gray);                                  
                                    foreach (var item in existPharmacy.ShowDrugTypeItems())
                                    {
                                        Helper.Print(item.ToString(), ConsoleColor.DarkGray);
                                    }
                                    Helper.Print("Choose drug type", ConsoleColor.DarkGray);
                                    string drugType1 = Console.ReadLine();
                                    DrugType existDrugType = existPharmacy.ShowDrugTypeItems().Find(x => x.TypeName.ToLower() ==
                                    drugType1.ToLower());
                                    if (existDrugType == null)
                                    {
                                        Helper.Print("Choose from available GrugTypes", ConsoleColor.Red);
                                        goto InputDrugTypes;
                                    }
                                    Helper.Print("Enter the name of drug", ConsoleColor.DarkGray);
                                    string drugName = Console.ReadLine();                                   
                                    inputDrugPrice:
                                    Helper.Print("enter price of drug", ConsoleColor.DarkGray);
                                    string drugPrice1 = Console.ReadLine();
                                    isInt = int.TryParse(drugPrice1, out int drugPrice);
                                    if (!isInt)
                                    {
                                        Helper.Print("Enter current price(with number)", ConsoleColor.Red);
                                        goto inputDrugPrice;
                                    }
                                    inputDrugount:
                                    Helper.Print("enter count of drug", ConsoleColor.DarkGray);
                                    string drugCount1 = Console.ReadLine();
                                    isInt = int.TryParse(drugCount1, out int drugCount);
                                    if (!isInt)
                                    {
                                        Helper.Print("Enter current count(with number)", ConsoleColor.Red);
                                        goto inputDrugount;
                                    }
                                    Helper.Print("Enter Information of drug", ConsoleColor.DarkCyan);
                                    string information = Console.ReadLine();
                                    Drug drug = new Drug(drugName, existDrugType, drugPrice, drugCount, information);
                                    existPharmacy.AddDrug(drug);
                                    Helper.Print($"{drugName} named drug Included to {existPharmacy} ", ConsoleColor.Green);
                                    break;
                                case Menu.ShowDrugItems:
                                    if (pharmacies.Count == 0)
                                    {
                                        Helper.Print("Pharmacy not available", ConsoleColor.Red);
                                        goto case Menu.AddPharmacy;
                                    }
                                inputPharmacyName2:
                                    Helper.Print("Current pharmacy list", ConsoleColor.Gray);
                                    foreach (var item in pharmacies)
                                    {
                                        Helper.Print(item.ToString(), ConsoleColor.DarkGray);
                                    }
                                    Helper.Print("Include the name of the Pharmacy", ConsoleColor.Gray);
                                    pharmacyName = Console.ReadLine();
                                    existPharmacy = pharmacies.Find(x => x.Name.ToLower() == pharmacyName.ToLower());
                                    if (existPharmacy == null)
                                    {
                                        Helper.Print("Choose from available pharmacies", ConsoleColor.Red);
                                        goto inputPharmacyName2;
                                    }                              
                                    Helper.Print("list of Drugs", ConsoleColor.Blue);
                                    foreach (var item in existPharmacy.ShowDrugItems())
                                    {
                                        Helper.Print(item.ToString(), ConsoleColor.DarkGray);
                                    }
                                    break;
                                case Menu.InfoDrug:
                                    if (pharmacies.Count == 0)
                                    {
                                        Helper.Print("Pharmacy not available", ConsoleColor.Red);
                                        goto case Menu.AddPharmacy;
                                    }
                                inputPharmacyName3:
                                    Helper.Print("Current pharmacy list", ConsoleColor.Gray);
                                    foreach (var item in pharmacies)
                                    {
                                        Helper.Print(item.ToString(), ConsoleColor.DarkGray);
                                    }
                                    Helper.Print("Include the name of the Pharmacy", ConsoleColor.Gray);
                                    pharmacyName = Console.ReadLine();
                                    existPharmacy = pharmacies.Find(x => x.Name.ToLower() == pharmacyName.ToLower());
                                    if (existPharmacy == null)
                                    {
                                        Helper.Print("Choose from available pharmacies", ConsoleColor.Red);
                                        goto inputPharmacyName3;
                                    }
                                    inputDrugNamee:
                                    Helper.Print("list of Drugs", ConsoleColor.Blue);
                                    foreach (var item in existPharmacy.ShowDrugItems())
                                    {
                                        Helper.Print(item.ToString(), ConsoleColor.DarkGray);
                                    }
                                    string drugName1 = Console.ReadLine();
                                    var drugname2= existPharmacy.InfoDrug(drugName1);
                                    if (drugname2==null)
                                    {
                                        Helper.Print("include Correct drug name ", ConsoleColor.Red);
                                        goto inputDrugNamee;
                                    }
                                    Helper.Print($"{drugname2.Information}", ConsoleColor.DarkGreen);
                                 break;
                                case Menu.SaleDrug:
                                    if (pharmacies.Count == 0)
                                    {
                                        Helper.Print("Pharmacy not available", ConsoleColor.Red);
                                        goto case Menu.AddPharmacy;
                                    }
                                inputPharmacyName5:
                                    Helper.Print("Current pharmacy list", ConsoleColor.Gray);
                                    foreach (var item in pharmacies)
                                    {
                                        Helper.Print(item.ToString(), ConsoleColor.DarkGray);
                                    }
                                    Helper.Print("Include the name of the Pharmacy", ConsoleColor.Gray);
                                    pharmacyName = Console.ReadLine();
                                    existPharmacy = pharmacies.Find(x => x.Name.ToLower() == pharmacyName.ToLower());
                                    if (existPharmacy == null)
                                    {
                                        Helper.Print("Choose from available pharmacies", ConsoleColor.Red);
                                        goto inputPharmacyName5;
                                    }
                                    inputDrugCount:
                                    Helper.Print("list of Drugs", ConsoleColor.Blue);
                                    foreach (var item in existPharmacy.ShowDrugItems())
                                    {
                                        Helper.Print(item.ToString(), ConsoleColor.DarkGray);
                                    }
                                    Helper.Print("Enter the name of drug", ConsoleColor.Cyan);
                                    string drugName2 = Console.ReadLine();
                                    inputDrugCount1:
                                    Helper.Print("Enter the count of drug", ConsoleColor.Cyan);
                                    string count1 = Console.ReadLine();
                                    isInt = int.TryParse(count1, out int count);
                                    if (!isInt)
                                    {
                                        Helper.Print("Enter correct the number", ConsoleColor.Red);
                                        goto inputDrugCount1;
                                    }               
                                    inputdrugMoney:
                                    Helper.Print("Enter the money of drug", ConsoleColor.Cyan);
                                    string money1 = Console.ReadLine();
                                    isInt = double.TryParse(money1, out double money);
                                    if (!isInt)
                                    {
                                        Helper.Print("Enter correct the number", ConsoleColor.Red);
                                        goto inputdrugMoney;
                                    }
                                    var saledDrug = existPharmacy.SaleDrug(drugName2, count, money);
                                    if (saledDrug==ReturnType.NullError)
                                    {
                                        Helper.Print("There isn't this drug ", ConsoleColor.Red);
                                        Helper.Print("Would you like to go to another pharmacy?yes/no", ConsoleColor.Blue);
                                        string otherPharmacy = Console.ReadLine();
                                        if (otherPharmacy.ToLower() == "yes".ToLower())
                                        {
                                            goto case Menu.SaleDrug;
                                        }
                                        break;
                                    }
                                    if(saledDrug == ReturnType.CountError )
                                    {                                                                                
                                            Helper.Print("The desired number of drugs is not available", ConsoleColor.Red);
                                            Helper.Print("Re-apply depending on the number of medications", ConsoleColor.Blue);
                                            goto inputDrugCount;                                      
                                    }
                                    if(saledDrug == ReturnType.MoneyError)
                                    {                                        
                                            Helper.Print("you don't have enough money", ConsoleColor.Red);
                                            break;                                       
                                    }                                                                                                                                 
                                    Helper.Print("The sale has been successfully implemented", ConsoleColor.Green);                                                                     
                                    break;                                
                            }                           
                        }
                        else
                        {
                            Helper.Print("Choose from the numbers shown", ConsoleColor.Red);
                        }
                    }
                }
                else
                {
                    Helper.Print("You aren't controller,you cannot log in!", ConsoleColor.Red);
                    return;
                }
            }
            else 
            {
                Helper.Print("Only the controller can enter", ConsoleColor.Red);
                return;
            }
        }
    }
}
