using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

//�Q�[���̐i�s���Ǘ�
public class QuestManager: MonoBehaviour
{
    public SceneLoadManager slManager;
    public GameObject zombiePrefab;
    public GameObject catPrefab;
    public GameObject gargoylePrefab;
    public StageUIManager stageUI;
    public BattleManager battleManager;
    public GameObject questImage;


    int currentStage = 1; //���݂̃X�e�[�W�i�s�x

    int stageLength = 10; //�X�e�[�W�̒���

    int[] encountTable = { 0, 0, 0, 1, 1, 1, 2, 2, 3, 3 }; //�G�ɑ�������e�[�u��

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
        DialogTextManager.instance.SetScenarios(new string[] { "�X�ɒ������B" });
    }
    IEnumerator Searching()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "�T�����c" });
        // �w�i��傫�����Ă���߂�
        questImage.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f)
            .OnComplete(() => questImage.transform.localScale = new Vector3(1.3f, 1, 1));
        // �t�F�[�h�A�E�g
        SpriteRenderer questImageSpriteRenderer = questImage.GetComponent<SpriteRenderer>();
        questImageSpriteRenderer.DOFade(0, 2f).OnComplete(() => questImageSpriteRenderer.DOFade(1, 0)); //2�b�����ď���
        //2�b�ԏ�����ҋ@������
        yield return new WaitForSeconds(2f);

        currentStage++;
        stageUI.UpdateUI(currentStage); //�i�s�x��UI�ɔ��f
        

        if (stageLength <= currentStage)
        {
            QuestClear();
        }
        else if (encountTable[Random.Range(0, 10)] == 1)
        {
            EncountEnemy(zombiePrefab);
        }
        else if (encountTable[Random.Range(0, 10)] == 2)
        {
            EncountEnemy(catPrefab);
        }
        else if (encountTable[Random.Range(0, 10)] == 3)
        {
            EncountEnemy(gargoylePrefab);
        }
        else
        {
            stageUI.ShowButtons(true);
        }
    }
    public void OnNextButton() //�i�ރ{�^�����������Ƃ��̊֐�
    {
        SoundManager.instance.PlaySE(0);
        stageUI.ShowButtons(false);
        StartCoroutine(Searching());
    }

    public void OnGoTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }

    void EncountEnemy(GameObject enemyPrefab)
    {
        stageUI.ShowButtons(false);
        GameObject enemyObj = Instantiate(enemyPrefab);

        SpriteRenderer enemySpriteRenderer = enemyObj.GetComponent<SpriteRenderer>();
        enemySpriteRenderer.DOFade(1, 1f);

        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.BattleSetUp(enemy);
        
    }
    public void EndBattle()
    {
        stageUI.ShowButtons(true);
    }
    void QuestClear()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "�󔠂��������I" });
        stageUI.ShowClearText();
        SoundManager.instance.PlaySE(2);
        SoundManager.instance.audioSourceBGM.Stop();
    }
    public IEnumerator PlayerDead()
    {
        SoundManager.instance.PlayBGM("Gameover");
        DialogTextManager.instance.SetScenarios(new string[] { "���Ȃ��͗͐s�����B" });
        yield return new WaitForSeconds(5f);
        slManager.LoadTo("TownScene");
    }
}
