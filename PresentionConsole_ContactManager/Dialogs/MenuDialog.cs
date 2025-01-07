using Business.Factories;
using Business.Interfaces;
using Business.Services;

namespace PresentionConsole_ContactManager.Dialogs;

public class MenuDialog(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;


    public void RunMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("######## MAIN MENU #######");
            Console.WriteLine("1. Add New Contact");
            Console.WriteLine("2. View All Contacts");
            Console.WriteLine("3. Avsluta");
            Console.Write("Select Option: ");
            var option = Console.ReadLine()!;

            switch (option)
            {
                case "1":

                   Console.Clear();
                   AddNewContact();
            
                    break;

                case "2":                   
                    ViewAllContacts();
                    Console.ReadKey();

                    break;
                case "3":
                   
                    QuitProgram();
                    Console.ReadKey();

                    break;
                default:
                    
                    InvalidOption();
                    Console.ReadKey();

                    break;

            }



        }


    }

    public void AddNewContact()
    {
        var contact = ContactFactory.Create();

        Console.Clear();
        Console.WriteLine("######## ADD NEW CONTACT #######");

        Console.Write("Enter firstName: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Enter lastname: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("Enter Email: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Enter Phone Number: ");
        contact.PhoneNumber = Console.ReadLine()!;

        Console.Write("Enter City : ");
        contact.City = Console.ReadLine()!;

        Console.Write("Enter adress: ");
        contact.StreetAddress = Console.ReadLine()!;

        Console.Write("Enter Your postcode: ");
        contact.PostalCode = Console.ReadLine()!;

        Console.WriteLine("-------------------------------------");

        var result =_contactService.CreateContact(contact);
        if (result)
            Console.WriteLine("Contact has been Created Successfully.!!!!");
        else
            Console.WriteLine("Unable to create Contact.!!!");
        Console.ReadKey();
    }

    public void ViewAllContacts()
    {
        
        var contacts = _contactService.GetAllContacts();
        Console.Clear();

        foreach (var contact in contacts)
        {
            Console.WriteLine("######## VIEW ALL CONTACTS #######");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Id: {contact.Id}");
            Console.WriteLine($"Firstname: {contact.FirstName}");
            Console.WriteLine($"Lastname: {contact.LastName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Phone: {contact.PhoneNumber}");
            Console.WriteLine($"City : {contact.City}");
            Console.WriteLine($"Adressen: {contact.StreetAddress}");
            Console.WriteLine($"PostCode: {contact.PostalCode}");


        }

        /* Detta är genererat av Chat GPT 4o - Denna kod gör så att om det finns inte något Kontakt så skriva att det inte finns nångot kontakt*/

        if (!contacts.Any())
        {
            Console.WriteLine("No contacts found.");
        }

    }

    public static void QuitProgram()
    {
        Console.WriteLine("Du har avslutat programmet ");
        Environment.Exit(0);
    }

    public static void InvalidOption()

    {
        Console.WriteLine("You must enter a valid option please");
        Console.WriteLine("CHOOSE BEWTEEN THE CHOICES 1 TO 3");



    }


}
