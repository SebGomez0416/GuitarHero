using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private TextMeshProUGUI Notas;
    [SerializeField] private TextMeshProUGUI count;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private int gameOverNotes;
    private int score;
    private int notas;
    private int failNotes;
    private int _count;
    
    public static event Action OnGameOver;

    private void Awake()
    {
        _count = 3;
    }

    private void Start()
    {
        InvokeRepeating("Count",0,1);
    }

    private void OnEnable()
    {
        Nota.OnUpdateScore += UpdateScore;
        Nota.OnFail += BadNote;
        EndNote.OnWin += IsWin;
    }

    private void OnDisable()
    {
        Nota.OnUpdateScore -= UpdateScore;
        Nota.OnFail -= BadNote;
        EndNote.OnWin -= IsWin;
    }

    private void Update()
    {
        UpdateNotas();
    }

    private void IsWin()
    {
        Time.timeScale=0;
        win.SetActive(true);
    }

    private void UpdateNotas()
    {
        switch (notas)
        {
            case 300:
                Notas.text = "x" + notas;
                failNotes = 0;
                Invoke("CleanNotes", 2);
                break;
            case 275:
                Notas.text = "x" + notas;
                failNotes = 0;
                Invoke("CleanNotes", 2);
                break;
            case 250:
                Notas.text = "x" + notas;
                failNotes = 0;
                Invoke("CleanNotes", 2);
                break;
            case 225:
                Notas.text = "x" + notas;
                failNotes = 0;
                Invoke("CleanNotes", 2);
                break;
            case 200:
                Notas.text = "x" + notas;
                failNotes = 0;
                Invoke("CleanNotes", 2);
                break;
            case 175:
                Notas.text = "x" + notas;
                failNotes = 0;
                Invoke("CleanNotes", 2);
                break;
            case 150:
                Notas.text = "x" + notas;
                failNotes = 0;
                Invoke("CleanNotes", 2);
                break;
            case 125:
                Notas.text = "x" + notas;
                failNotes = 0;
                Invoke("CleanNotes", 2);
                break;
            case 100:
                Notas.text = "x" + notas;
                failNotes = 0;
                Invoke("CleanNotes", 2);
                break;
            case 75:
                Notas.text = "x" + notas;
                failNotes = 0;
                Invoke("CleanNotes", 2);
                break;
            case 50:
                Notas.text = "x" + notas;
                failNotes = 0;
                Invoke("CleanNotes", 2);
                break;
            case 25:
                Notas.text = "x" + notas;
                failNotes = 0;
                Invoke("CleanNotes", 2);
                break;
        }

        if (failNotes >= gameOverNotes)
        {
            gameOver.SetActive(true);
            OnGameOver?.Invoke();
        }
    }

    private void CleanNotes()
    {
        Notas.text = "";
    }

    private void Count()
    {
       switch (_count)
        {
            case 3:
                count.text = "" + 3;
                break;
            case 2:
                count.text = "" + 2;
                break;
            case 1:
                count.text = "" + 1;
                break;
            case 0:
                CancelInvoke();
                count.enabled = false;
                break;
        }
       _count--;
    }

    private void UpdateScore()
    {
        notas++;
        failNotes--;
        if (failNotes < 0) failNotes = 0;
        score += 100;
        Score.text=""+score;
    }

    private void BadNote()
    {
        notas = 0;
        failNotes++;
        Notas.text = "";
    }

}
