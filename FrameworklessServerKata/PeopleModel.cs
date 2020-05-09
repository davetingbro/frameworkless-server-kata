using System.Collections.Generic;

namespace FrameworklessServerKata
{
    public class PeopleModel
    {
        public List<Person> People { get; }

        public PeopleModel()
        {
            People = new List<Person>{new Person("David")};
        }

        public void Add(Person person)
        {
            People.Add(person);
        }

        public void Delete(string name)
        {
            People.RemoveAll(p => p.Name == name);
        }
    }
}