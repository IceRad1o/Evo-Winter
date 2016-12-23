 *DisposableItem
 *@Brief 一次性使用道具
 *@Author CEJ
 *@Time 16.12.23
 *@API

 SetUsingNumber
	*@SetUsingNumber
    	*@设置一次性道具的使用次数
     	*@number  将次数设置为number

 GetUsingNumber
	*@GetUsingNumber
     	*@获得一次性道具的使用次数    
 
 Use
	*@Use
   	*@一次性道具的使用
    	*@返回：Buff 道具增加的buff，如果道具是使用skill，则返回null

 Create
	*@Create
     	*@设置该道具的一些相关属性
     	*@ID 该道具的ID

 Destroy
	*@Destroy
     	*@销毁该实例