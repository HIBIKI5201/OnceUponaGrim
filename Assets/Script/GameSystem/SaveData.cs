using System;

[Serializable]
public class SaveData
{
    public string Name;
    public int Level;
    public int MaxHp;

    public SaveData(string name, int level, int maxHp)
    {
        this.Name = name;
        this.Level = level;
        this.MaxHp = maxHp;
    }
}
