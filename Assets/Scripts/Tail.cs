using System;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
   private float speed = 3;
   [SerializeField] private List<Material> materials;
   [SerializeField] private MeshRenderer meshRenderer;
   private bool _tail;
   private bool fire;
   public bool _Tail
   {
      set => _tail = value;
   }

   public static event Action <bool> OnFire;
   public static event Action <bool> OnWrongNote;

   private void Update()
   {
      Movement();

      if (Input.GetKey(KeyCode.Alpha1)&& _tail)
      {
         if (!fire)
         {
            meshRenderer.material = materials[0];
            meshRenderer.materials[1].color = materials[1].color;
            OnFire?.Invoke(true);
            fire = true;
         }
      }
      else
      {
         if (fire)
         {
            OnWrongNote?.Invoke(true);
            OnFire?.Invoke(false);
            meshRenderer.material = materials[2];
            meshRenderer.materials[1].color = materials[3].color;
           
            fire = false;
            _tail = false;
         }
      }

      if (transform.position.z < 0)
      {
         //OnWrongNote?.Invoke(true);
         OnFire?.Invoke(false);
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
