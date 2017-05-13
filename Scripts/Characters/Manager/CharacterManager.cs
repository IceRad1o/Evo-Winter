using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// CharacterManager
/// Brief: For Management of all characters
/// Author: IfYan
/// Latest Update Time: 2017.5.11
/// </summary>
public class CharacterManager :ExUnitySingleton<CharacterManager>
{
   
    List<Character> characterList = new List<Character>();

    public List<Character> CharacterList
    {
        get { return characterList; }
        set { characterList = value; }
    }


 
}
