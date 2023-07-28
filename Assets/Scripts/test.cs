using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
   private AudioSource track;
   private bool pause;

   [SerializeField] private float delay;

   private void Awake()
   {
      track = GetComponent<AudioSource>();
      pause = false;
   }

   private void Start()
   {
      track.PlayDelayed(delay);
   }

   private void Update()
   {
      EditSong();
   }

   private void EditSong()
   {
      if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("GamePlay");

      if (Input.GetKeyDown(KeyCode.Space)) pause = !pause;

      if (pause)
      {
         Time.timeScale=0;
         track.Pause();
      }
      else
      {
         Time.timeScale = 1;
         track.UnPause();
      }

   }
}