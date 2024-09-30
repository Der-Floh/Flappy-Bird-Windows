namespace Flappy_Bird_Windows.Data.Config;

[AttributeUsage(AttributeTargets.Class)]
public class ConfigSectionAttribute(string sectionName) : Attribute
{
    public string SectionName { get; } = sectionName;
}

