using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;
        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }
    //8行14列
    public int rows = 8;
    public int columns = 8;
    public Count wallElementsCount = new Count(2, 6);
    public Count GroundElementsCount = new Count(2, 6);





	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
