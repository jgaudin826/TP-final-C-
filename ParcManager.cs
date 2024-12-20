using System;
using System.Text.RegularExpressions;
using TPFinal.Models;

namespace TPFinal
{
    public class ParcManager
    {   
        public Parc CarParc {get; set;}
        private string LicensePlatePattern = @"^[A-Z]{2}-\d{3}-[A-Z]{2}$";

        public ParcManager() //Constructor
        {
            this.CarParc = new Parc();
        }

        public void Menu()
        {
            Console.Clear();

            while(true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("WELCOME TO THE CAR PARC");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Select what you would like to do:");
                Console.ResetColor();
                Console.WriteLine("1. Add a new car to the parc.");
                Console.WriteLine("2. Remove a car from the parc.");
                Console.WriteLine("3. List all cars in the parc.");
                Console.WriteLine("4. Rent a car.");
                Console.WriteLine("5. Return a car.");
                Console.WriteLine("6. Quit the program.");

                if(int.TryParse(Console.ReadLine(),out int userOption)){
                    switch(userOption){
                        case 1:
                            Console.Clear();

                            while(true)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("Add a new car the car parc | enter 'q' to quit");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Enter the car's brand from this selected list :");
                                Console.ResetColor();
                                foreach (var brand in Enum.GetNames(typeof(Brands)))
                                {
                                    Console.WriteLine("- " + brand);
                                }

                                string? inputBrand = Console.ReadLine();
                                if (inputBrand == "q") {
                                    Console.Clear();
                                    Console.WriteLine("You've quit the process");
                                    break;
                                }

                                if (Enum.TryParse(inputBrand, out Brands chosenBrand))
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("Add a new car the car parc | enter 'q' to quit");
                                    Console.ResetColor();
                                    Console.WriteLine($"Selected Brand : {chosenBrand}");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Enter the car's model from this selected list :");
                                    Console.ResetColor();

                                    string enumName = "TPFinal.Models." + chosenBrand + "Models";
                                    Type? enumType = Type.GetType(enumName);

                                    if (enumType != null && enumType.IsEnum)
                                    {
                                        foreach (var model in Enum.GetNames(enumType))
                                        {
                                            Console.WriteLine("- " + model);
                                        }
                                        
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Internal Error: no models found for this car brand");
                                        Console.ResetColor();
                                        break;
                                    }

                                    string? inputModel = Console.ReadLine();
                                    if (inputModel == "q") {
                                        Console.Clear();
                                        Console.WriteLine("You've quit the process");
                                        break;
                                    }

                                    if (Enum.TryParse(enumType, inputModel, out object? chosenModel))
                                    {
                                        Console.Clear();

                                        while(true)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                            Console.WriteLine("Add a new car the car parc | enter 'q' to go back");
                                            Console.ResetColor();
                                            Console.WriteLine($"Selected Brand : {chosenBrand}");
                                            Console.WriteLine($"Selected Model : {chosenModel}");
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.WriteLine("Enter a French license plate (format: AA-000-AA):");
                                            Console.ResetColor();
                                            
                                            string? licensePlate = Console.ReadLine();
                                            
                                            if (licensePlate == "q") {
                                                Console.Clear();
                                                break;
                                            }
                                            
                                            if(licensePlate != null && Regex.IsMatch(licensePlate, LicensePlatePattern))
                                            {
                                                if(CarParc.GetCarFromLicensePlate(licensePlate)==null)
                                                {
                                                    Console.Clear();

                                                    while(true)
                                                    {
                                                        
                                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                                        Console.WriteLine("Add a new car the car parc | enter '6' to go back");
                                                        Console.ResetColor();
                                                        Console.WriteLine($"Selected Brand : {chosenBrand}");
                                                        Console.WriteLine($"Selected Model : {chosenModel}");
                                                        Console.WriteLine($"License Plate : {licensePlate}");
                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.WriteLine("Enter the car's year of registration:");
                                                        Console.ResetColor();
                                                        
                                                        if(int.TryParse(Console.ReadLine(),out int carYear)){
                                                            if(1668 <= carYear && carYear <= 2024){
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                                                Console.WriteLine("Add a new car the car parc | enter anything other than 'y' to go back");
                                                                Console.ResetColor();
                                                                Console.WriteLine($"Selected Brand : {chosenBrand}");
                                                                Console.WriteLine($"Selected Model : {chosenModel}");
                                                                Console.WriteLine($"License Plate : {licensePlate}");
                                                                Console.WriteLine($"Registration Year : {carYear}");
                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.WriteLine("Confirm and add car to the parc? Type 'y' to confirm.");
                                                                Console.ResetColor();
                                                                string? confirm = Console.ReadLine();
                                                                if (confirm == "y") {
                                                                    Console.Clear();
                                                                    CarParc.AddANewCar(chosenBrand, chosenModel, licensePlate, carYear);
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine("Successfully added the new car to the car parc.");
                                                                    Console.ResetColor();
                                                                    goto DONE;
                                                                } else {
                                                                    Console.Clear();
                                                                    break;
                                                                }

                                                            }else if(carYear == 6){
                                                                Console.Clear();;
                                                                break;
                                                            } else{
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Error: The year of registration must be between 1668 and 2024.");
                                                                Console.ResetColor();
                                                            }
                                                        } else {
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.Red;  
                                                            Console.WriteLine("Error: input not recognised");
                                                            Console.ResetColor();
                                                        }
                                                    } 
                                                } else {
                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Error: This license plate is already registered to a car in this car parc.");
                                                    Console.ResetColor();
                                                }
                                            } else {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Error: you seem to have inputed a lisence plate that is the wrong format.");
                                                Console.ResetColor();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Error: you seem to have inputed an unknown car model for this brand.");
                                        Console.ResetColor();
                                        break;
                                    }

                                } else {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: you seem to have inputed an unknown car brand.");
                                    Console.ResetColor();
                                    break;
                                }
                            }
                            DONE:
                            break;

                        case 2:
                            Console.Clear();

                            while(true)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("Remove a car from the parc | enter 'q' to quit");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Enter the car's license plate (format: AA-000-AA):");
                                Console.ResetColor();
                                
                                string? licensePlate = Console.ReadLine();
                                if (licensePlate == "q") {
                                    Console.Clear();
                                    Console.WriteLine("You've quit the process");
                                    break;
                                }
                                if(licensePlate != null && Regex.IsMatch(licensePlate, LicensePlatePattern))
                                {
                                    Car? carToRemove = CarParc.GetCarFromLicensePlate(licensePlate);
                                    if(carToRemove!=null)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine("Car to be removed:");
                                        Console.ResetColor();
                                        Console.WriteLine(carToRemove.All_info_car());
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("Confirm and remove the car from the parc? y/n");
                                        Console.ResetColor();
                                        string? confirm = Console.ReadLine();
                                        if (confirm == "y") {
                                            CarParc.RemoveCar(licensePlate);
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Successfully removed the car from the car parc.");
                                            Console.ResetColor();
                                            break;
                                        } else {
                                            Console.Clear();
                                            Console.WriteLine("You've quit the process");
                                            break;
                                        }

                                    } else {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Error: This license plate is not registered to any car in this car parc.");
                                        Console.ResetColor();
                                    }
                                } else {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: you seem to have inputed a lisence plate that is the wrong format.");
                                    Console.ResetColor();
                                }
                            }
                            break;

                        case 3:
                            Console.Clear();
                            
                            while(true)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("List of all cars in the parc:");
                                Console.ResetColor();
                                Console.WriteLine();
                                CarParc.ListAllCars();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Select what you would like to do:");
                                Console.ResetColor();
                                Console.WriteLine("1. Filter by Brand or Model.");
                                Console.WriteLine("2. Search with license plate.");
                                Console.WriteLine("3. List all cars available to rent.");
                                Console.WriteLine("4. Back to the Main Menu.");
                                if(int.TryParse(Console.ReadLine(),out int userInput)){
                                    switch(userInput){
                                        case 1:
                                            Console.Clear();

                                            while(true)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                                Console.WriteLine("Filter cars from the parc | enter 'q' to go back");
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.WriteLine("Enter either part or all of the car's brand or model:");
                                                Console.ResetColor();
                                                
                                                string? filterString = Console.ReadLine();
                                                if (filterString == "q") {
                                                    Console.Clear();
                                                    Console.WriteLine("You've quit the process");
                                                    break;
                                                }
                                                
                                                if(filterString != null){
                                                    Console.WriteLine();
                                                    CarParc.FilterAllCars(filterString);
                                                    Console.WriteLine();
                                                    while(true)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.WriteLine("Enter anything to go back:");
                                                        Console.ResetColor();
                                                        
                                                        string? _ = Console.ReadLine();
                                                        Console.Clear();
                                                        break;
                                                    }
                                                } else { 
                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Error: input not recognised.");
                                                    Console.ResetColor();
                                                }
                                            }
                                            break;
                                        case 2:
                                            Console.Clear();

                                            while(true)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                                Console.WriteLine("Search cars from the parc | enter 'q' to go back");
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.WriteLine("Enter either part or all of the license plate you want to find:");
                                                Console.ResetColor();
                                                
                                                string? searchString = Console.ReadLine();
                                                if (searchString == "q") {
                                                    Console.Clear();
                                                    Console.WriteLine("You've quit the process");
                                                    break;
                                                }

                                                if(searchString != null){
                                                    Console.WriteLine();
                                                    CarParc.SearchAllCars(searchString);
                                                    Console.WriteLine();
                                                    while(true)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.WriteLine("Enter anything to go back:");
                                                        Console.ResetColor();
                                                        
                                                        string? _ = Console.ReadLine();
                                                        Console.Clear();
                                                        break;
                                                    }
                                                } else { 
                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Error: input not recognised.");
                                                    Console.ResetColor();
                                                }
                                            }
                                            break;
                                        case 3:
                                            Console.Clear();

