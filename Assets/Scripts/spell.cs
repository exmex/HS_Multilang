using UnityEngine;
using System.Collections;

public class spell : MonoBehaviour
{
    //通用
    public void OnPlay() { }
    //专有
    public void OnAttack(GameObject target) { }
    public void OnUnderAttack(int demage, GameObject attacker) { }
    public void OnTurnBegin() { }
    public void OnTurnEnd() { }
    public void OnDeath() { }
	/*
    void darw(int count = 1) { }
    void addCost(int count = 1) { }
    void addCostMax(int count = 1) { }
    */
    /// <summary>
    /// 冲锋-此单位免疫召唤疲劳，被召唤出的回合即可攻击
    /// </summary>
    void charge() { }
    /// <summary>
    /// 嘲讽-当场上有拥有嘲讽技能的卡牌时，对方无法攻击本方英雄，必须优先攻击此卡牌
    /// </summary>
    void taunt() { }
}
/*
*通用技能 
 * 嘲讽-当场上有拥有嘲讽技能的卡牌时，对方无法攻击本方英雄，必须优先攻击此卡牌
 * 冲锋-此单位免疫召唤疲劳，被召唤出的回合即可攻击
 * 战场咆哮：x-此单位上场时，造成X效果
 * 死亡呓语:X-此单位死亡时，造成X效果
 * 沉默–移除目标角色所有效果
 * 激怒：X-收到伤害时，造成X效果
 * 圣盾–免疫此单位下次所受攻击 
 * 连击:X->如果你在使用连击的之前使用了另一张卡牌，则造成X效果
 * 风怒-每回合可攻击两次
 * 过载x-预支下回合可用魔力水晶X
 * 冻结–被冻结目标无法攻击
 * 选择-X：YX与Y选择一项法术能量+X-增加法术的伤害X 
 * 潜行-此单位攻击前无法被攻击或者成为法术的目标
    */
