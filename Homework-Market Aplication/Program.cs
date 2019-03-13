using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_Market_Aplication.Classes;

namespace Homework_Market_Aplication
{
    class Program
    {
        static void Buyer(Product[] products, string buyerInput, Cart cartOfBuyer, Person buyer)
        {
            
            while (buyerInput != "exit")
            {
                bool isNameOfProductInList = false;
                for (var i = 0; i < products.Length; i++)
                {
                    if (buyerInput.ToLower() == products[i].Name.ToLower())
                    {
                        isNameOfProductInList = true;

                        Product ListOfProducts = new Product(products[i].Name, products[i].SerialNumber, products[i].Description, products[i].Declaration);                      
                        cartOfBuyer.ListOfProducts.Add(ListOfProducts); 
                        Console.WriteLine("Please select another product!");
                        buyerInput = Console.ReadLine();
                        break;
                        
                    }
                }

                if (isNameOfProductInList == false)
                {
                    Console.WriteLine("There is no such product!Please select another product!");
                    buyerInput = Console.ReadLine();
                }
            }

            if (buyerInput == "exit")
            {
                Console.WriteLine("Press 2: Cash register - Here you can buy your products!");

            }
            Console.ReadLine();

            
        }

        static void Cashier(Person buyer , Cart cartOfBuyer, Product[] products)
        {

            Console.WriteLine($"{buyer.FirstName} {buyer.LastName}:Hello, I like to pay, please!");
            Console.WriteLine("Hello!, of course! tit tit tit.....");

            double sum = 0;
            int minAge = 18;
            int age = AgeBuyer(buyer.DateOfBirth);

            foreach (var product in cartOfBuyer.ListOfProducts)
            {
                for (int i = 0; i < products.Length; i++)
                {
                    if(product.Name == products[i].Name)
                    {
                        if (products[i].Declaration == "Only for adults" && age < minAge)
                        {
                           
                            Console.WriteLine($"Sorry, but you can not pay this product!{products[i].Name} is only for adults!");
                             Console.WriteLine($"{buyer.FirstName} {buyer.LastName}: Aha,It's ok.");
                        }
                        else
                        {
                            sum = sum + int.Parse(products[i].Description);
                        }

                    }
                   

                }

            }
            double payment = SumWithDiscount(sum, buyer);                               
            Console.WriteLine("Your total price is {0:C}", payment);          
            Console.WriteLine("Thank you for shopping at our store!Bye!");           
            Console.WriteLine($"{buyer.FirstName} {buyer.LastName}: Bye!");
            Console.ReadLine();       
        }
 
        static double SumWithDiscount(double sum, Person buyer)
        {
            if (sum > 50 && buyer.BuyerCard == true)
            {

                sum = sum - CalculateDiscountIfBuyerHaveLoyalCard(sum, buyer);
                return sum;
            }
            else if (sum > 50)
            {

                sum = sum - CalculateDiscountIfCostIsBigger(sum, buyer);
                return sum;
            }
            else
            {
                return sum;
            }

        }

        static double CalculateDiscountIfCostIsBigger(double sum, Person buyer)
        {
            double discount = sum * 0.10;
            return discount;
        }
        static double CalculateDiscountIfBuyerHaveLoyalCard(double sum, Person buyer)
        {
            double discount1 = sum * 0.15 + sum * 0.10;
            return discount1;
        }

        static int AgeBuyer(DateTime birthdate)
        {
            DateTime currentTime = DateTime.Now;
            int age = currentTime.Year - birthdate.Year;
            if (birthdate.Month > currentTime.Month) age--;
            if (birthdate.Month == currentTime.Month && birthdate.Day > currentTime.Day) age--;
            return age;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Market aplication:");
            Console.WriteLine(@"Please enter ""1"" to start with shopping!Thanks and Welcome!");
            int personalInfo;

            while (!Int32.TryParse(Console.ReadLine(), out personalInfo))
            {
                Console.WriteLine("Invalid input! Try again!");
               
            }

            Product[] products = new Product[]
            {
                new Product("Eggs", 10203040, "25","For all users"),
                new Product("Jameson",50607080, "20","Only for adults"),
                new Product("Sprite",90100110, "52","For all users"),
                new Product("Cigarette Rodeo",12013014, "35","Only for adults"),
                new Product("Milk",15016017, "45","For all users")
            };


            if (personalInfo == 1)
            {
                Person buyer = new Person();
                Console.WriteLine("Please enter you first name:");
                buyer.FirstName = Console.ReadLine();

                Console.WriteLine("Please enter you last name:");
                buyer.LastName = Console.ReadLine();

                Console.WriteLine("Please enter you date of birth in format dd/MM/yyyy:");
                buyer.DateOfBirth = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Please enter you security number SSN (max 9 digits):");
                buyer.SecurityNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter if you have buyerCard(true/false):");
                buyer.BuyerCard = bool.Parse(Console.ReadLine());
          
                Console.WriteLine("List of Products:");

                for (var i = 0; i < products.Length; i++)
                {
                    Console.WriteLine($"{products[i].Name}");
                    

                }
                Console.WriteLine(@"Please select a product of the list and Write ""exit"" if the selection is finished:");
            

                Cart cartOfBuyer = new Cart();

                string buyerInput = Console.ReadLine();
                  
                Buyer(products, buyerInput, cartOfBuyer, buyer);

                personalInfo = 2;
                
                Cashier(buyer,cartOfBuyer,products);
               
            }
          Console.ReadLine();
        }
                   
    }
}