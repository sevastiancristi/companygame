using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpritesPackage
{
    public enum Department
    {
        CONSTRUCTION = 0,
        ACCOUNTING,
        HUMANRESOURCES,
        SALESANDMARKETING,
        RESEARCHANDDEVELOPMENT,
        INFORMATINOTECHNOLOGY,
        LOGISTICS,
        PROCUREMENT
    }

    private static string[] SpritePaths =
    {
        "UI/Sprites/Construction",
        "UI/Sprites/Accounting",
        "UI/Sprites/HumanResources",
        "UI/Sprites/SalesAndMarketing",
        "UI/Sprites/ResearchAndDevelopment",
        "UI/Sprites/InformationTechnology",
        "UI/Sprites/Logistics",
        "UI/Sprites/Procurement"
    };

    private static SpritesPackage _instance = null;
    public static SpritesPackage Instance
    {
        get
        {
            if(_instance == null)
                _instance = new SpritesPackage();
            return _instance;
        }
    }

    private Dictionary<string, Sprite> spritesMap = new Dictionary<string, Sprite>();

    public Sprite getSpriteFor(Department department)
    {
        return getSpriteFromPath(SpritePaths[(int)department]);
    }

    public Sprite getSpriteFromPath(string spritePath)
    {
        if (spritesMap.ContainsKey(spritePath))
        {
            return spritesMap[spritePath];
        }
        else
        {
            Sprite sprite = Resources.Load<Sprite>(spritePath);
            if (sprite == null)
                Debug.LogError("Sprite not existent!");
            spritesMap.Add(spritePath, sprite);
            return sprite;
        }
    }

    public Sprite getSpriteFromMulti(string spritePath, string spriteName)
    {
        string fullPath = spritePath + "/" + spriteName;
        if (spritesMap.ContainsKey(fullPath))
        {
            return spritesMap[fullPath];
        }
        else
        {
            Sprite sprite = Resources.LoadAll<Sprite>(spritePath).Single(s => s.name == spriteName);
            if (sprite == null)
                Debug.LogError("Sprite not existent!");
            spritesMap.Add(fullPath, sprite);
            return sprite;
        }
    }
}
