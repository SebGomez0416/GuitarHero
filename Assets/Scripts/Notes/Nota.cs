
using System;
using UnityEngine;

public class Nota : MonoBehaviour
{
    [SerializeField] private float speed;
    public static event Action <bool> OnWrongNote;
    public static event Action <bool> OnCorrectNote;
    public static event Action OnFire;
    private bool isActive = true;
    [SerializeField] private Tail tail;

    private void Update()
    {
       Movement();
       CheckNote();
    }

    private void CheckNote()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if ( transform.position.z <= 0.24f && transform.position.z >= -0.24f && isActive)
            {
                isActive = false;
                if(tail!= null)tail._Tail = true;
                OnCorrectNote?.Invoke(false);
                OnFire?.Invoke();
            }
           // else // hacer ruido 
        }
        
        if (transform.position.z < -0.25f  && isActive)
        {
            OnWrongNote?.Invoke(true);
            //hacer ruido
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
