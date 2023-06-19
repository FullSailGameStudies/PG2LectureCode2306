namespace Day10
{

    /*
        ╔══════════╗ 
        ║ File I/O ║
        ╚══════════╝ 

        3 things are required for File I/O:
        1) Open the file
        2) read/write to the file
        3) close the file


        TIPS:
            use File.ReadAllText to open,read,close the file in 1 statement
            the using() statement can ensure that the file is closed

    */
    public enum Powers
    {
        Money, Jumping, Speed, Strength, Swimming
    }
    class Superhero
    {
        public string Name { get; set; }
        public string Secret { get; set; }
        public Powers Power { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                ╔══════════╗ 
                ║ File I/O ║
                ╚══════════╝ 

                [  Open the file  ]
                [  Write to the file  ]
                [  Close the file  ]
             
                you need the path to the file
                    use full path ( drive + directories + filename )
                    or use relative path ( directories + filename )
                    or current directory ( filename )


                
                using (StreamWriter sw = new StreamWriter(filePath)) // this line opens the file to write to it
                {                
                    //these lines write to the file
                    sw.Write("Batman");
                    sw.Write(54);
                    sw.Write(13.7);
                    sw.Write(true);

                }//this closes the file

            */

            string directories = @"C:\temp\2306"; //use @ in front of the string to ignore escape sequences inside the string
            string fileName = "tempFile.txt";
            string filePath = Path.Combine(directories, fileName); //use Path.Combine to get the proper directory separators

            char delimiter = '^';
            //1) open
            using (StreamWriter sw = new StreamWriter(filePath))//file, memory, custom. IDisposable. call Dispose
            {
                //2) write to the file
                sw.Write("Batman rules.");
                sw.Write(delimiter);
                sw.Write(15);
                sw.Write(delimiter);
                sw.Write(7.34);
                sw.Write(delimiter);
                sw.Write(true);
            }//3) close the file


            /*
                CHALLENGE 1:
                    Create a List of Superhero.
                    Write the list to a CSV file             
            */
            List<Superhero> DC = new List<Superhero>()
            {
                new Superhero(){ Name = "Batman", Secret = "Bruce Wayne", Power = Powers.Money },
                new Superhero(){ Name = "Superman", Secret = "Clark Kent", Power = Powers.Jumping },
                new Superhero(){ Name = "Wonder Woman", Secret = "Diana Prince", Power = Powers.Strength },
                new Superhero(){ Name = "Aquaman", Secret = "Arthur Curry", Power = Powers.Swimming }
            };
            string dc = "heroes.csv";
            char csv = '*';
            filePath = Path.Combine(directories, dc);
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var hero in DC)
                {
                    sw.WriteLine($"{hero.Name}{csv}{hero.Secret}{csv}{hero.Power}");
                }
            }



            filePath = Path.Combine(directories, fileName);
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = sr.ReadLine();
                    string[] lineData = line.Split(delimiter);
                    string d1 = lineData[0];
                    int d2 = int.Parse(lineData[1]);
                    double d3 = double.Parse(lineData[2]);
                    bool d4 = bool.Parse(lineData[3]);
                    foreach (var item in lineData)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            else
                Console.WriteLine($"{filePath} could not be found.");



            /*
                ╔═══════════════════╗ 
                ║ Splitting Strings ║
                ╚═══════════════════╝ 

                taking 1 string a separating it into multiple pieces of data

                use the string's Split method

            */
            string csvString = "Batman;Bruce Wayne;Bats;The Dark Knight";
            string[] data = csvString.Split(';');



            /*
                CHALLENGE 2:

                    Open the CSV file and read the data 
                    into a new list of superheroes
             

                    create a superhero list
                    check if the file is there
                    if so, 
                        open the file
                        read the data
                        split to get the array of hero strings
                        loop over the hero strings
                            split the hero string to get the hero data
                            build a superhero with the hero data
                            add the superhero to the list
            */
            List<Superhero> dc2 = new();//create a superhero list
            filePath = Path.Combine(directories, dc);
            if (File.Exists(filePath))//check if the file is there
            {
                /* open the file
                   read the data */
                string dcText = File.ReadAllText(filePath);//Open, Read, Close the file
                //split to get the array of hero strings
                string[] dcData = dcText.Split('\n');
                foreach (var dcItem in dcData)//loop over the hero strings
                {
                    if (string.IsNullOrWhiteSpace(dcItem)) break;
                    //split the hero string to get the hero data
                    string[] heroData = dcItem.Split(csv);
                    Superhero hero = new Superhero() //build a superhero with the hero data
                    {
                        Name = heroData[0],
                        Secret = heroData[1],
                        Power = Enum.Parse<Powers>(heroData[2])
                    };
                    dc2.Add(hero);//add the superhero to the list
                }
            }
            foreach (var dcHero in dc2)
            {
                Console.WriteLine($"{dcHero.Name} ({dcHero.Secret}) can do {dcHero.Power}");
            }





            /*
                ╔═════════════╗ 
                ║ Serializing ║
                ╚═════════════╝ 

                Saving the state (data) of objects

            */



                /*
                 * Challenge 3:
                    Serialize (write) the list of superheroes to a json file
                */




                /*
                    ╔═══════════════╗ 
                    ║ Deserializing ║
                    ╚═══════════════╝ 

                    Recreating the objects from the saved state (data) of objects

                */



                /*

                    Challenge 4: deserialize the jla.json file into a list of superheroes

                */
            }
        }
}