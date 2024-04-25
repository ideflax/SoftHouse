using Assignment;
using System.ComponentModel.Design;
using System.IO;
using System.IO.Pipes;
using System.Xml.Serialization;

internal class SHAConsoleApp
{
    private static void Main(string[] args)
    {
        FileStream fileStream = File.OpenRead("fileBased.txt");
        StreamReader streamReader = new StreamReader(fileStream);
        People people = new People();
        people.Person = new List<Person>();
        Person? currentPerson = null;
        Family? currentFamily = null;
        string line;

        while ((line = streamReader.ReadLine()) != null)
        {

            List<string> row = line.Split("|").ToList();
            string? rowType = row.FirstOrDefault();
            if (rowType == null)
            {
                //Invalid row format
                continue;
            }
            else
            {
                switch(rowType)
                {
                    case "P":
                        currentPerson = new Person();
                        currentPerson.Firstname = row[1];
                        currentPerson.Lastname = row[2];
                        people.Person.Add(currentPerson);
                        currentFamily = null;       //New person in created, clear if there's a family from previous person
                        break;
                    case "T":
                        if (currentFamily != null)      //If a family node is added for the current person, the following data always belong to family node.
                        {
                            currentFamily.Phone = new Phone();
                            currentFamily.Phone.Mobile = row.ElementAtOrDefault(1);
                            currentFamily.Phone.LandLine = row.ElementAtOrDefault(2);
                        }
                        else if (currentPerson != null)
                        {
                            currentPerson.Phone = new Phone();
                            currentPerson.Phone.Mobile = row.ElementAtOrDefault(1);
                            currentPerson.Phone.LandLine = row.ElementAtOrDefault(2);
                        }
                        else
                        {
                            //No Node to attach phone number to, implement error handling
                        }
                        break;
                    case "A":
                        if (currentFamily != null)      //If a family node is added for the current person, the following data always belong to family node.
                        {
                            currentFamily.Address = new Address();
                            currentFamily.Address.Street = row.ElementAtOrDefault(1);
                            currentFamily.Address.City = row.ElementAtOrDefault(2);
                            currentFamily.Address.ZipCode = row.ElementAtOrDefault(3);
                        }
                        else if (currentPerson != null)
                        {
                            currentPerson.Address = new Address();
                            currentPerson.Address.Street = row.ElementAtOrDefault(1);
                            currentPerson.Address.City = row.ElementAtOrDefault(2);
                            currentPerson.Address.ZipCode = row.ElementAtOrDefault(3);                            
                        }
                        else
                        {
                            //No node to attach Adress to, implement error handling
                        }
                        break;
                    case "F":
                        if(currentPerson != null)
                        {
                            if (currentPerson.Family == null)
                                currentPerson.Family = new List<Family>();
                            currentFamily = new Family();
                            currentFamily.Name = row.ElementAtOrDefault(1);
                            currentFamily.Born = row.ElementAtOrDefault(2);
                            currentPerson.Family.Add(currentFamily);
                        }
                        else
                        {
                            //No Node to attach Family to, implement error handling.
                        }
                        break;

                    default:
                        //Check format of input file, implement error handling.
                        break;
                }
            }     
        }
        XmlSerializer serializer = new XmlSerializer(typeof(People));
        serializer.Serialize(Console.Out, people);
        FileStream fs = File.Create("output.xml");
        serializer.Serialize(fs, people);
        Console.WriteLine();
        Console.ReadLine();
    }
}
