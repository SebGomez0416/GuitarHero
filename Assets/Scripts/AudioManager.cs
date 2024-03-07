using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;

public class AudioManager : MonoBehaviour
{
   [SerializeField]private List<AudioSource> tracks;
   [SerializeField] private AudioSource failNote;
   private bool pause;
   [SerializeField] private float delay;

   private void Awake()
   {
      Cursor.visible = false;
      Time.timeScale = 1;
      Invoke("Play",3); 
      Play();
   }

   private void OnEnable()
   {
      Nota.OnWrongNote += IsMute;
      Nota.OnCorrectNote += IsMute;
      Nota.OnFail += BadNote;
      Tail.OnWrongNote += IsMute;
      EndNote.OnGameOver += GameOver;
      HUD.OnGameOver += GameOver;
   }

   private void OnDisable()
   {
      Nota.OnWrongNote -= IsMute;
      Nota.OnCorrectNote -= IsMute;
      Nota.OnFail -= BadNote;
      Tail.OnWrongNote -= IsMute;
      EndNote.OnGameOver -= GameOver;
      HUD.OnGameOver -= GameOver;
   }

   private void IsMute(bool mute) 
   {
      tracks[0].mute = mute;
   }

   private void BadNote()
   {;
      int rand = Random.Range(0, 3);
      if (rand == 0)
      {
         failNote.Play();
      }
     
   }

   public void Pause()
   {
      foreach (var track in tracks)
         track.Pause();
   }
   
   private void UnPause()
   {
      foreach (var track in tracks)
         track.UnPause();
   }


   private void Play()
   {
      foreach (var track in tracks)
         track.PlayDelayed(delay);
   }

   private void GameOver()
   {
      pause = !pause;
      if (pause)
      {
         Time.timeScale=0;
         Pause();
      }
   }

   public void ShowMenu(InputAction.CallbackContext callbackContext)
   {
      SceneManager.LoadScene("Menu");
      /*if (callbackContext.performed)
      {
         pause = !pause;
         
         if (pause)
         {
            Time.timeScale=0;
            Pause();
         }
         else
         {
            Time.timeScale = 1;
            UnPause();
         }
      }*/
      
   }
   
   public void Reload(InputAction.CallbackContext callbackContext)
   {
      if (callbackContext.performed)
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }


}