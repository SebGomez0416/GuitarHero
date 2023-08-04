using System;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
   private float speed = 2.5f;
   [SerializeField] private List<Material> materials;
   [SerializeField] private MeshRenderer meshRenderer;
   private bool _tail;
   private string _colorNotes;

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
   {;
      _colorNotes = "Green";
      
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
      Vector3 movement;

      movement.x =0;
      movement.y =0;
      movement.z = -1 * speed * Time.deltaTime;
      transform.position += movement;
   }
}
