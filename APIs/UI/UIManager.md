 *UIManager
 *@Brief 负责管理游戏UI交互
 *@Author YYF
 *@Time 17.1.25
 *@API
 GetInstance
     *@Brief 获取一个UIManager实例 
     *@Return UIManager
	 
 OnDisplayPlayerAttributes
     *@Brief 显示玩家详细信息界面
	 
 OnNormalAttack
     *@Brief 触发普通攻击
 
 OnSpecialAttack
     *@Brief 触发特殊攻击
	 
 OnRaceSkill
     *@Brief 触发种族技能
	 
 OnInitiativeItem
     *@Brief 触发使用主动道具
	 
 OnDisposableItem
     *@Brief 触发使用一次性道具
	 
 DestroyDisposableItem
     *@Brief 销毁UI上的一次性道具
	 
 DestroyInitiativeItem
     *@Brief 销毁UI上的主动道具
	 
 AddInitiativeItem
     *@Brief 增加主动道具到UI
	 *@Param Sprite item 道具图片
	 
 AddDisposableItem
     *@Brief 增加一次性道具到UI
     *@Param Sprite item 道具图片
	 
 SetEsscences
     *@Brief 设置某种精华的数目
     *@Param1 int type  需要设置数目的精华的种类
     *@Param2 int value 需要设置的数目值
	 
 SetPhote
     *@Brief 设置头像类别
     *@Param int type 类别 0=地精 1=吸血鬼 2=狼人 3=矮人
	 
 SetTextTitleStyle
     *@Brief 将文本样式设置成标题样式
	 *@Remark 未实现