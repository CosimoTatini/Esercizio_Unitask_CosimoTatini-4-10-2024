using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartAndUndoButton : MonoBehaviour
{


    [SerializeField] private Button _avviaButton;
    [SerializeField] private Button _fermaButton;
    [SerializeField] private TextMeshProUGUI _countdowntext;
    
    //[SerializeField] private GameObject[] _racers;
    //[SerializeField] private Transform _finishline;
    //[SerializeField] TextMeshProUGUI winnertext;

    private CancellationTokenSource cancellationTokenSource;
    private bool _isCountingDown = false;
   
  


    private void Start()
    {
        // Aggiungere i listener per i bottoni
        _avviaButton.onClick.AddListener(AvviaCountdown);
        //_fermaButton.onClick.AddListener(FermaCountdown);

        // Inizializzare il testo del countdown a 10
        _countdowntext.text = "10";

        //OnRaceEnd.AddListener((winner) =>
        //{
        //    StopAllRacers();
        //    winnertext.text = $" The winner is :{winner}";
        //});

    }

 

    public async void AvviaCountdown()
    {
        // Evita di avviare un altro countdown se uno è già in corso
        if (_isCountingDown)
            return;

        _isCountingDown = true;
        cancellationTokenSource = new CancellationTokenSource();

        int timeLeft = 10;

        try
        {
            while (timeLeft >= 0)
            {
                _countdowntext.text = timeLeft.ToString();
                await UniTask.Delay(1000, cancellationToken: cancellationTokenSource.Token);
                timeLeft--;
            }
            //OnRaceStart.Invoke();
            //StartRace();
        }
        catch (OperationCanceledException)
        {
            // Se il countdown viene annullato, resettiamo il testo
            _countdowntext.text = "10";
        }
        finally
        {
            _isCountingDown = false;
        }
    }

    //public void FermaCountdown()
    //{
    //    if (_isCountingDown && cancellationTokenSource != null)
    //    {
    //        cancellationTokenSource.Cancel();
    //        cancellationTokenSource.Dispose();
    //        _isCountingDown = false;
    //    }
    //}
    //public void StartRace()
    //{
    

    //    foreach(var racer in _racers)
    //    {
    //        float randomspeed = UnityEngine.Random.Range(2f,5f);
    //        Moveracer(racer, randomspeed).Forget();
    //    }
        


    //}

    //public async UniTaskVoid Moveracer(GameObject racer, float speed)
    //{
    //   while(racer.transform.position.x<=_finishline.position.x)
    //   {
    //        racer.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    //        await UniTask.Yield();
    //   }
    //    OnRaceEnd.Invoke(racer.name);
    //}
    //public void StopAllRacers()
    //{
    //    foreach (GameObject racer in _racers)
    //    {
    //        racer.GetComponent<Rigidbody>().velocity = Vector3.zero;
    //    }
    //}



}



