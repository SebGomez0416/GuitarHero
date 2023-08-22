using UnityEngine;
using UnityEngine.SceneManagement;

public class Traste : MonoBehaviour
{
    private float speed;
    private bool init;
    
    private void Awake()
    {
        speed = SceneManager.GetActiveScene().name == "Tiene Razon" ? 3.0f : 2.5f;
    }

    private void Start()
    {
        Invoke("Init",3);
    }
    
    private void Init()
    {
        init = true;
    }

    private void Update()
    {
        if (!init) return;
        Vector3 movement= Vector3.zero;
        movement.z = -1;
        transform.position += movement * (speed * Time.deltaTime);
        
        Spawn();
    }

    private void Spawn()
    {
        if (transform.position.z <= -3)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, 14.5f);
            transform.position = newPos;
        }
    }
}
