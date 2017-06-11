using UnityEngine;
using System.Collections;
/// <summary>
/// Includes Preference Animations
/// </summary>
public class ActionManager : ExUnitySingleton<ActionManager> {

    static public void DisplayUIObject(GameObject gameObject)
    {
        gameObject.transform.localScale = Vector3.zero;
     
        gameObject.AddComponent<ScaleTo>().Init(0.1f, Vector4.one, false, false, true);
    }

    static public void UndisplayUIObject(GameObject gameObject)
    {
        gameObject.AddComponent<ScaleTo>().Init(0.1f, Vector4.zero, false, false, true);
    }
}
