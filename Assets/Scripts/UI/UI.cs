using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject play;
    [SerializeField] private GameObject credits;
    
    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        /*if (!Input.GetKeyDown(KeyCode.Escape)) return;
        play.SetActive(false);
        credits.SetActive(false);
        menu.SetActive(true);*/
    }

    public void Play()
    {
        menu.SetActive(false);
        play.SetActive(true);
    }

    public void Credits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    
}
