using System;
using System.IO;
using System.Text;

namespace Kastoras.Models;

public class NoteModel : FileModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; private set; }
    public DateTime LastAccessTime { get; private set; }
    private string[] _tags;
    public string[] Tags { get; set; }

    public NoteModel(string filePath)
    {
        Title = Path.GetFileNameWithoutExtension(Name);
        Content = ReadContent();
        LastAccessTime = File.GetLastAccessTime(filePath);
        _tags = new string[0]; // Initialize with empty array
    }

    public string ReadContent()
    {
        try
        {
            Content = File.ReadAllText(FullPath);
            LastAccessTime = DateTime.Now;
            return Content;
        }
        catch (IOException ex)
        {
            throw new IOException($"Error reading note content: {ex.Message}", ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new UnauthorizedAccessException($"Access denied when reading note content: {ex.Message}", ex);
        }
    }

    public bool UpdateContent(string newContent)
    {
        try
        {
            File.WriteAllText(FullPath, newContent);
            Content = newContent;
            LastModifiedTime = DateTime.Now;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool AppendContent(string additionalContent)
    {
        try
        {
            using (StreamWriter sw = File.AppendText(FullPath))
            {
                sw.WriteLine(additionalContent);
            }
            Content += Environment.NewLine + additionalContent;
            LastModifiedTime = DateTime.Now;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void AddTag(string tag)
    {
        Array.Resize(ref _tags, _tags.Length + 1);
        _tags[_tags.Length - 1] = tag;
    }

    public void RemoveTag(string tag)
    {
        _tags = Array.FindAll(_tags, t => t != tag);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Note: {Title}");
        sb.AppendLine($"Last Modified: {LastModifiedTime}");
        sb.AppendLine($"Tags: {string.Join(", ", Tags)}");
        sb.AppendLine($"Content Preview: {(Content.Length > 50 ? Content.Substring(0, 50) + "..." : Content)}");
        return sb.ToString();
    }
}