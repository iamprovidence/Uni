namespace FillingInYourDataBase.Entities
{
    class Author
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public System.Collections.Generic.List<Book> Books { get; set; }
    }
}
