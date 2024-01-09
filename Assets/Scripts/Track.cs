using Unity.Mathematics;
using UnityEngine;

public class Track : MonoBehaviour
{
    public GameObject green;
    public GameObject red;
    public GameObject yellow;
    public GameObject blue;


    void Update()
    {
        if (Input.GetButtonDown("Green")|| Input.GetKeyDown(KeyCode.Alpha1))
        {
          Instantiate(green,Vector3.zero,quaternion.identity,this.transform);
          
        }
        
        if (Input.GetButtonDown("Red"))
        {
            Instantiate(red,new Vector3(1,0,0),quaternion.identity,this.transform);
            
        }
        
        if (Input.GetButtonDown("Yellow"))
        {
            Instantiate(yellow,new Vector3(2,0,0),quaternion.identity,this.transform);
            
        }
        
        if (Input.GetButtonDown("Blue"))
        {
            Instantiate(blue,new Vector3(3,0,0),quaternion.identity,this.transform);
            
        }
    }
}
