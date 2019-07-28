using System;
using System.Collections.Generic;

public class Robot
{
    private static List<string> RobotCrew { get; set; } = new List<string>();

    private string _name;
    
    public string Name
    {
        get
        {
            if (_name == null)
            {
                string newName = GenerateName();

                while (RobotCrew.Contains(newName))
                {
                    newName = GenerateName();
                }
                RobotCrew.Add(newName);
                _name = newName;
                return newName;
            }
            else
            {
                return _name;
            }
        }
        set
        {
            _name = value;
        }
    }

    public void Reset()
    {
        //RobotCrew.Remove(Name); // had to remove or previous serial numbers would reappear
        Name = null;
    }

    public string GenerateName()
    {
        Random rnd = new Random();
        Func<char> getLetter = () => (char)rnd.Next(65, 91); // inclusive minimum, exclusive maximum
        Func<char> getNumber = () => (char)rnd.Next(48, 58);

        char[] robotName = new char[5];
        
        robotName[0] = getLetter();
        robotName[1] = getLetter();
        robotName[2] = getNumber();
        robotName[3] = getNumber();
        robotName[4] = getNumber();

        return new string(robotName);
    }
}