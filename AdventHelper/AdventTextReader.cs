namespace AdventHelper
{
    public static class AdventTextReader
    {
        public static List<int> GetNumberListFromFile(string textFile)
        {
            List<int> codes = new List<int>();
            FileStream fileStream = new FileStream(textFile, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        if (int.TryParse(line, out int code))
                        {
                            codes.Add(code);
                        }
                    }
                }
            }
            return codes;
        }
        public static List<string> GetListFromFile(string textFile)
        {         
            return GetListFromFile(textFile, false);
        }
        public static List<string> GetListFromFile(string textFile, bool includeWhiteSpace)
        {
            List<string> lines = new List<string>();
            FileStream fileStream = new FileStream(textFile, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line) && includeWhiteSpace)
                    {
                        lines.Add(line);
                    }
                    else
                    {
                        if (line is null)
                            lines.Add(string.Empty);
                        else
                            lines.Add(line);
                    }
                }
            }
            return lines;
        }
        public static List<int> GetSingleIntListFromFile(string textFile)
        {
            List<int> lines = new List<int>();
            FileStream fileStream = new FileStream(textFile, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] text = line.Split(',');
                        foreach (var numberText in text)
                        {
                            int number = int.Parse(numberText);
                            lines.Add(number);
                        }
                    }
                }
            }
            return lines;
        }
    }
}