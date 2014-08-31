using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class WhiteCells
{
    public int countOccupied(string[] board)
    {
        int sum = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    if (board[i][j] == 'F')
                    {
                        sum++;
                    }
                }
            }
        }
        return sum;
    }

    // CUT begin
    static bool DoTest(string[] board, int __expected)
    {
        DateTime startTime = DateTime.Now;
        Exception exception = null;
        WhiteCells instance = new WhiteCells();
        int __result = 0;
        try
        {
            __result = instance.countOccupied(board);
        }
        catch (Exception e)
        {
            exception = e;
        }
        TimeSpan __elapsed = new TimeSpan(DateTime.Now.Ticks - startTime.Ticks);

        if (exception != null)
        {
            Console.Error.WriteLine("RUNTIME ERROR!");
            Console.Error.WriteLine(exception);
            return false;
        }
        else if (__result == __expected)
        {
            Console.Error.WriteLine("PASSED! " + string.Format("({0:0.00} seconds)", __elapsed.TotalSeconds));
            return true;
        }
        else
        {
            Console.Error.WriteLine("FAILED! " + string.Format("({0:0.00} seconds)", __elapsed.TotalSeconds));
            Console.Error.WriteLine("           Expected: " + __expected);
            Console.Error.WriteLine("           Received: " + __result);
            return false;
        }
    }

    public static void Main(string[] args)
    {
        HashSet<int> cases = new HashSet<int>();
        for (int i = 0; i < args.Length; ++i)
            cases.Add(int.Parse(args[i]));

        Console.Error.WriteLine("WhiteCells (250 Points)");
        Console.Error.WriteLine();

        int nCases = 0, nPassed = 0;
        using (var reader = File.OpenText("WhiteCells.sample"))
        {
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null || !line.StartsWith("--"))
                    break;

                string[] board = new string[int.Parse(reader.ReadLine())];
                for (int i = 0; i < board.Length; ++i)
                    board[i] = (string)Convert.ChangeType(reader.ReadLine(), typeof(string));
                reader.ReadLine();
                int __answer = (int)Convert.ChangeType(reader.ReadLine(), typeof(int));

                nCases++;
                if (cases.Count > 0 && !cases.Contains(nCases - 1))
                    continue;
                Console.Error.Write(string.Format("  Testcase #{0} ... ", nCases - 1));
                if (DoTest(board, __answer))
                    nPassed++;
            }
        }

        if (cases.Count > 0)
            nCases = cases.Count;
        Console.Error.WriteLine();
        Console.Error.WriteLine(string.Format("Passed : {0}/{1} cases", nPassed, nCases));

        DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int T = (int)((DateTime.UtcNow - Jan1st1970).TotalSeconds - 1409497817);
        double PT = T / 60.0, TT = 75.0;
        Console.Error.WriteLine(string.Format("Time   : {0} minutes {1} secs", T / 60, T % 60));
        Console.Error.WriteLine(string.Format("Score  : {0:0.00} points", 250 * (0.3 + (0.7 * TT * TT) / (10.0 * PT * PT + TT * TT))));
    }
    // CUT end
}
