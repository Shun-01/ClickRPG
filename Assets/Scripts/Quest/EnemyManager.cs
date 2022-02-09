using System;
using UnityEngine;
using DG.Tweening;

//�G���Ǘ�������́@�X�e�[�^�X�A�N���b�N���o�Ȃ�
public class EnemyManager : MonoBehaviour
{
    Action clickAction; //�N���b�N���ꂽ�Ƃ��Ɏ��s����֐��i�O������ݒ肷��j

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
    public void AddEventListenerOnClick(Action action) //clickAction�Ɋ֐���o�^����֐�
    {
        clickAction += action;
    }
    public void OnClick()
    {
        clickAction();
    }

}
