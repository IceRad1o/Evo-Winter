using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Author YYF
/// 小地图模块
/// </summary>
public class LittleMap : ExUnitySingleton<LittleMap>{

    public Sprite gridKnow;
    public Sprite gridUnknow;
    public Sprite gridExist;
    public Button mapButton;    //地图按钮
    public GameObject grid;

    List<GameObject> gridList = new List<GameObject>();
    int rows;
    int columns;
	void Start () {

        InitLittleMap();
        StartCoroutine(Timing());

	}
   public  void InitLittleMap()
    {
        rows = CheckpointManager.Instance.rows;
        columns = CheckpointManager.Instance.columns;

        for (int i = 0; i < rows; i++)
            for (int j = 0; j <columns; j++)
            {
                
                GameObject obj = Instantiate(grid, this.gameObject.transform, true) as GameObject;
                obj.GetComponent<RectTransform>().localPosition = new Vector3(40 * j - 120, 120-40*i, 0);
                gridList.Add(obj);
            }
    }

    IEnumerator Timing()
    {
        yield return new WaitForSeconds(1);
        UpdateLittleMap();
    }
    //初始化小地图
    public void UpdateLittleMap()
    {
        int[,] map = CheckpointManager.Instance.roomArray;
        rows = CheckpointManager.Instance.rows;
        columns = CheckpointManager.Instance.columns;


        for(int i=0;i<rows;i++)
            for(int j=0;j<columns;j++)
            {
                //if (map[j, i] == 0)
                //{
                //    gridList[(i)*rows+ rows-1-j].SetActive(false);
                //}
                if (map[i, j] == 0)
                {
                    gridList[i * rows + j].SetActive(false);
                }
                else
                {
                    if(CheckpointManager.Instance.GetNextRoom(i, j).pass==1)
                        gridList[i * rows + j].GetComponent<Image>().sprite = gridUnknow;
                    else
                        gridList[i * rows + j].GetComponent<Image>().sprite = gridExist;
                }

            }

        int roomX = RoomManager.Instance.roomX;
        int roomY = RoomManager.Instance.roomY;
        gridList[roomX * rows + roomY].GetComponent<Image>().sprite = gridKnow;
        if (roomX - 1 >= 0)
            gridList[(roomX-1) * rows + roomY].GetComponent<Image>().sprite = gridUnknow;
        if (roomX + 1 >= 0)
            gridList[(roomX+1) * rows  + roomY].GetComponent<Image>().sprite = gridUnknow;
        if (roomY - 1 >= 0)
            gridList[roomX * rows + roomY - 1].GetComponent<Image>().sprite = gridUnknow;
        if (roomY + 1 >= 0)
            gridList[roomX * rows + roomY + 1].GetComponent<Image>().sprite = gridUnknow;
   

    }



}
