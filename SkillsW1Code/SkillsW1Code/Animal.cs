using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SkillsW1Code
{
    public class Animal
    {
        private static int idCounter;

        public int Id { get; set; } 
        public string Species { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; } 
        public bool Spayed { get; set; } 
        public string Breed { get; set; }
        public string Colour { get; set; }
        public string Birthday { get; set; } 
        public string VaccineStatus { get; set; }
        public string Identification { get; set; }
        public double AdoptionFee { get; set; }
        public bool Archived { get; set; }
        public DateOnly ArchivedDate { get; set; }
        public bool Adopted { get; set; }
        public DateOnly AdoptionDate { get; set; }

        public int GenerateID()
        {
            return (++idCounter); 
        }

        public Animal (string Species, string Name, char Gender, bool Spayed, string Breed, string Colour, string Birthday, string VaccineStatus, string Identification, double AdoptionFee)
        {
            Id = GenerateID();
            this.Species = Species;
            this.Name = Name;
            this.Gender = Gender;
            this.Spayed = Spayed;
            this.Breed = Breed;
            this.Colour = Colour;
            this.Birthday = Birthday;
            this.VaccineStatus = VaccineStatus;
            this.Identification = Identification;
            this.AdoptionFee = AdoptionFee;
            Archived = false;
            ArchivedDate = new DateOnly();
            Adopted = false;
            AdoptionDate = new DateOnly();
        }
        public Animal(string Species, string Name, char Gender, bool Spayed, string Breed, string Colour, string Birthday, string VaccineStatus, string Identification, double AdoptionFee, bool Archived, DateOnly ArchivedDate, bool Adopted, DateOnly AdoptionDate)
            : this(Species, Name, Gender, Spayed, Breed, Colour, Birthday, VaccineStatus, Identification, AdoptionFee) 
            {
                this.Archived = Archived;
                this.ArchivedDate = ArchivedDate;
                this.Adopted = Adopted;
                this.AdoptionDate = AdoptionDate;
            }

        public string displayAnimal()
        {
            string s = "Animal output\n";
            s += "ID: " + Id.ToString().PadLeft(8,'0') + "\n";
            s += "Species: " + Species + "\n";
            s += "Name: " + Name + "\n";
            s += "Gender: " + Gender + "\n";
            s += "Spayed: " + (Spayed) + "\n";
            s += "Breed: " + Breed + "\n";
            s += "Colour: " + Colour + "\n";
            s += "Birthday: " + Birthday + "\n";
            s += "Vaccine Status: " + VaccineStatus + "\n";
            s += "Identification: " + Identification + "\n";
            s += "Adoption Fee: " + AdoptionFee + "\n";
            s += "Archived: " + Archived + "\n";
            s += "Archived Date: " + ArchivedDate + "\n";
            s += "Adopted: " + Adopted + "\n";
            s += "Adoption Date: " + AdoptionDate  + "\n";

            return s;
        }
    }
}
