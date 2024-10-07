using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UndoButton : MonoBehaviour
{
    [SerializeField] private Button _undocountdownbutton;
    [SerializeField] private TextMeshProUGUI _originaltextbutton;

    CancellationTokenSource cancellationTokenSource;



    private void Awake()
    {
        if(_undocountdownbutton!=null)
        {
            _undocountdownbutton.onClick.AddListener(CancelCountDown);

        }
    }
       

 

    
    public void CancelCountDown()
    {
        if (cancellationTokenSource!=null && cancellationTokenSource.IsCancellationRequested)
        {
            cancellationTokenSource.Cancel();
            int countdownvalue = 10;
            _originaltextbutton.text= countdownvalue.ToString();
        }
    }
}
