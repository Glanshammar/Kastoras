using System;
using System.IO;
using Kastoras.Models;

namespace Kastoras.Services;

public class FileService
{
    public FileModel CreateFromFilePath(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("The specified file does not exist.", filePath);

        FileInfo fileInfo = new(filePath);
        return new FileModel
        {
            Name = fileInfo.Name,
            FullPath = fileInfo.FullName,
            SizeInBytes = fileInfo.Length,
            CreationTime = fileInfo.CreationTime,
            LastModifiedTime = fileInfo.LastWriteTime,
            Extension = fileInfo.Extension
        };
    }

    public string GetSizeFormatted(FileModel file)
    {
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        int order = 0;
        double size = file.SizeInBytes;

        while (size >= 1024 && order < sizes.Length - 1)
        {
            order++;
            size /= 1024;
        }

        return $"{size:0.##} {sizes[order]}";
    }

    public bool Delete(FileModel file)
    {
        try
        {
            File.Delete(file.FullPath);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Rename(FileModel file, string newName)
    {
        try
        {
            string newPath = Path.Combine(Path.GetDirectoryName(file.FullPath), newName);
            File.Move(file.FullPath, newPath);
            
            // Update model properties
            file.FullPath = newPath;
            file.Name = newName;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public string GetFileDescription(FileModel file)
    {
        return $"File: {file.Name}, Size: {GetSizeFormatted(file)}, Created: {file.CreationTime}";
    }
}