using UnityEngine;

public class Traste : MonoBehaviour
{
    private float speed = 3.0f;

    private void Update()
    {
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
