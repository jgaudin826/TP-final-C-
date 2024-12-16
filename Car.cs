class Car 
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public DateTime Year { get; set; }
    public bool Statut { get; set; }
    public string Assurance { get; set; }

    public string LicensePlate { get; set; }
    
    
    public string All_info_car()
    {
        return $"Id : {Id}, Brand : {Brand}, Model : {Model}, Year : {Year}, Statut : {Statut}, Assurance : {Assurance}, LicensePlate : {LicensePlate}";
    }
  
    public Car(int Id ,string Brand, string Model, DateTime Year, bool Statut, string Assurance, string LicensePlate)
    {
        this.Id = Id;
        this. Brand = Brand;
        this.Model = Model;
        this.Year = Year;
        this.Statut = Statut ;
        this.Assurance = Assurance;
        this.LicensePlate = LicensePlate;

    }

     Car car1 = new Car(1,"Toyota","Corolla",new DateTime(2020, 1, 1),true,"Allianz","AB-123-CD");
}