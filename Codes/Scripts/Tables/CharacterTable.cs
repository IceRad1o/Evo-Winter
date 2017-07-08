using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterTable : ExUnitySingleton<CharacterTable> {



    public Character[] characters;
    public static bool isInit = false;
    //public Character[] bosses;
    //REID->Character的字典,快速查找ID为X的Character
    public static Dictionary<REID, Character> IDDict = new Dictionary<REID, Character>(100);

    public static Dictionary<Character.RaceType, Character[]> RaceDict = new Dictionary<Character.RaceType, Character[]>(100);
    public static Dictionary<Character.CareerType, Character[]> CareerDict = new Dictionary<Character.CareerType, Character[]>(100);
    public static Dictionary<Character.CampType, Character[]> CampDict = new Dictionary<Character.CampType, Character[]>(100);

    private void Start()
    {
        if(!isInit)
        {
            InitDict();
            isInit = true;
        }
      
      
    }

    public void InitDict()
    {

        for (int i = 0; i < characters.Length; i++)
        {
           
            IDDict.Add(characters[i].RoomElementID, characters[i]);
        }
        foreach (Character.RaceType item in System.Enum.GetValues(typeof(Character.RaceType)))
        {
            RaceDict.Add(item, FindCharacterByRace(item));
        }
        foreach (Character.CareerType item in System.Enum.GetValues(typeof(Character.CareerType)))
        {
            CareerDict.Add(item, FindCharacterByCareer(item));
        }
        foreach (Character.CampType item in System.Enum.GetValues(typeof(Character.CampType)))
        {
            CampDict.Add(item, FindCharacterByCamp(item));
        }
    }
    public Character[] FindCharacterByCamp(Character.CampType camp)
    {
        List<Character> list = new List<Character>();

        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].tag == camp.ToString())
                list.Add(characters[i]);
        }
        return list.ToArray();
    }

    public Character[] FindCharacterByRace(Character.RaceType race)
    {
        List<Character> list = new List<Character>();
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].Race== race)
                list.Add(characters[i]);
        }
        return list.ToArray();
    }

    public Character[] FindCharacterByCareer(Character.CareerType career)
    {
        List<Character> list = new List<Character>();
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].Career== career)
                list.Add(characters[i]);
        }
        return list.ToArray();
    }




}
