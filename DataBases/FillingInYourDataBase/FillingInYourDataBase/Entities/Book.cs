namespace FillingInYourDataBase.Entities
{
    class Book
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int TotalAmount { get; set; }
        public int AmountToRepair { get; set; }
        public int AmountToReadHome { get; set; }
    }
}
