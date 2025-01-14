using System;
using System.Data.Common;
using System.Globalization;

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
                chosenBrand.ToString(),   
                chosenModel.ToString(),    
                Convert.ToInt32(carYear),                   
                false,                     
                licensePlate.ToString()             
            );

            CarsList.Add(newCar);
        }

        public Car? GetCarFromLicensePlate(string licensePlate) //method to check if a car with the license plate exists in the car parc
        {
            foreach (Car car in CarsList)
            {
                if (car.LicensePlate == licensePlate)
                {
                    return car;
                }
            }
            return null;
        }

        public void RemoveCar(string licensePlate) //method to remove a car from the car parc using the license plate as a unique ID
        {
            Car? carToRemove = null;
            foreach (var car in CarsList)
            {
                if (car.LicensePlate == licensePlate)
                {
                    carToRemove = car;
                }
            }

            if (carToRemove != null){
                CarsList.Remove(carToRemove);
            }       
        }

        public void ListAllCars()
        {
            foreach (var car in CarsList)
            {
                Console.WriteLine(car.All_info_car());
            }
        }
        public void FilterAllCars(string filterString) //return a list off all cars with a brand or model matching the filterString
        {
            foreach (var car in CarsList)
            {
                if(car.Brand.ToLower().Contains(filterString.ToLower().Replace(" ","")) || car.Model.ToLower().Contains(filterString.ToLower().Replace(" ","")))
                {
                    Console.WriteLine(car.All_info_car());
                }
            }
        }
        public void SearchAllCars(string searchString) //return a list off all cars with a license plate matching the searchString
        {
            foreach (var car in CarsList)
                    {
                        if(car.LicensePlate.ToLower().Replace("-","").Contains(searchString.ToLower().Replace("-","").Replace(" ","")))
                        {
                            Console.WriteLine(car.All_info_car());
                        }
                    }
        }

        public void GetAllAvailableCars() // return a list of all info of available cars
        {

            foreach (Car car in CarsList)
            {
                if (!car.IsRented)
                {
                    Console.WriteLine(car.All_info_car());
                }
            }
        }

        public void RentCar(string licensePlate) // Method that checks if a vehicle has been rented
        {
           foreach (var car in CarsList)
           {
                if (car.LicensePlate == licensePlate)
                {
                    car.IsRented = true;
                }
           }
        }

         public void ReturnCar(string licensePlate) // Method that checks if a vehicle has been returned
        {
           foreach (var car in CarsList)
           {
                if (car.LicensePlate == licensePlate)
                {
                    car.IsRented = false;
                }
           }
        }
    }

}
