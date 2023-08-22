using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndNote : MonoBehaviour
{
    
    private bool init;
    private float speed;
    
    public static event Action OnWin;
    public static event Action OnGameOver;

    private void Awake()
    {
        Invoke("Init",3);
        speed =SceneManager.GetActiveScene().name == "Tiene Razon" ? 3.0f : 2.5f;
    }
    private void Init()
    {
        init = true;
    }

    private void Update()
    {
        Movement();

        if (transform.position.z <= 0)
        {
            OnWin?.Invoke();
            OnGameOver?.Invoke();
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
