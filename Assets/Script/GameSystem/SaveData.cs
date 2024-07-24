using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public string Name;
    public int Level;
    public int MaxHp;
    public List<int> Materials;

    public SaveData(string name, int level, int maxHp, List<int> materials)
    {
        this.Name = name;
        this.Level = level;
        this.MaxHp = maxHp;
        this.Materials = materials;
    }
}
