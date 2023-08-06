using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nota : MonoBehaviour
{
    private float speed;
    private bool isActive = true;
    [SerializeField] private Tail tail;
    [SerializeField] private string ColorNote;
    
    public static event Action <bool> OnWrongNote;
    public static event Action <bool> OnCorrectNote;
    public static event Action <float>OnFire;
    public static event Action OnFail;

    private void Awake()
    {
        speed = SceneManager.GetActiveScene().name == "Tiene Razon" ? 3.0f : 2.5f;
    }

    private void Update()
    {
       Movement();
      // CheckNote();
    }

    private void CheckNote()
    {
        if (Input.GetAxis("Vertical")*Time.deltaTime != 0)
        {
            if (Input.GetButtonDown(ColorNote) )
            {
                if ( transform.position.z <= 0.45f && transform.position.z >= -0.3f && isActive)
                {
                    isActive = false;
                    if (tail != null)
                    {
                        tail._Tail = true;
                        tail._ColorNotes = ColorNote;
                    }
                    OnCorrectNote?.Invoke(false);
                    OnFire?.Invoke(transform.position.x);
                    Destroy(gameObject);
                }
            }
        }

        if (transform.position.z < -0.31f  && isActive)
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
