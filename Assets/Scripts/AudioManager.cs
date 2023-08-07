using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
   [SerializeField]private List<AudioSource> tracks;
   [SerializeField] private AudioSource failNote;
   private bool pause;
   [SerializeField] private float delay;

   private void Start()
   {
     Play();
   }

   private void OnEnable()
   {
      Nota.OnWrongNote += IsMute;
      Nota.OnCorrectNote += IsMute;
      Nota.OnFail += BadNote;
      Tail.OnWrongNote += IsMute;
   }

   private void OnDisable()
   {
      Nota.OnWrongNote -= IsMute;
      Nota.OnCorrectNote -= IsMute;
      Nota.OnFail -= BadNote;
      Tail.OnWrongNote -= IsMute;
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

   private void EditSong()
   {
      if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);

      if (Input.GetKeyDown(KeyCode.Space)) pause = !pause;

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

      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
         if (SceneManager.GetActiveScene().name == "Tiene Razon")
         {
            SceneManager.LoadScene("Sobre la Mesa");
         }
         else SceneManager.LoadScene("Tiene Razon");
      }

      if (Input.GetKeyDown(KeyCode.Alpha2))
      {
         SceneManager.LoadScene("Es el Amor");
      }
      
      if (Input.GetKeyDown(KeyCode.Alpha4))
      {
         Application.Quit();
      }
      

   }
}