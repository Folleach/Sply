package folleach.sply;

import java.io.*;
import java.util.HashMap;

public class Config
{
    public final String Separator;
    public final char CommentCharacter;

    private HashMap<String, String> _dictionary = new HashMap<>();

    public Config(String separator, char commentCharacter)
    {
        Separator = separator;
        CommentCharacter = commentCharacter;
    }

    public Config(String separator)
    {
        this(separator, '#');
    }

    public Config()
    {
        this("=", '#');
    }

    public int getCount()
    {
        return _dictionary.size();
    }

    public String get(String key)
    {
        return _dictionary.get(key);
    }

    public void Load(String filePath) throws IOException
    {
        File file = new File(filePath);
        BufferedReader reader = new BufferedReader(new FileReader(file));
        for (String line; (line = reader.readLine()) != null; ) {
            if (line.length() == 1 || line.charAt(0) == CommentCharacter)
                continue;
            String[] arr = line.split(Separator, 2);
            _dictionary.put(arr[0], arr[1]);
        }
    }
}
