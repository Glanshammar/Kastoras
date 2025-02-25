using System;
using System.Collections.Generic;
using HarfBuzzSharp;
using Kastoras.Enums;

namespace Kastoras.Models;

public enum MoodLevel { Happy, Neutral, Sad, Anxious }
public enum MeditationType { Mindfulness, Stress, Focus, Sleep, Compassion, Zen, Vipassana, Metta, Mantra, Transcendental, Chakra, Qigong }

public class MoodEntry
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public MoodLevel Mood { get; set; }
    public string Notes { get; set; }
}

public class MeditationSession
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int DurationMinutes { get; set; }
    public MeditationType Type { get; set; }
}

public class JournalEntry
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public List<Tag> Tags { get; set; }
    public MoodEntry? MoodEntry { get; set; }
}