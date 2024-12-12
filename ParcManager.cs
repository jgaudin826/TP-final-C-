using System;

namespace TPFinal
{
    public class ParcManager
    {
        public Parc parc {get; set;} //

        public ParkManager() //Constructor
        {
            parc = new Parc();
        }

        public void Menu()
        {
            Console.WriteLine("WELCOME TO THE CAR PARK");
            int userOption = 0;
            while(userOption != 5)
            {
                Console.WriteLine("Select what you would like to do: \n1. Add a new car to the park. \n2. List all cars in the park. \n 3. Rent a car. \n 4. Return a car. \n5. Quit the program.");

                userOption = Convert.ToInt32(Console.ReadLine());

                switch userOption{
                    case 1:
                        parc.AddCar()
                        break
                    case 2:
                        Console.WriteLine("List of all cars in the park:");
                        // list all cars
                        int userInput = 0;
                        while(userInput != 2)
                            Console.WriteLine("1. Search/Filter. \n2. Go back.");
                            userInput = Convert.ToInt32(Console.ReadLine());
                            switch(userInput){
                                case 1:
                                    Console.WriteLine("Search by license plate, brand or model of the vehicule:");
                                    string searchString = Console.ReadLine();
                                    break
                                default:
                                    break
                            }
                        break
                    case 3:

                        break
                    case 4:

                        break
                    default:
                        break
                }
            }
        }
    }
}