using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorManager : MonoBehaviour
{
    public static ColorManager instance;

    public TMP_Text NumUI;
    public int ColorNum = 0;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        NumUI.text = ColorNum.ToString();
    }
}
