using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public void ClickStartButton()
    {
        SoundManager.instance.PlaySE(0);
    }
}
