using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    private void Start()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "�X�ɒ������B" });

    }
    public void ClickToQuestButton()
    {
        SoundManager.instance.PlaySE(0);
    }
}
