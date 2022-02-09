using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyUIManager : MonoBehaviour
{
    public Text nameText;
    public GameObject nameTextPanel;
    public Text hpText;
    public GameObject hpTextPanel;


    public void BattleUISetUp(EnemyManager enemy)
    {
        hpText.text = string.Format("HPÅF{0}", enemy.hp);
        nameText.text = string.Format("{0}", enemy.name);
        ShowButtons(true);
    }
    public void UpdateUI(EnemyManager enemy)
    {
        hpText.text = string.Format("HPÅF{0}", enemy.hp);
    }

    public void ShowButtons(bool x)
    {
        nameText.gameObject.SetActive(x);
        hpText.gameObject.SetActive(x);
        nameTextPanel.SetActive(x);
        hpTextPanel.SetActive(x);
    }
}