public class Car 
{
    public int Id ;
    public string Brand;
    public string Model;
    public string Year;
    public string Statut;
    public string Assurance;
    public string LicensePlate;
    

    public string value_Brand_car()
    {
        return Brand;
    }


    public Car(int Id ,string Brand, string Model, string Year, string Statut, string Assurance, string LicensePlate)
    {
        this.Id = Id;
        this. Brand = Brand;
        this.Model = Model;
        this.Year = Year;
        this.Statut = Statut;
        this.Assurance = Assurance;
        this.LicensePlate = LicensePlate;

    }
}