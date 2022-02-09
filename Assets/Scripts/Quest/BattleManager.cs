using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//�퓬���Ǘ�
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
   
    //�R���[�`��
    //�T���v��
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
        DialogTextManager.instance.SetScenarios(new string[] { enemy.name+"�����ꂽ�I" });
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
            DialogTextManager.instance.SetScenarios(new string[] { "�v���C���[�̍U���I\n" + enemy.name + "��" + player.at + "�_���[�W��^�����I" });
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
        DialogTextManager.instance.SetScenarios(new string[] { enemy.name+"�̍U���I\n�v���C���[��" + enemy.at + "�_���[�W����������I" });
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
            DialogTextManager.instance.SetScenarios(new string[] { enemy.name + "��|�����I" });
            stageUI.ShowButtons(true);
            Destroy(enemy.gameObject);
            enemyUI.ShowButtons(false);
            SoundManager.instance.PlayBGM("QuestScene");
            canAttack = true;
        }
    }
}
