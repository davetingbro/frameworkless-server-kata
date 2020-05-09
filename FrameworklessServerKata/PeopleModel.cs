using System;
using System.Collections.Generic;

namespace FrameworklessServerKata
{
    public class PeopleModel
    {
        public List<Person> People { get; }
        private readonly Person _worldOwner;

        public PeopleModel()
        {
            _worldOwner = new Person("David");
            People = new List<Person>{_worldOwner};
        }

        public void Add(Person person)
        {
            People.Add(person);
        }

        public void Delete(string name)
        {
            if (name == _worldOwner.Name)
                throw new ArgumentException("Cannot delete world owner");
            People.RemoveAll(p => p.Name == name);
        }
    }
}