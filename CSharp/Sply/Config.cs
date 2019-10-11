using System;
using System.Collections.Generic;
using System.IO;

namespace Sply
{
    public class Config
    {
        public readonly char Separator;
        public readonly char CommentCharacter;

        public Dictionary<string, string> _dictionary = new Dictionary<string, string>();

        public string this[string key]
        {
            get => _dictionary.ContainsKey(key) ? _dictionary[key] : key;
        }

        public int Length
        {
            get => _dictionary.Count;
        }

        public Config(char separator = '=', char commentCharacter = '#')
        {
            Separator = separator;
            CommentCharacter = commentCharacter;
        }

        public void Load(string filePath)
        {
            string[] config = File.ReadAllLines(filePath);
            string[] line;
            char[] separetor = new char[] { Separator };
            foreach (string fLine in config)
            {
                if (string.IsNullOrEmpty(fLine) || fLine.IndexOf(CommentCharacter) == 0)
                    continue;
                line = fLine.Split(separetor, 2);
                _dictionary.Add(line[0], line[1]);
            }
        }
    }
}