                                            while(true)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                                Console.WriteLine("List of all alvailable cars in the parc");
                                                Console.ResetColor();
                                                Console.WriteLine();
                                                CarParc.GetAllAvailableCars();
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.WriteLine("Enter anything to go back:");
                                                Console.ResetColor();
                                                
                                                string? _ = Console.ReadLine();
                                                Console.Clear();
                                                break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    if(userInput == 3){
                                        Console.Clear();
                                        Console.WriteLine("You've quit the process");
                                        break;
                                    }
                                } else {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;  
                                    Console.WriteLine("Error: input not recognised");
                                    Console.ResetColor();
                                }
                                if(userOption == 4){
                                    Console.Clear();
                                    Console.WriteLine("You've quit the process");
                                    break;
                                }
                            }
                            break;

                        case 4:
                            Console.Clear();
                            
                            while(true)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("Rent a car from the parc | enter 'q' to quit");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Enter the car's license plate (format: AA-000-AA):");
                                Console.ResetColor();
                                
                                string? licensePlate = Console.ReadLine();
                                if (licensePlate == "q") {
                                    Console.Clear();
                                    Console.WriteLine("You've quit the process");
                                    break;
                                }
                                if(licensePlate != null && Regex.IsMatch(licensePlate, LicensePlatePattern))
                                {
                                    Car? carToRent = CarParc.GetCarFromLicensePlate(licensePlate);
                                    if(carToRent!=null && !carToRent.IsRented)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine("Car to be rented:");
                                        Console.ResetColor();
                                        Console.WriteLine(carToRent.All_info_car());
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("Confirm and rent the car from the parc? y/n");
                                        Console.ResetColor();
                                        string? confirm = Console.ReadLine();
                                        if (confirm == "y") {
                                            //CarParc.RentCar(licensePlate);
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Successfully rented the car from the car parc.");
                                            Console.ResetColor();
                                            break;
                                        } else {
                                            Console.Clear();
                                            Console.WriteLine("You've quit the process");
                                            break;
                                        }

                                    } else {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Error: This license plate is not registered to any car in this car parc.");
                                        Console.ResetColor();
                                    }
                                } else {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: you seem to have inputed a lisence plate that is the wrong format.");
                                    Console.ResetColor();
                                }
                            }
                            break;

                        case 5:
                            Console.Clear();
                            
                            while(true)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("Return a car to the parc | enter 'q' to quit");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Enter the car's license plate (format: AA-000-AA):");
                                Console.ResetColor();
                                
                                string? licensePlate = Console.ReadLine();
                                if (licensePlate == "q") {
                                    Console.Clear();
                                    Console.WriteLine("You've quit the process");
                                    break;
                                }
                                if(licensePlate != null && Regex.IsMatch(licensePlate, LicensePlatePattern))
                                {
                                    Car? carToReturn = CarParc.GetCarFromLicensePlate(licensePlate);
                                    if(carToReturn!=null && carToReturn.IsRented)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine("Car to be returned:");
                                        Console.ResetColor();
                                        Console.WriteLine(carToReturn.All_info_car());
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("Confirm and return the car to the parc? y/n");
                                        Console.ResetColor();
                                        string? confirm = Console.ReadLine();
                                        if (confirm == "y") {
                                            //CarParc.ReturnCar(licensePlate);
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Successfully returned the car to the car parc.");
                                            Console.ResetColor();
                                            break;
                                        } else {
                                            Console.Clear();
                                            Console.WriteLine("You've quit the process");
                                            break;
                                        }

                                    } else {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Error: This license plate is not registered to any car in this car parc.");
                                        Console.ResetColor();
                                    }
                                } else {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: you seem to have inputed a lisence plate that is the wrong format.");
                                    Console.ResetColor();
                                }
                            }
                            break;

                        default:
                            break;
                    }

                    if(userOption == 6){
                        break;
                    }
                } else {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: input not recognised");
                    Console.ResetColor();
                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Successfully closed the program");
            Console.ResetColor();
        }
    }
}