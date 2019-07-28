using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets = 'V',
    Radishes = 'R',
    Clover = 'C',
    Grass = 'G'
}

public enum Children
{
    // Integers act as Child ID and will increase by 1 all the way up to Larry at 12
    Alice = 1, Bob, Charlie, David,
    Eve, Fred, Ginny, Harriet,
    Ileana, Joseph, Kincaid, Larry

}

public class KindergartenGarden
{
    private Dictionary<int, List<Plant>> StudentsToPlants = new Dictionary<int, List<Plant>>();

    public KindergartenGarden(string diagram)
    {
        string[] rows = diagram.Split("\n");

        foreach (string row in rows)
        {

            //Turn string row into collection of Tuples
            IEnumerable<(int, Plant)> plantRow = row.Select((plantChar, i) 
                => (((i + 1) + (i + 1) % 2) / 2,        // Child ID for each pair, increases by 1 every 2 times. Offset i by 1 as begins as 0
                (Plant)plantChar));                     // Char literal casts to a Plant as per Enum lookup

            foreach ((int studentNo, Plant theirPlant) in plantRow)
            {
                // Populate the Dictionary with Child ID as the key, List<Plant> as the value
                
                if (!StudentsToPlants.TryGetValue(studentNo, out List<Plant> theirPots))
                    StudentsToPlants[studentNo] = theirPots = new List<Plant>();

                theirPots.Add(theirPlant);
            }
        } 
    }

    public IEnumerable<Plant> Plants(string student)
    {
        return StudentsToPlants[(int)Enum.Parse(typeof(Children), student)];
    }
    
}