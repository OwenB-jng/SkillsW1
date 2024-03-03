using SkillsW1Code;

DateOnly today = DateOnly.FromDateTime(DateTime.Now);

AnimalManager AnimalManager = new AnimalManager();
Animal animal1 = new Animal("Dog", "Dog1", 'M', true, "Boxer", "Brown", "01/01/2001", "Up to Date", "Barcode", 200);
Animal animal2 = new Animal("Cat", "Cat1", 'F', false, "Domestic Shorthair", "Orange", "01/01/2001", "Up to Date", "Barcode", 200);
Animal animal3 = new Animal("Fish", "Fish1", 'F', false, "Koi", "Orange", "01/01/2001", "Up to Date", "Barcode", 100, true, new DateOnly(2024, 1, 1), true, new DateOnly(2024, 1, 1));

AnimalManager.AddAnimal(animal1);
AnimalManager.AddAnimal(animal2);
AnimalManager.AddAnimal(animal3);


while (true)
{
    Console.WriteLine("Welcome! Please select an operation.");
    Console.WriteLine("Please enter 1 to enter a new animal");
    Console.WriteLine("Please enter 2 to find an animal");
    Console.WriteLine("Please enter 3 to delete an animal");
    Console.WriteLine("Please enter 4 to list all animal");
    Console.WriteLine("Please enter 5 to update an animal");
    Console.WriteLine("Please enter 6 to manage archival status for animal");
    Console.WriteLine("Please enter 7 to adopt an animal");
    Console.WriteLine("Please enter 8 to archive adopted animals from the past 3 months");
    Console.WriteLine("Please enter 9 to search by archived animals");

    string choice = Console.ReadLine();

    //Create Animal
    if (choice == "1")
    {
        Console.WriteLine("Please enter the animal's species");
        string newSpecies = Console.ReadLine();

        Console.WriteLine("Please enter the animal's name");
        string newName = Console.ReadLine();

        Console.WriteLine("Please enter the animal's gender");
        char newGender = Convert.ToChar(Console.ReadLine());

        Console.WriteLine("Please enter the animal's spayed status");
        bool newSpayed = Convert.ToBoolean(Console.ReadLine());

        Console.WriteLine("Please enter the animal's breed");
        string newBreed = Console.ReadLine();

        Console.WriteLine("Please enter the animal's colour");
        string newColour = Console.ReadLine();

        Console.WriteLine("Please enter the animal's birthday");
        string newBirthday = Console.ReadLine();

        Console.WriteLine("Please enter the animal's vaccination status");
        string newVaccineStatus = Console.ReadLine();

        Console.WriteLine("Please enter the animal's form of identification");
        string newIdentification = Console.ReadLine();



        int animalAge = today.Year - DateOnly.Parse(newBirthday).Year;
        int newAdoptionFee = 0;
        if (animalAge == 1 || animalAge == 0)
        {
            newAdoptionFee = 300;
        }
        else if(animalAge > 10)
        {
            newAdoptionFee = 100;
        }
        else
        {
            newAdoptionFee = 200;
        }

        Animal newAnimal = new Animal(newSpecies, newName, newGender, newSpayed, newBreed, newColour, newBirthday, newVaccineStatus, newIdentification, newAdoptionFee);
        AnimalManager.AddAnimal(newAnimal);
    }

    //Find one animal by Id
    if (choice == "2")
    {
        Console.WriteLine("Please input the animal id");
        int findId = Convert.ToInt32(Console.ReadLine());
        Animal foundAnimal = AnimalManager.findAnimalByID(findId);
        if (foundAnimal != null)
        {
            Console.WriteLine(foundAnimal.displayAnimal());
        }
        else {
            Console.WriteLine("No animal found with that ID");
        }
    }

    //Delete one animal by Id
    if (choice == "3")
    {
        Console.WriteLine("Please input the animal id");
        int findId = Convert.ToInt32(Console.ReadLine());
        Animal foundAnimal = AnimalManager.findAnimalByID(findId);
        if (foundAnimal != null)
        {
            AnimalManager.DeleteAnimal(findId);
        }
        else 
        {
            Console.WriteLine("No animal found with that ID");
        }
    }

    //List all animals
    if (choice == "4")
    {
        Console.WriteLine(AnimalManager.ListAllAnimals());
    }

    //Update animal by id
    if (choice == "5")
    {
        Console.WriteLine("Please input the animal id");
        int findId = Convert.ToInt32(Console.ReadLine());
        Animal foundAnimal = AnimalManager.findAnimalByID(findId);
        if (foundAnimal != null)
        {
            Console.WriteLine("Please enter the animal's species");
            string newSpecies = Console.ReadLine();
            foundAnimal.Species = newSpecies;

            Console.WriteLine("Please enter the animal's name");
            string newName = Console.ReadLine();
            foundAnimal.Name = newName;

            Console.WriteLine("Please enter the animal's gender");
            char newGender = Convert.ToChar(Console.ReadLine());
            foundAnimal.Gender = newGender;

            Console.WriteLine("Please enter the animal's spayed status");
            bool newSpayed = Convert.ToBoolean(Console.ReadLine());
            foundAnimal.Spayed = newSpayed;

            Console.WriteLine("Please enter the animal's breed");
            string newBreed = Console.ReadLine();
            foundAnimal.Breed = newBreed;

            Console.WriteLine("Please enter the animal's colour");
            string newColour = Console.ReadLine();
            foundAnimal.Colour = newColour;

            Console.WriteLine("Please enter the animal's birthday");
            string newBirthday = Console.ReadLine();
            foundAnimal.Birthday = newBirthday;

            Console.WriteLine("Please enter the animal's vaccination status");
            string newVaccineStatus = Console.ReadLine();
            foundAnimal.VaccineStatus = newVaccineStatus;

            Console.WriteLine("Please enter the animal's form of identification");
            string newIdentification = Console.ReadLine();
            foundAnimal.Identification = newIdentification;

            Console.WriteLine("Please enter the animal's adoption fee");
            double newAdoptionFee = Convert.ToDouble(Console.ReadLine());
            foundAnimal.AdoptionFee = newAdoptionFee;

        }
        else
        {
            Console.WriteLine("No animal found with that ID");
        }
    }

    //Archive status
    if (choice == "6")
    {
        Console.WriteLine("Please input the animal id");
        int findId = Convert.ToInt32(Console.ReadLine());
        Animal foundAnimal = AnimalManager.findAnimalByID(findId);
        if (foundAnimal != null)
        {
            if (foundAnimal.Archived == false)
            {
                foundAnimal.Archived = true;
                Console.WriteLine(foundAnimal.Name + " archived status set to True");
                foundAnimal.ArchivedDate = today;
            }
            else
            {
                foundAnimal.Archived = false;
                Console.WriteLine(foundAnimal.Name + " archived status set to False");
                foundAnimal.ArchivedDate = new DateOnly();
            }
        }
        else
        {
            Console.WriteLine("No animal found with that ID");
        }
    }

    //Adopt an animal and set adoption date to today
    if (choice == "7")
    {
        Console.WriteLine("Please input the animal id");
        int findId = Convert.ToInt32(Console.ReadLine());
        Animal foundAnimal = AnimalManager.findAnimalByID(findId);
        if (foundAnimal != null)
        {
            foundAnimal.Adopted = true;
            foundAnimal.AdoptionDate = DateOnly.FromDateTime(DateTime.Now);
        }
        else
        {
            Console.WriteLine("No animal found with that ID");
        }
    }

    //Archive last 3 months
    if (choice == "8")
    {
        AnimalManager.ArchivePast3Months();
    }

    //Search Archived
    if (choice == "9")
    {
        Console.WriteLine("Please input number of days");
        int findId = Convert.ToInt32(Console.ReadLine());
        
    }

}
