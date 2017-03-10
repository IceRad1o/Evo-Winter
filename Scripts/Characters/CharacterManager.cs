using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CharacterManager :ExUnitySingleton<CharacterManager>
{

    List<Character> characterList = new List<Character>();

    public List<Character> CharacterList
    {
        get { return characterList; }
        set { characterList = value; }
    }


 
}
