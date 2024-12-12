using System;

namespace TPFinal
{
  class Program
  {
    static void Main(string[] args)
    {
      Car v = new Car(1,"Ford","2024","Disponible","Groupma-Loire-Bretagne"); 

      Console.WriteLine(v.Marque);
    }
  }
}