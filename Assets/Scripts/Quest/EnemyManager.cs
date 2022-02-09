using System;
using UnityEngine;
using DG.Tweening;

//敵を管理するもの　ステータス、クリック検出など
public class EnemyManager : MonoBehaviour
{
    Action clickAction; //クリックされたときに実行する関数（外部から設定する）

    public new string name;
    public int hp;
    public int at;
    public GameObject hitEffect;
    public void Attack(PlayerManager player)
    {
        player.Damage(at);
    }
    public void Damage(int damage)
    {
        transform.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        Instantiate(hitEffect, this.transform, false);
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
    }
    public void AddEventListenerOnClick(Action action) //clickActionに関数を登録する関数
    {
        clickAction += action;
    }
    public void OnClick()
    {
        clickAction();
    }

}
