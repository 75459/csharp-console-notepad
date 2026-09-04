using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ConsoleNotepad;

internal class StorageService
{
    private readonly string _filePath;
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };


    public StorageService(string filePath)
    {
        _filePath = filePath;
    }

    public void Save<T>(T data)
    {
        string jsonValue = JsonSerializer.Serialize(data, _options);
        File.WriteAllText(_filePath, jsonValue);
    }

    public T Load<T>() where T : new()
    {
        if (!File.Exists(_filePath))
        {
            return new T();
        }

        try
        {
            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<T>(json, _options) ?? new T();

        }
        catch (JsonException)
        {
            return new T();
        }
    }

}
