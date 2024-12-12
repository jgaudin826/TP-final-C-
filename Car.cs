class Car 
{
    public int Id ;
    public string Marque;
    public string Year;
    public string Statut;
    public string Assurance;

    public string Immatriculation;
    public string Type_de_vehicule;

    public string valueMarque()
    {
        return this.Marque;
    }

    public Car(int Id ,string Marque, string Year, string Statut, string Assurance, string Immatriculation, string Type_de_vehicule)
    {
        this.Id = Id;
        this.Marque = Marque;
        this.Year = Year;
        this.Statut = Statut;
        this.Assurance = Assurance;
        this.Immatriculation = Immatriculation;
        this.Type_de_vehicule = Type_de_vehicule;

    }
}