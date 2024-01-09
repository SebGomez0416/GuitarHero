using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

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

   private void Update()
   {
      EditSong();
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

   private void Pause()
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

   private void EditSong()
   {
      if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Deus da Forca");

      if (Input.GetKeyDown(KeyCode.Space))
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
      }
   }
}