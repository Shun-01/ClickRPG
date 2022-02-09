using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//戦闘を管理
public class BattleManager : MonoBehaviour
{
    public bool canAttack;
    public Transform mainCamera;
    public QuestManager questManager;
    public StageUIManager stageUI;
    public PlayerManager player;
    public EnemyManager enemy;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
   
    //コルーチン
    //サンプル
    IEnumerator SampleCol(float x)
    {
        yield return new WaitForSeconds(x);;
    }
    private void Start()
    {
        playerUI.UpdateUI(player);
        canAttack = true;
    }

    public void BattleSetUp(EnemyManager enemy)
    {
        DialogTextManager.instance.SetScenarios(new string[] { enemy.name+"が現れた！" });
        this.enemy = enemy;
        playerUI.BattleUISetUp(player);
        enemyUI.BattleUISetUp(enemy);
        SoundManager.instance.PlayBGM("Battle");

        enemy.AddEventListenerOnClick(PlayerAttack);
    }
    void PlayerAttack()
    {
        if (canAttack == true)
        {
            StopAllCoroutines();
            player.Attack(enemy);
            SoundManager.instance.PlaySE(1);
            DialogTextManager.instance.SetScenarios(new string[] { "プレイヤーの攻撃！\n" + enemy.name + "に" + player.at + "ダメージを与えた！" });
            enemyUI.UpdateUI(enemy);
            canAttack = false;
            if (enemy.hp == 0)
            {
                StartCoroutine(EndBattle());
            }
            else
            {
                StartCoroutine(EnemyTurn());
            }
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(2f);
        SoundManager.instance.PlaySE(1);
        enemy.Attack(player);
        DialogTextManager.instance.SetScenarios(new string[] { enemy.name+"の攻撃！\nプレイヤーは" + enemy.at + "ダメージをくらった！" });
        mainCamera.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        playerUI.UpdateUI(player);
        canAttack = true;
        if (player.hp == 0)
        {
            canAttack = false;
            StartCoroutine(EndBattle());
        }
    }
    IEnumerator EndBattle()
    {
        if (player.hp == 0)
        {
            yield return new WaitForSeconds(2f);
            StartCoroutine(questManager.PlayerDead());
            
        }
        else if (enemy.hp == 0)
        {
            yield return new WaitForSeconds(2f);
            DialogTextManager.instance.SetScenarios(new string[] { enemy.name + "を倒した！" });
            stageUI.ShowButtons(true);
            Destroy(enemy.gameObject);
            enemyUI.ShowButtons(false);
            SoundManager.instance.PlayBGM("QuestScene");
            canAttack = true;
        }
    }
}
