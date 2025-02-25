using System;
using System.IO;
using System.Text;
using Kastoras.Models;

namespace Kastoras.Services;

public class NotesService
{
    private readonly FileService _fileService = new();

    public NoteModel CreateNoteFromFilePath(string filePath)
    {
        var fileModel = _fileService.CreateFromFilePath(filePath);
        return new NoteModel(fileModel);
    }

    public string ReadContent(NoteModel note)
    {
        try
        {
            note.Content = File.ReadAllText(note.File.FullPath);
            note.LastAccessTime = DateTime.Now;
            return note.Content;
        }
        catch (IOException ex)
        {
            throw new IOException($"Error reading note content: {ex.Message}", ex);
        }
    }

    public bool UpdateContent(NoteModel note, string newContent)
    {
        try
        {
            File.WriteAllText(note.File.FullPath, newContent);
            note.Content = newContent;
            note.File.LastModifiedTime = DateTime.Now;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool AppendContent(NoteModel note, string additionalContent)
    {
        try
        {
            File.AppendAllText(note.File.FullPath, Environment.NewLine + additionalContent);
            note.Content += Environment.NewLine + additionalContent;
            note.File.LastModifiedTime = DateTime.Now;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void AddTag(NoteModel note, string tag)
    {
        note.Tags.Add(tag);
    }

    public void RemoveTag(NoteModel note, string tag)
    {
        note.Tags.Remove(tag);
    }

    public string GetNoteDescription(NoteModel note)
    {
        StringBuilder sb = new();
        sb.AppendLine($"Note: {note.Title}");
        sb.AppendLine($"Last Modified: {note.File.LastModifiedTime}");
        sb.AppendLine($"Tags: {string.Join(", ", note.Tags)}");
        sb.AppendLine($"Content Preview: {(note.Content.Length > 50 ? note.Content[..50] + "..." : note.Content)}");
        return sb.ToString();
    }
}