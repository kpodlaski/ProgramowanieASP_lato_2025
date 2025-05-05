﻿namespace FileOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = { "First linę", "Second line", "Third line" };

            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            docPath = ".";
            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }

            using (StreamReader inputStreamReader = new StreamReader(Path.Combine(docPath, "WriteLines.txt")))
            {
                int c;
                while ( (c = inputStreamReader.Read()) > -1)
                {
                    Console.WriteLine((char) c);
                }
            }

        }
    }
}
