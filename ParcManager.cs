using System;
using System.Runtime.InteropServices.Swift;
using System.Text.RegularExpressions;
using TPFinal.Models;

namespace TPFinal
{
    public class ParcManager
    {   
        // Class-level fields and properties
        // This class manages the car parc, including adding, removing, renting, and returning cars.
        public Parc CarParc {get; set;} // The car parc being managed
        private string LicensePlatePattern = @"^[A-Z]{2}-\d{3}-[A-Z]{2}$"; // Regex for validating French license plates

        // Constructor: Initializes the car parc
        public ParcManager() 
        {
            this.CarParc = new Parc();
        }

        // Menu: Main user interface for interacting with the car parc
        public void Menu()
        {
            Console.Clear();

            while(true) // Infinite loop for menu options
            {
                // Display menu options
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

                // Read user input and handle menu selection
                if(int.TryParse(Console.ReadLine(),out int userOption)){
                    switch(userOption){

                        // Option 1: Add a new car
                        case 1:
                            Console.Clear();
                            AddNewCar();
                            break;

                        // Option 2: Remove a car
                        case 2:
                            Console.Clear();
                            RemoveCar();
                            break;
                            
                        // Option 3: List all cars
                        case 3:
                            Console.Clear();
                            ListAllCars();
                            break;

                        // Option 4: Rent a car
                        case 4:
                            Console.Clear();
                            RentCar();
                            break;
                        
                        // Option 5: Return a car
                        case 5:
                            Console.Clear();
                            ReturnCar();
                            break;

                        default:
                            Console.Clear();
                            break;
                    }

                    // Option 6: Quit the program
                    if(userOption == 6){
                        break;
                    }
                } else {
                    PrintMessage(ConsoleColor.Red,"Error: input not recognised");
                }
            }
            PrintMessage(ConsoleColor.Green,"Successfully closed the program");
        }

        private void AddNewCar(){
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Add a new car the car parc | enter 'q' to quit");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Enter the car's brand from this selected list :");
                Console.ResetColor();

                // Print all brands from the predefined brand enumeration
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
                
                // Check if user input corresponds to a valid brand
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
                    
                    // Select the enumaration corresponding to the selected brand
                    string enumName = "TPFinal.Models." + chosenBrand + "Models";
                    Type? enumType = Type.GetType(enumName);

                    // Check if the selected model enumeration is valid
                    if (enumType != null && enumType.IsEnum)
                    {
                        foreach (var model in Enum.GetNames(enumType))
                        {
                            Console.WriteLine("- " + model);
                        }
                        
                    }
                    else
                    {
                        PrintMessage(ConsoleColor.Red,"Internal Error: no models found for this car brand");
                        break;
                    }

                    string? inputModel = Console.ReadLine();
                    if (inputModel == "q") {
                        Console.Clear();
                        Console.WriteLine("You've quit the process");
                        break;
                    }

                    // Check if user input corresponds to a valid model from the chosen brand
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
                            
