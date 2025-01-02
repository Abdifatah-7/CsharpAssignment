using Business.Interfaces;

namespace Business.Services
{
    public class FileService : IFileService
    {
        private readonly string _directoryPath;
        private readonly string _fileName;
        public FileService(string directoryPath = "Data", string fileName = "List.json")
        {
            
        }
        public string GetContentFromFile()
        {
            throw new NotImplementedException();
        }

        public bool SaveContentToFile(string content)
        {
            throw new NotImplementedException();
        }
    }
}
