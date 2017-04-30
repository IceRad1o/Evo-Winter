using UnityEngine;

public class UnitySingleton<T> : MonoBehaviour
        where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    //obj.hideFlags = HideFlags.DontSave;  
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    _instance = (T)obj.AddComponent(typeof(T));
                    
                }
            }
            return _instance;
        }
    }
    public virtual void Awake()
    {
        
        //DontDestroyOnLoad(this.gameObject);
        if (_instance == null)
        {
            _instance = this as T;
        }
        else
        {
            //Debug.LogError("111");
            Destroy(gameObject);
        }
    }
}





public class ExUnitySingleton<T> : ExSubject
        where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    //obj.hideFlags = HideFlags.DontSave;  
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    _instance = (T)obj.AddComponent(typeof(T));
                }
            }
            return _instance;
        }
    }
    public virtual void Awake()
    {
        
        //DontDestroyOnLoad(this.gameObject);

        if (_instance == null)
        {
            _instance = this as T;
        }
        else
        {
            //Debug.LogError("111");
            Destroy(gameObject);
            if (_instance == null)
                Debug.Log("Test Itstance  null");
            else
                Debug.Log("Test Itstance  not null");
            //Destroy(_instance);
            //_instance = this as T;
        }
    }
}