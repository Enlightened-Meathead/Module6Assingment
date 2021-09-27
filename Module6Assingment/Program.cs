using System;
using System.Collections.Generic;
using System.Xml;

namespace Module6Assingment
{
    class Program
    {
        static void Main(string[] args)
        {
            

            char command = 'z';
            double total = 0;
            List<Item> vendingItems = new List<Item>();
            
            Console.WriteLine(
                "++++++++++++++++++++++++++++++\nWelcome to the vending machine.\n++++++++++++++++++++++++++++++");

            do
            {
                Console.Write(
                    "What would you like to do? (A - add items, B - buy items, V- view inventory and money collected, E - exit the vending machine): ");
                command = Console.ReadLine().ToUpper().Trim()[0];
                Console.WriteLine();
                switch (command)
                {
                    case 'A':
                        string name = "";
                        do
                        {
                            int quantity = 0;
                            double price = 0;
                            Console.Write("Item to stock (NA when done): ");
                            name = Console.ReadLine();
                            if (name.ToUpper() != "NA")
                            {
                                while (quantity == 0)
                                {
                                    Console.Write("Quantity to stock: ");
                                    Int32.TryParse(Console.ReadLine(), out quantity);
                                    if (quantity == 0)
                                    {
                                        Console.WriteLine("Please enter a valid quantity.");
                                    }
                                }

                                while (price == 0)
                                {
                                    Console.Write("Price per item: ");
                                    Double.TryParse(Console.ReadLine(), out price);
                                    if (price == 0)
                                    {
                                        Console.WriteLine("Please enter a valid price.");
                                    }
                                }

                                vendingItems.Add(new Item(name, quantity, price));
                            }
                        }

                            while (name.ToUpper() != "NA");

                            Console.WriteLine("\n ==========================\n");
                        break;
                    case 'B':
                        Console.WriteLine("Vending Machine");
                        foreach (var i in vendingItems)
                        {
                            Console.WriteLine($"{vendingItems.IndexOf(i) + 1} - {i.GetItemName()} {i.GetPrice():C}, {i.GetItemQuantity()} available");
                        }
                        
                        string input = "";
                        do
                        {
                            Console.Write("Item to buy (Enter number on above list, NA to end): ");
                            input = Console.ReadLine().Trim();
                            if (input.ToUpper() != "NA")
                            {
                                Int32.TryParse(input, out int inp);
                                if ( inp > 0)
                                {
                                    int quantity = 0;
                                    while (quantity == 0)
                                    {
                                        Console.Write("How many would you like to buy? ");
                                        Int32.TryParse(Console.ReadLine(), out quantity);
                                        int withdrawlimit = vendingItems[(Convert.ToInt32(input) - 1)].GetItemQuantity();
                                        if (quantity == 0 || quantity > withdrawlimit)
                                        {
                                            Console.WriteLine("Please enter a valid quantity.");
                                            quantity = 0;
                                        }
                                    }
                                    vendingItems[(Convert.ToInt32(input) - 1)].SetItemQuantity(quantity);
                                    total = total + (vendingItems[(Convert.ToInt32(input) - 1)].GetPrice() * quantity);
                                }
                                Console.WriteLine("Invalid input.");
                            }

                        } while (input.ToUpper() != "NA");
                        Console.WriteLine("\n ==========================\n");
                        break;
                    case 'V':
                        Console.WriteLine("Inventory and Sales");
                        foreach (var i in vendingItems)
                        {
                            Console.WriteLine($" {i.GetItemQuantity()} {i.GetItemName()}");
                        }
                        Console.WriteLine($"{total:C} collected from sales.\n ==========================\n");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input.\n");
                        break;
                }
            } while (command != 'E');

            Console.Write("Have a great day!");
        }
    }
}