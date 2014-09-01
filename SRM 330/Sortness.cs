using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class Sortness
{
    public double getSortness(int[] a)
    {
        double sum = 0;
        int l = a.Length;
        for (int i = 0; i < l; i++)
        {
            for (int j = 0; j < l; j++)
            {
                if (i < j)
                {
                    if (a[i] > a[j])
                        sum++;
                }
                else if (i > j)
                {
                    if (a[i] < a[j])
                        sum++;
                }
            }
        }
        return sum / l;
    }

    // CUT begin
    static bool DoTest(int[] a, double __expected)
    {
        DateTime startTime = DateTime.Now;
        Exception exception = null;
        Sortness instance = new Sortness();
        double __result = 0.0;
        try
        {
            __result = instance.getSortness(a);
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
        else if (DoubleEquals(__expected, __result))
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

    static bool DoubleEquals(double a, double b)
    {
        return Math.Abs(a - b) < 1e-9 || Math.Abs(a) > Math.Abs(b) * (1.0 - 1e-9) && Math.Abs(a) < Math.Abs(b) * (1.0 + 1e-9);
    }

    public static void Main(string[] args)
    {
        HashSet<int> cases = new HashSet<int>();
        for (int i = 0; i < args.Length; ++i)
            cases.Add(int.Parse(args[i]));

        Console.Error.WriteLine("Sortness (250 Points)");
        Console.Error.WriteLine();

        int nCases = 0, nPassed = 0;
        using (var reader = File.OpenText("Sortness.sample"))
        {
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null || !line.StartsWith("--"))
                    break;

                int[] a = new int[int.Parse(reader.ReadLine())];
                for (int i = 0; i < a.Length; ++i)
                    a[i] = (int)Convert.ChangeType(reader.ReadLine(), typeof(int));
                reader.ReadLine();
                double __answer = (double)Convert.ChangeType(reader.ReadLine(), typeof(double));

                nCases++;
                if (cases.Count > 0 && !cases.Contains(nCases - 1))
                    continue;
                Console.Error.Write(string.Format("  Testcase #{0} ... ", nCases - 1));
                if (DoTest(a, __answer))
                    nPassed++;
            }
        }

        if (cases.Count > 0)
            nCases = cases.Count;
        Console.Error.WriteLine();
        Console.Error.WriteLine(string.Format("Passed : {0}/{1} cases", nPassed, nCases));

        DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int T = (int)((DateTime.UtcNow - Jan1st1970).TotalSeconds - 1409562724);
        double PT = T / 60.0, TT = 75.0;
        Console.Error.WriteLine(string.Format("Time   : {0} minutes {1} secs", T / 60, T % 60));
        Console.Error.WriteLine(string.Format("Score  : {0:0.00} points", 250 * (0.3 + (0.7 * TT * TT) / (10.0 * PT * PT + TT * TT))));
    }
    // CUT end
}
