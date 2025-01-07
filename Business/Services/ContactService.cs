using Business.Interfaces;
using Business.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Services;

public class ContactService(IFileService fileService) : IContactService
{
    private readonly IFileService _fileService = fileService;
    private List<Contact> _contacts = [];

    public bool CreateContact(Contact contact)
    {
         GetDataFromFile();
        _contacts.Add(contact);
        var result = SaveDataToFile();
        return result;
    }




    public IEnumerable<Contact> GetAllContacts()
    {
       GetDataFromFile();
        return _contacts;
    }

    public bool SaveDataToFile()
    {
        try
        {
            var json =JsonSerializer.Serialize(_contacts);
            _fileService.SaveContentToFile(json);

            return true;
             
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }




    public bool GetDataFromFile()
    {
        try
            {
            var json = _fileService.GetContentFromFile();

            if (!string.IsNullOrEmpty(json))
            {
                _contacts = JsonSerializer.Deserialize<List<Contact>>(json)!;
                 return true;
            }
        }
        catch(Exception ex)
        {
        
            Debug.WriteLine(ex.Message);
            _contacts = [];          
        }
        return false;
    }


   

}
