using System;
using System.Collections.Generic;
using System.IO;

namespace Kastoras.Models;

public class NoteModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; internal set; }
    public DateTime LastAccessTime { get; internal set; }
    public List<string> Tags { get; set; }
    public FileModel File { get; }

    public NoteModel(FileModel fileModel)
    {
        File = fileModel;
        Title = Path.GetFileNameWithoutExtension(fileModel.Name);
        Tags = new List<string>();
    }
}