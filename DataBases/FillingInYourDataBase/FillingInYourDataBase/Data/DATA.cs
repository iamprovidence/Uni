namespace FillingInYourDataBase
{
    class DATA
    {
        // FIELDS
        char[] letters;
        string[] name;
        string[] surname;
        string[] words;
        string[] phname;
        int phNameIndex;
        string[] country;
        string[] cities;
        System.Random random;

        public DATA()
        {
            random = new System.Random();
            letters = "abcdefghijclmnopqrstuwxyz123456789".ToCharArray();
            words = System.Text.RegularExpressions.Regex.Replace(
                System.IO.File.ReadAllText("../../Data/LoremIpsum.txt").ToLower().Replace(",","").Replace(".",""), @"\s+", " ").Split();
            name = System.IO.File.ReadAllLines("../../Data/Names.txt");
            surname = System.IO.File.ReadAllLines("../../Data/Surnames.txt");
            phname = System.IO.File.ReadAllLines("../../Data/PHnames.txt");
            country = System.IO.File.ReadAllLines("../../Data/Country.txt");
            cities = System.IO.File.ReadAllLines("../../Data/City.txt");
            phNameIndex = 0;
        }
        public string GetBookName()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(words[random.Next(words.Length)]);
            sb[0] = sb[0].ToString().ToUpper()[0];
            sb.Append(" ");
            int l = sb.Length;
            sb.Append(words[random.Next(words.Length)]);
            sb[l] = sb[l].ToString().ToUpper()[0];

            return sb.ToString();
        }
        public string GetName()
        {
            return name[random.Next(name.Length)];
        }
        public string GetSurname()
        {
            return surname[random.Next(surname.Length)];
        }
        public string GetISBN()
        {
            int f = random.Next(100, 1000);
            int s = random.Next(100, 1000);
            int t = random.Next(10, 100);
            int fo = random.Next(1000, 10000);
            int fi = random.Next(0, 10);

            return string.Join("-", f, s, t, fo, fi);
        }
        public string GetCode()
        {
            System.Text.StringBuilder code = new System.Text.StringBuilder();

            for (int i = 0; i < 10; ++i)
            {
                code.Append(letters[random.Next(letters.Length)]);
            }
            code.Insert(4, '-');
            code.Insert(9, '-');

            return code.ToString();
        }
        public string GetPhone()
        {
            System.Text.StringBuilder phone = new System.Text.StringBuilder();
            phone.Append("380");
            phone.Append(random.Next(100000000, 1000000000));
            return phone.ToString();
        }
        public string GetPublishingHouseName()
        {
            return phname[phNameIndex++ % phname.Length];
        }
        public string GetCountry()
        {
            return country[random.Next(country.Length)];
        }
        public string GetCity()
        {
            return cities[random.Next(cities.Length)];
        }
    }
}
