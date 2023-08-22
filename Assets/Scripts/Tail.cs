using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tail : MonoBehaviour
{
   private float speed;
   [SerializeField] private List<Material> materials;
   [SerializeField] private MeshRenderer meshRenderer;
   private bool _tail;
   private string _colorNotes;
   private bool init;

   private bool fire;
   public bool _Tail
   {
      set => _tail = value;
   }
   
   public string _ColorNotes
   {
      get => _colorNotes;
      set => _colorNotes = value;
   }

   public static event Action <bool,float> OnFire;
   public static event Action <bool> OnWrongNote;

   private void Awake()
   {
      Invoke("Init",3);
      speed = SceneManager.GetActiveScene().name == "Tiene Razon" ? 3.0f : 2.5f;
      _colorNotes = "Green";
   }
   
   private void Init()
   {
      init = true;
   }

   private void Update()
   {
      Movement();
      if (Input.GetButton(_colorNotes)&& _tail)
      {
        if(!fire)
        {
            meshRenderer.material = materials[0];
            meshRenderer.materials[1].color = materials[1].color;
            OnFire?.Invoke(true,transform.position.x);
            fire = true;
        }
      }
      else
      {
         if (fire)
         {
            OnWrongNote?.Invoke(true);
            OnFire?.Invoke(false,transform.position.x);
            meshRenderer.material = materials[2];
            meshRenderer.materials[1].color = materials[3].color;
           
            fire = false;
            _tail = false;
         }
      }

      if (transform.position.z < 0)
      {
         OnFire?.Invoke(false,transform.position.x);
         Destroy(gameObject);
      }
   }
   
   private void Movement()
   {
      if (!init) return;
      Vector3 movement;

      movement.x =0;
      movement.y =0;
      movement.z = -1 * speed * Time.deltaTime;
      transform.position += movement;
   }
}
