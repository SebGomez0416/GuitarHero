using UnityEngine;

public class Nota : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
       Movement();
    }
    
    private void Movement()
    {
        Vector3 movement;

        movement.x =0;
        movement.y =0;
        movement.z =-1 *speed* Time.fixedDeltaTime;
        
        rb.MovePosition(rb.position+movement);
    }
}
