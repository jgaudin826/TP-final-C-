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
                Console.WriteLine("WELCOME TO THE CAR PARC");
                Console.WriteLine("Select what you would like to do:");
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
                                Console.WriteLine("Add a new car the car parc | enter 'q' to quit");
                                Console.WriteLine("Enter the car's brand from this selected list :");
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
                                    Console.WriteLine("Add a new car the car parc | enter 'q' to quit");
                                    Console.WriteLine($"Selected Brand : {chosenBrand}");
                                    Console.WriteLine("Enter the car's model from this selected list :");

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
                                        Console.WriteLine("Internal Error: no models found for this car brand");
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
                                            Console.WriteLine("Add a new car the car parc | enter 'q' to quit");
                                            Console.WriteLine($"Selected Brand : {chosenBrand}");
                                            Console.WriteLine($"Selected Model : {chosenModel}");
                                            Console.WriteLine("Enter a French license plate (format: AA-000-AA):");
                                            
                                            string? licensePlate = Console.ReadLine();
                                            
                                            if (licensePlate == "q") {
                                                Console.Clear();
                                                Console.WriteLine("You've quit the process");
                                                break;
                                            }
                                            
                                            if(licensePlate != null && Regex.IsMatch(licensePlate, LicensePlatePattern))
                                            {
                                                if(CarParc.GetCarFromLicensePlate(licensePlate)==null)
                                                {
                                                    Console.Clear();

                                                    while(true)
                                                    {
                                                        Console.WriteLine("Add a new car the car parc | enter '6' to quit");
                                                        Console.WriteLine($"Selected Brand : {chosenBrand}");
                                                        Console.WriteLine($"Selected Model : {chosenModel}");
                                                        Console.WriteLine($"License Plate : {licensePlate}");
                                                        Console.WriteLine("Enter the car's year of registration:");
                                                        
                                                        if(int.TryParse(Console.ReadLine(),out int carYear)){
                                                            if(1668 <= carYear && carYear <= 2024){
                                                                Console.WriteLine("Add a new car the car parc | enter '6' to quit");
                                                                Console.WriteLine($"Selected Brand : {chosenBrand}");
                                                                Console.WriteLine($"Selected Model : {chosenModel}");
                                                                Console.WriteLine($"License Plate : {licensePlate}");
                                                                Console.WriteLine($"License Plate : {carYear}");
                                                                Console.WriteLine("Confirm and add car to the parc? y/n");
                                                                string? confirm = Console.ReadLine();
                                                                if (confirm == "y") {
                                                                    CarParc.AddANewCar(chosenBrand, chosenModel, licensePlate, carYear);
                                                                    Console.WriteLine("Successfully added the new car to the car parc.");
                                                                    break;
                                                                } else {
                                                                    Console.Clear();
                                                                    Console.WriteLine("You've quit the process");
                                                                    break;
                                                                }

                                                            }else if(carYear == 6){
                                                                Console.Clear();
                                                                Console.WriteLine("You've quit the process");
                                                                break;
                                                            } else{
                                                                Console.Clear();
                                                                Console.WriteLine("Error: The year of registration must be between 1668 and 2024.");
                                                            }
                                                        } else {
                                                            Console.Clear();
                                                            Console.WriteLine("Error: input not recognised");
                                                        }
                                                    } 
                                                } else {
                                                    Console.Clear();
                                                    Console.WriteLine("Error: This license plate is already registered to a car in this car parc.");
                                                }
                                            } else {
                                                Console.Clear();
                                                Console.WriteLine("Error: you seem to have inputed a lisence plate that is the wrong format.");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Error: you seem to have inputed an unknown car model for this brand.");
                                        break;
                                    }

                                } else {
                                    Console.Clear();
                                    Console.WriteLine("Error: you seem to have inputed an unknown car brand.");
                                    break;
                                }
                            }
                            break;

                        case 2:
                            Console.Clear();

                            while(true)
                            {
                                Console.WriteLine("Remove a car from the parc | enter 'q' to quit");
                                Console.WriteLine("Enter the car's license plate (format: AA-000-AA):");
                                
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
                                        Console.WriteLine("Car to be removed:");
                                        Console.WriteLine(carToRemove.All_info_car());
                                        Console.WriteLine("Confirm and remove the car from the parc? y/n");
                                        string? confirm = Console.ReadLine();
                                        if (confirm == "y") {
                                            CarParc.RemoveCar(licensePlate);
                                            Console.WriteLine("Successfully removed the car from the car parc.");
                                            break;
                                        } else {
                                            Console.Clear();
                                            Console.WriteLine("You've quit the process");
                                            break;
                                        }

                                    } else {
                                        Console.Clear();
                                        Console.WriteLine("Error: This license plate is not registered to any car in this car parc.");
                                    }
                                } else {
                                    Console.Clear();
                                    Console.WriteLine("Error: you seem to have inputed a lisence plate that is the wrong format.");
                                }
                            }
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("List of all cars in the parc:");
                            CarParc.ListAllCars();
                            Console.WriteLine("Select what you would like to do:");
                            Console.WriteLine("1. Filter by Brand or Model.");
                            Console.WriteLine("2. Search with license plate.");
                            Console.WriteLine("3. Back to the Main Menu.");
                            if(int.TryParse(Console.ReadLine(),out int userInput)){
                                switch(userInput){
                                    case 1:
                                        Console.Clear();

                                        while(true)
                                        {
                                            Console.WriteLine("Filter cars from the parc | enter 'q' to quit");
                                            Console.WriteLine("Enter the car's license plate (format: AA-000-AA):");
                                            
                                            string? licensePlate = Console.ReadLine();
                                            if (licensePlate == "q") {
                                                Console.Clear();
                                                Console.WriteLine("You've quit the process");
                                                break;
                                            }
                                        }
                                        break;
                                    case 2:
                                    Console.Clear();

                                        while(true)
                                        {
                                            Console.WriteLine("Search cars from the parc | enter 'q' to quit");
                                            Console.WriteLine("Enter the car's license plate (format: AA-000-AA):");
                                            
                                            string? licensePlate = Console.ReadLine();
                                            if (licensePlate == "q") {
                                                Console.Clear();
                                                Console.WriteLine("You've quit the process");
                                                break;
                                            }
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
                            }

                            break;

                        case 4:
                            Console.Clear();
                            
                            while(true)
                            {
                                Console.WriteLine("Rent a car from the parc | enter 'q' to quit");
                                Console.WriteLine("Enter the car's license plate (format: AA-000-AA):");
                                
                                string? licensePlate = Console.ReadLine();
                                if (licensePlate == "q") {
                                    Console.Clear();
                                    Console.WriteLine("You've quit the process");
                                    break;
                                }
                                if(licensePlate != null && Regex.IsMatch(licensePlate, LicensePlatePattern))
                                {
                                    Car? carToRent = CarParc.GetCarFromLicensePlate(licensePlate);
                                    if(carToRent!=null)
                                    {
                                        Console.WriteLine("Car to be removed:");
                                        Console.WriteLine(carToRent.All_info_car());
                                        Console.WriteLine("Confirm and rent the car from the parc? y/n");
                                        string? confirm = Console.ReadLine();
                                        if (confirm == "y") {
                                            CarParc.RemoveCar(licensePlate);
                                            Console.WriteLine("Successfully rented the car from the car parc.");
                                            break;
                                        } else {
                                            Console.Clear();
                                            Console.WriteLine("You've quit the process");
                                            break;
                                        }

                                    } else {
                                        Console.Clear();
                                        Console.WriteLine("Error: This license plate is not registered to any car in this car parc.");
                                    }
                                } else {
                                    Console.Clear();
                                    Console.WriteLine("Error: you seem to have inputed a lisence plate that is the wrong format.");
                                }
                            }
                            break;

                        case 5:
                            Console.Clear();
                            
                            while(true)
                            {
                                Console.WriteLine("Return a car to the parc | enter 'q' to quit");
                                Console.WriteLine("Enter the car's license plate (format: AA-000-AA):");
                                
                                string? licensePlate = Console.ReadLine();
                                if (licensePlate == "q") {
                                    Console.Clear();
                                    Console.WriteLine("You've quit the process");
                                    break;
                                }
                                if(licensePlate != null && Regex.IsMatch(licensePlate, LicensePlatePattern))
                                {
                                    Car? carToReturn = CarParc.GetCarFromLicensePlate(licensePlate);
                                    if(carToReturn!=null)
                                    {
                                        Console.WriteLine("Car to be removed:");
                                        Console.WriteLine(carToReturn.All_info_car());
                                        Console.WriteLine("Confirm and return the car to the parc? y/n");
                                        string? confirm = Console.ReadLine();
                                        if (confirm == "y") {
                                            CarParc.RemoveCar(licensePlate);
                                            Console.WriteLine("Successfully returned the car to the car parc.");
                                            break;
                                        } else {
                                            Console.Clear();
                                            Console.WriteLine("You've quit the process");
                                            break;
                                        }

                                    } else {
                                        Console.Clear();
                                        Console.WriteLine("Error: This license plate is not registered to any car in this car parc.");
                                    }
                                } else {
                                    Console.Clear();
                                    Console.WriteLine("Error: you seem to have inputed a lisence plate that is the wrong format.");
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
                    Console.WriteLine("Error: input not recognised");
                }
            }
            Console.Clear();
            Console.WriteLine("Successfully closed the program");
        }
    }
}