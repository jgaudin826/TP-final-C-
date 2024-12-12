class Car 
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public bool Statut { get; set; }
    public string Assurance { get; set; }

    public string LicensePlate { get; set; }
    
    
    public string All_info_car()
    {
        return $"Id : {Id}, Brand : {Brand}, Model : {Model}, Year : {Year}, Statut : {Statut}, Assurance : {Assurance}, LicensePlate : {LicensePlate}";
    }
  
    public Car(int Id ,string Brand, string Model, string Year, bool Statut, string Assurance, string LicensePlate)
    {
        this.Id = Id;
        this. Brand = Brand;
        this.Model = Model;
        this.Year = Year;
        this.Statut =true ;
        this.Assurance = Assurance;
        this.LicensePlate = LicensePlate;

    }
}