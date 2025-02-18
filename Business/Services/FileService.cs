﻿using Business.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Services;

public class FileService : IFileService
{

    private readonly string _directoryPath;
    private readonly string _filePath;

    public FileService(string directoryPath, string fileName)
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
    }



    public bool SaveContentToFile(string content)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);

            
            File.WriteAllText(_filePath,content);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }


    public string GetContentFromFile()
    {

        if (File.Exists(_filePath))
            return File.ReadAllText(_filePath);


        return null!;

    }
}
