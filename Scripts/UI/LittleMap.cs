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
    public Sprite gridStayed;
    public Sprite gridAccessible;
    public Sprite gridExist;
    public Button mapButton;    //地图按钮
    public GameObject grid;

    List<GameObject> gridList = new List<GameObject>();
    int rows;
    int columns;
    int maxRows=6;
    int maxColumns=6;
	void Start () {

        InitLittleMap();
        UpdateLittleMap();
     

	}
   public  void InitLittleMap()
    {
        rows = CheckpointManager.Instance.rows;
        columns = CheckpointManager.Instance.columns;
   
        for (int i = 0; i < maxRows; i++)
            for (int j = 0; j <maxColumns; j++)
            {
                
                GameObject obj = Instantiate(grid, this.gameObject.transform, true) as GameObject;
                obj.GetComponent<RectTransform>().localPosition = new Vector3(40 * j - 120, 120-40*i, 0);
                obj.SetActive(false);
                gridList.Add(obj);
            }
    }


    /// <summary>
    /// 更新小地图
    /// </summary>
    public void UpdateLittleMap()
    {
        int[,] map = CheckpointManager.Instance.roomArray;
        rows = CheckpointManager.Instance.rows;
        columns = CheckpointManager.Instance.columns;


        int roomX = RoomManager.Instance.roomX;
        int roomY = RoomManager.Instance.roomY;

        if (map==null)
        {
            Debug.Log("Map is null");
            return;
        }
        //先根据通过与否分成已知的和未知的和可接近的
        for(int i=0;i<rows;i++)
            for(int j=0;j<columns;j++)
            {
                if (map[i, j] == 0)
                {
                    gridList[i * maxRows + j].SetActive(false);
                }
                else
                {
                    gridList[i * maxRows + j].SetActive(true);
                    if(CheckpointManager.Instance.GetNextRoom(i, j).pass==1)
                        gridList[i * maxRows + j].GetComponent<Image>().sprite = gridKnow;
                    else if ((i <= roomX + 1 && i >= roomX - 1&&j==roomY) ||( j <= roomY + 1 && j >= roomY - 1&&i==roomX))
                        gridList[i * maxRows + j].GetComponent<Image>().sprite = gridAccessible;
                    else
                        gridList[i * maxRows + j].GetComponent<Image>().sprite = gridExist;

                  
                }

            }

        gridList[roomX * maxRows + roomY].GetComponent<Image>().sprite = gridStayed;

   

    }



}
