using System;

namespace TPFinal
{
    public class Car // Initialization of the Car class with properties and constructor
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool IsRented { get; set; }
        public string LicensePlate { get; set; }
        
        
        public string All_info_car()  // Method by which information is displayed of a car
        {
            return $"Brand : {Brand}, Model : {Model}, Year : {Year}, IsRented : {IsRented}, LicensePlate : {LicensePlate}";
        }
    
        public Car(string Brand, string Model, int Year, bool IsRented, string LicensePlate) // Constructor of Car class
        {
            this.Brand = Brand;
            this.Model = Model;
            this.Year = Year;
            this.IsRented = IsRented ;
            this.LicensePlate = LicensePlate;

        }

    }
}