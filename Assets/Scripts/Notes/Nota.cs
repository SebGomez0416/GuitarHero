
using System;
using UnityEngine;

public class Nota : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isActive = true;
    [SerializeField] private Tail tail;
    [SerializeField] private string ColorNote;
    
    public static event Action <bool> OnWrongNote;
    public static event Action <bool> OnCorrectNote;
    public static event Action <float>OnFire;
    public static event Action OnFail;
    


    private void Update()
    {
       Movement();
       CheckNote();
    }

    private void CheckNote()
    {
        if (Input.GetButtonDown(ColorNote) &&  Input.GetAxis("Vertical") == -0.1f || Input.GetAxis("Vertical") == 0.1f)
        {
            if ( transform.position.z <= 0.4f && transform.position.z >= -0.4f && isActive)
            {
                isActive = false;
                if(tail!= null)tail._Tail = true;
                OnCorrectNote?.Invoke(false);
                OnFire?.Invoke(transform.position.x);
                Destroy(gameObject);
            }
        }
        
        if (transform.position.z < -0.41f  && isActive)
        {
            OnWrongNote?.Invoke(true);
            OnFail?.Invoke();
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
