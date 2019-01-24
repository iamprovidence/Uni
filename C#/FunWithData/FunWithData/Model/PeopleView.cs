namespace FunWithData.Model
{
    // обгортка над People, підтримує фільтрацію, сортування
    class PeopleView
    {
        // FIELDS
        People people; // оригінальна колекція
        System.Collections.Generic.List<Person> view; // представлення, яке містить відфільтровану, посортовану колекцію 
        // CONSTRUCTORS
        public PeopleView(People people)
        {
            this.people = people;
            this.view = new System.Collections.Generic.List<Person>();
            Reset();
        }
        public void Reset()
        {
            view.Clear();
            view.AddRange(people);
        }
        // PROPERTIES
        public int Count => view.Count;
        public Person this[int index] => view[index];
        // METHODS
        public void SortBy(SortMode sortMode)
        {
            switch(sortMode)
            {
                case SortMode.Id : view.Sort((p1, p2) => p1.Id.CompareTo(p2.Id)); break;
                case SortMode.Name: view.Sort((p1, p2) => p1.Name.CompareTo(p2.Name)); break;
                case SortMode.Surname: view.Sort((p1, p2) => p1.Surname.CompareTo(p2.Surname)); break;
                case SortMode.Age: view.Sort((p1, p2) => p1.Age.CompareTo(p2.Age)); break;
                default: throw new System.InvalidOperationException("Current sort mode is not supported");
            }
        }
        // 1. чистимо список
        // 2. заповнюємо тими значеннями, що підходять
        public void FilterBy(FilterModeInt filterModeInt, int min, int max)
        {
            // initialize predicate
            System.Predicate<Person> predicate;
            switch (filterModeInt)
            {
                case FilterModeInt.Id: predicate = (p) => p.Id > min && p.Id < max;  break;
                case FilterModeInt.Age: predicate = (p) => p.Age > min && p.Age < max;  break;
                default: throw new System.InvalidOperationException("Current filter mode is not supported");
            }

            // filtering
            view.Clear();
            foreach (Person item in people)
            {
                if (predicate(item)) view.Add(item);
            }
        }
        public void FilterBy(FilterModeString filterModeString, string subString)
        {
            // initialize predicate
            System.Predicate<Person> predicate;
            switch (filterModeString)
            {
                case FilterModeString.Name: predicate = (p) => p.Name.Contains(subString); break;
                case FilterModeString.Surname: predicate = (p) => p.Surname.Contains(subString); break;
                default: throw new System.InvalidOperationException("Current filter mode is not supported");
            }

            // filtering
            view.Clear();
            foreach (Person item in people)
            {
                if (predicate(item)) view.Add(item);
            }
        }
        public int IndexOf(string name)
        {
            return view.FindIndex((p) => p.Name.Equals(name));
        }
    }
}