                            // Check if the license plate is a valid format (AA-000-AA)
                            if(licensePlate != null && Regex.IsMatch(licensePlate, LicensePlatePattern))
                            {
                                // Check if this license plate already exists in the car park
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
                                            // Check if the regitration date is valid (first car invented in 1885)
                                            if(1885 <= carYear && carYear <= DateTime.Now.Year){
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

                                                // Ask for confirmation
                                                string? confirm = Console.ReadLine();
                                                if (confirm == "y") {
                                                    Console.Clear();
                                                    CarParc.AddANewCar(chosenBrand, chosenModel, licensePlate, carYear);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("Successfully added the new car to the car parc.");
                                                    Console.ResetColor();
                                                    return; // exit all while loops once done
                                                } else {
                                                    PrintMessage(ConsoleColor.Red,"ABORTED! The car was not added to the car parc.");
                                                    return; // exit all while loops once done
                                                }

                                            }else if(carYear == 6){
                                                Console.Clear();
                                                break;
                                            } else{
                                                PrintMessage(ConsoleColor.Red,"Error: The year of registration must be between 1668 and 2024.");
                                            }
                                        } else {
                                            PrintMessage(ConsoleColor.Red,"Error: input not recognised");
                                        }
                                    } 
                                } else {
                                    PrintMessage(ConsoleColor.Red,"Error: This license plate is already registered to a car in this car parc.");
                                }
                            } else {
                                PrintMessage(ConsoleColor.Red,"Error: you seem to have inputed a lisence plate that is the wrong format.");
                            }
                        }
                    }
                    else
                    {
                        PrintMessage(ConsoleColor.Red,"Error: you seem to have inputed an unknown car model for this brand.");
                        break;
                    }

                } else {
                    PrintMessage(ConsoleColor.Red,"Error: you seem to have inputed an unknown car brand.");
                    break;
                }
            }
            return;
        }
        private void RemoveCar(){
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
                // Check if the license plate is a valid format (AA-000-AA)
                if(licensePlate != null && Regex.IsMatch(licensePlate, LicensePlatePattern))
                {

                    // Get and print info of the selected car if it exists in the car parc
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

                        // Ask for confirmation
                        string? confirm = Console.ReadLine();
                        if (confirm == "y") {
                            CarParc.RemoveCar(licensePlate);
                            PrintMessage(ConsoleColor.Red,"Successfully removed the car from the car parc.");
                            break;
                        } else {
                            Console.Clear();
                            Console.WriteLine("You've quit the process");
                            break;
                        }

                    } else {
                        PrintMessage(ConsoleColor.Red,"Error: This license plate is not registered to any car in this car parc.");
                    }

                } else {
                    PrintMessage(ConsoleColor.Red,"Error: you seem to have inputed a lisence plate that is the wrong format.");
                }
            }
            return;
        }
        private void ListAllCars(){
            while(true)
            {
                // Print all cars info and display sub menu options
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
                
                // Read user input and handle menu selection
                if(int.TryParse(Console.ReadLine(),out int userInput)){
                    switch(userInput){
                        // SubOption 1: Filter cars by brand or model
                        case 1:
                            Console.Clear();
                            FilterByBrandOrModel();
                            break;

                        // SubOption 2: Search cars by partial or full license plate
                        case 2:
                            Console.Clear();
                            SearchByLicensePlate();
                            break;

                        // SubOption 3: List all available cars to be rented
                        case 3:
                            Console.Clear();
                            ListAllAvailableCars();
                            break;
                            
                        default:
                            Console.Clear();
                            break;
                    }
                    if(userInput == 4){
                        Console.Clear();
                        Console.WriteLine("You've quit the process");
                        break;
                    }
                } else {
                    PrintMessage(ConsoleColor.Red,"Error: input not recognised");
                }
            }
            return;
        }
        private void FilterByBrandOrModel(){
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
                    PrintMessage(ConsoleColor.Red,"Error: input not recognised.");
                }
            }
            return;
        }
        private void SearchByLicensePlate(){
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
                    PrintMessage(ConsoleColor.Red,"Error: input not recognised.");
                }
            }
            return;
        }
        private void ListAllAvailableCars(){
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
            return;
        }
        private void RentCar(){
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

                // Check if the license plate is a valid format (AA-000-AA)
                if(licensePlate != null && Regex.IsMatch(licensePlate, LicensePlatePattern))
                {
                    Car? carToRent = CarParc.GetCarFromLicensePlate(licensePlate);

                    // Check if car exists
                    if(carToRent!=null)
                    {

                        // Check if car is not rented
                        if(!carToRent.IsRented){
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Car to be rented:");
                            Console.ResetColor();
                            Console.WriteLine(carToRent.All_info_car());
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Confirm and rent the car from the parc? y/n");
                            Console.ResetColor();

                            // Ask for confirmation
                            string? confirm = Console.ReadLine();
                            if (confirm == "y") {
                                CarParc.RentCar(licensePlate);
                                Console.Clear();
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
                            PrintMessage(ConsoleColor.Red,"Error: This car is already being rented by someone else");
                        }

                    } else {
                        PrintMessage(ConsoleColor.Red,"Error: This license plate is not registered to any car in this car parc.");
                    }
                } else {
                    PrintMessage(ConsoleColor.Red,"Error: you seem to have inputed a lisence plate that is the wrong format.");
                }
            }
            return;
        }
        private void ReturnCar(){
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

                // Check if the license plate is a valid format (AA-000-AA)
                if(licensePlate != null && Regex.IsMatch(licensePlate, LicensePlatePattern))
                {
                    Car? carToReturn = CarParc.GetCarFromLicensePlate(licensePlate);

                    // Check if car exists
                    if(carToReturn!=null)
                    {
                        // Check if car is rented
                        if(carToReturn.IsRented){
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Car to be returned:");
                            Console.ResetColor();
                            Console.WriteLine(carToReturn.All_info_car());
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Confirm and return the car to the parc? y/n");
                            Console.ResetColor();

                            // Ask for confirmation
                            string? confirm = Console.ReadLine();
                            if (confirm == "y") {
                                CarParc.ReturnCar(licensePlate);
                                PrintMessage(ConsoleColor.Green,"Successfully returned the car to the car parc.");
                                break;
                            } else {
                                Console.Clear();
                                Console.WriteLine("You've quit the process");
                                break;
                            }
                        } else {
                            PrintMessage(ConsoleColor.Red,"Error: This car is not listed as being rented by anyone.");
                        }

                    } else {
                        PrintMessage(ConsoleColor.Red,"Error: This license plate is not registered to any car in this car parc.");
                    }
                } else {
                    PrintMessage(ConsoleColor.Red, "Error: you seem to have inputed a lisence plate that is the wrong format.");
                }
            }
            return;
        }
        private void PrintMessage(System.ConsoleColor color, string message){
            Console.Clear();
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}