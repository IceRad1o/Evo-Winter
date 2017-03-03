using UnityEngine;
using System.Collections;

/*EffectManager
 *@Brief 负责生成特效
 *@Remark 当前仅存了3种特效,故ID仅能为0,1,2
 *@Author YYF
 *@Time 16.12.25
 */
public class EffectManager : UnitySingleton<EffectManager> {


    public  GameObject[] effects;   //特效prefabs




    /*InstantiateEffect
     *@Brief 生成一个对应ID的特效实例
     *@Param int effectID 特效ID号
     *@Return GameObject 特效实例对象 
     *@Remark 当前effectID仅支持0-2
     */
    public GameObject InstantiateEffect(int effectID)
    {
        GameObject effect = Instantiate(effects[effectID]);
        return effect;
    }





}
