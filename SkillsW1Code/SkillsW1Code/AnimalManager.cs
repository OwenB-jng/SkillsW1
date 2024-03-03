using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsW1Code
{
    public class AnimalManager
    {
        public List<Animal> Animals { get; set; }

        public AnimalManager()
        {
            Animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
            Console.WriteLine("Animal Added");
        }

        public bool DeleteAnimal(int id)
        {
            Animal animalToDel = findAnimalByID(id);
            if (animalToDel != null)
            {
                Animals.Remove(animalToDel);
                return true;
            }
            return false;
        }

        public Animal findAnimalByID(int id)
        {
            foreach (Animal animal in Animals)
            {
                if (animal.Id == id)
                    return animal;
            }
            return null;
        }

        public string ListAllAnimals()
        {
            string s = "";
            foreach (Animal animal in Animals)
            {
                if (animal.Archived == false)
                {
                    s += animal.displayAnimal() + "\n";
                }
            }
            if (s == "")
            {
                s = "No animals in shelter";
            }
            return s;
        }

        public void ArchivePast3Months()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            foreach (Animal animal in Animals)
            {
                int daysSinceAdopted = today.DayNumber - animal.AdoptionDate.DayNumber;
                if (daysSinceAdopted < 90)
                {
                    animal.Archived = true;
                    animal.ArchivedDate = today;
                }
            }
        }
        public void SearchArchive(int days)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            foreach (Animal animal in Animals)
            {
                int daysSinceArchived = today.DayNumber - animal.ArchivedDate.DayNumber;
                if (daysSinceArchived < days){
                    Console.WriteLine(animal.displayAnimal());
                }
            }
        }
    }
}
