using System;
using System.IO;
using ReactiveUI;

namespace Kastoras.Models;

public class FileModel : ReactiveObject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FullPath { get; set; }
    public long SizeInBytes { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime LastModifiedTime { get; set; }
    public string Extension { get; set; }
}