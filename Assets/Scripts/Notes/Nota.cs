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
    public static event Action OnUpdateScore;
    private bool easyMod;
    private bool init;

    private void Awake()
    { 
        Invoke("Init",3);
        speed =SceneManager.GetActiveScene().name == "Tiene Razon" ? 3.0f : 2.5f;
    }

    private void OnEnable()
    {
        Bridge.OnPlayNote += CheckNote;
    }

    private void OnDisable()
    {
        Bridge.OnPlayNote -= CheckNote;
    }

    private void Init()
    {
        init = true;
    }

    private void Update()
    {
       Movement();
       FailNote();
    }

    private void CheckNote(string color)
    {
        if (ColorNote != color) return;
        
        if( transform.position.z <= 0.4f && transform.position.z >= -0.3f && isActive)
        {
            isActive = false;
            if (tail != null)
            {
              tail._Tail = true;
              tail._ColorNotes = ColorNote;
            }
            OnCorrectNote?.Invoke(false);
            OnUpdateScore?.Invoke();
            OnFire?.Invoke(transform.position.x);
            Destroy(gameObject);
        }
    }

    private void FailNote()
    {
        if (transform.position.z < -0.31f  && isActive)
        {
            OnWrongNote?.Invoke(true);
            OnFail?.Invoke();
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
