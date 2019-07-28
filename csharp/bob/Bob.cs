using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class Bob
{
    private static class Responses
    {
        public const string ShoutedStatement = "Whoa, chill out!";
        public const string ShoutedQuestion = "Calm down, I know what I'm doing!";
        public const string Question = "Sure.";
        public const string EmptyStatement = "Fine. Be that way!";
        public const string AnythingElse = "Whatever.";
    }

    public static string Response(string statement)
    {
        statement = statement.Trim();                                       // Remove leading and trailing whitespace from the statement

        if (statement == String.Empty) return Responses.EmptyStatement;      // Statement is null or empty or just whitespace. Exit here.

        var regex = new Regex("[a-zA-Z]");                                  // Prepare regex used for finding any English Roman alphabet letters

        // Create an integer by using binary operators to add 1/0 when statement properties are true/false
        int statementProperties = statement.EndsWith("?") ? 1 << 1 : 0;                                             // Is statement a question? 00/0 if not, 10/2 if so
        statementProperties |= (regex.Match(statement).Success && statement.ToUpper().Equals(statement)) ? 1 : 0;   // Is statement shouted? 00/0 if not, 01/1 if so

        switch (statementProperties)
        {
            case 1:
                return Responses.ShoutedStatement;
            case 2:
                return Responses.Question;
            case 3:
                return Responses.ShoutedQuestion;
        }

        return Responses.AnythingElse;
    }
}