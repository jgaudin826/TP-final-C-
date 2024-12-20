using System;

namespace TPFinal
{
    public class Parc
    {
       public List<Car> CarsList {get; set;} //property 

        public Parc() //constructor 
        {
            CarsList = new List<Car>();
        }

        public void AddANewCar(Models.Brands chosenBrand, object chosenModel, string licensePlate, int carYear) //method to add a new car
        {
            Car newCar = new Car(
                Convert.ToString(chosenBrand),    
                Convert.ToString(chosenModel),    
                Convert.ToInt32(carYear),                   
                false,                     
                Convert.ToString(licensePlate)             
            );

            CarsList.Add(newCar);
        }

        public Car? GetCarFromLicensePlate(string licensePlate) //method to check if a car with the license plate exists in the car parc
        {
            return null;
        }

        public void RemoveCar(string licensePlate) //method to remove a car from the car parc using the license plate as a unique ID
        {
        }

        public void ListAllCars()
        {
            Console.WriteLine("list of all cars");
        }
        public void FilterAllCars(string filterString) //return a list off all cars with a brand or model matching the filterString
        {
            Console.WriteLine("filtered list of all cars");
        }
        public void SearchAllCars(string searchString) //return a list off all cars with a license plate matching the searchString
        {
            Console.WriteLine("searched list of all cars");
        }
    }
}
