using System;
using System.Xml;

public class ConfigReader
{
    private readonly XmlDocument _doc;

    public ConfigReader(string xmlPath)
    {
        _doc = new XmlDocument();
        _doc.Load(xmlPath);
    }

    public int GetInt(string key, int defaultValue)
    {
        string val = _doc.SelectSingleNode($"//setting[@key='{key}']")?.InnerText;
        return int.TryParse(val, out int result) ? result : defaultValue;
    }

    public bool GetBool(string key, bool defaultValue)
    {
        string val = _doc.SelectSingleNode($"//setting[@key='{key}']")?.InnerText;
        return bool.TryParse(val, out bool result) ? result : defaultValue;
    }

    public DateTime GetDate(string key, DateTime defaultValue)
    {
        string val = _doc.SelectSingleNode($"//setting[@key='{key}']")?.InnerText;
        return DateTime.TryParse(val, out DateTime result) ? result : defaultValue;
    }

    // Example usage
    public static void Main()
    {
        // Sample XML: create a test file called "config.xml"
        /*
        <config>
            <setting key="isEnabled">true</setting>
            <setting key="maxUsers">1000</setting>
            <setting key="launchDate">2025-07-01</setting>
        </config>
        */

        ConfigReader reader = new ConfigReader("config.xml");

        bool isEnabled = reader.GetBool("isEnabled", false);
        int maxUsers = reader.GetInt("maxUsers", 10);
        DateTime launchDate = reader.GetDate("launchDate", DateTime.Now);

        Console.WriteLine($"Enabled: {isEnabled}");
        Console.WriteLine($"Max Users: {maxUsers}");
        Console.WriteLine($"Launch Date: {launchDate:yyyy-MM-dd}");
    }
}
