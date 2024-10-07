using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Startbutton : MonoBehaviour
{
   [SerializeField] private Button _startcountdownbutton;
   [SerializeField] private TextMeshProUGUI _countdowntext;


    private void Awake()
    {
        if(_startcountdownbutton!=null)
        {
         _startcountdownbutton.onClick.AddListener(StartCountdown);
        }
      
    }

    public async void StartCountdown()
    {
        await CountDownAsync(10);
    }

    public async UniTask CountDownAsync(int v)
    {
        if(_startcountdownbutton!=null)
        {
            for (int i = v; i >= 0; i--)
            {
                _countdowntext.text = i.ToString();
                await UniTask.Delay(1000);
            }
        }
      
    }
}
