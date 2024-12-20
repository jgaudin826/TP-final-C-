using System;

namespace TPFinal
{
    public class GestionFlotte
    {
        private Car[] _parc; 

        public Car[] Parc
        {
            get => _parc;
            set => _parc = value;
        }

        public GestionFlotte()
        {
            _parc = new Car[0]; 
        }

        public void AddANewCar(int id, string brand, string model, string year, string statut, string assurance, string licensePlate)
        {
            if (_parc.Any(car => car.Id == id))
            {
                throw new ArgumentException("This ID already exists in our directory!");
            }

            if (_parc.Any(car => car.LicensePlate == licensePlate))
            {
                throw new ArgumentException("This license plate already exists in our directory!");
            }

            var newCar = new Car(id, brand, model, year, statut, assurance, licensePlate);
            Array.Resize(ref _parc, _parc.Length + 1);
            _parc[^1] = newCar;
        }
    }

}
//license and id are unique - make an error check to make sure they don't already exist, return either the error messages or the new car
