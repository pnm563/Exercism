using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private SortedDictionary<int, SortedSet<string>> TheRoster { get; set; } = new SortedDictionary<int, SortedSet<string>>();

    public void Add(string student, int grade)
    {
        if (!TheRoster.ContainsKey(grade)) TheRoster[grade] = new SortedSet<string>();

        TheRoster[grade].Add(student);
    }

    public IEnumerable<string> Roster() => TheRoster.SelectMany(x => x.Value);

    public IEnumerable<string> Grade(int grade) => TheRoster.ContainsKey(grade) ? TheRoster[grade].ToArray() : new string[0];
}