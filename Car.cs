class Car 
{
    public int Id ;
    public string Brand;
    public string Year;
    public string Statut;
    public string Assurance;

    public string LisenceTape;
    public string Brand_car;

    public string valueMarque()
    {
        return Brand;
    }

    public Car(int Id ,string Brand, string Year, string Statut, string Assurance, string LisenceTape, string Brand_car)
    {
        this.Id = Id;
        this. Brand = Brand;
        this.Year = Year;
        this.Statut = Statut;
        this.Assurance = Assurance;
        this.LisenceTape = LisenceTape;
        this.Brand_car = Brand_car;

    }
}