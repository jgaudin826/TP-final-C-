using System;

namespace TPFinal
{
    public class Car 
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool IsRented { get; set; }
        public string LicensePlate { get; set; }
        
        
        public string All_info_car()
        {
            return $"Brand : {Brand}, Model : {Model}, Year : {Year}, IsRented : {IsRented}, LicensePlate : {LicensePlate}";
        }
    
        public Car(string Brand, string Model, int Year, bool IsRented, string LicensePlate)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.Year = Year;
            this.IsRented = IsRented ;
            this.LicensePlate = LicensePlate;

        }

        Car car1 = new Car("Toyota","Corolla",2020,true,"AB-123-CD");
    }
}