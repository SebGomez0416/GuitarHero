using Unity.Mathematics;
using UnityEngine;

public class Track : MonoBehaviour
{
    public GameObject green;
    public GameObject red;
    public GameObject yellow;


    void Update()
    {
        if (Input.GetButtonDown("Green"))
        {
          Instantiate(green,Vector3.zero,quaternion.identity,this.transform);
          Time.timeScale = 0;
        }
        
        if (Input.GetButtonDown("Red"))
        {
            Instantiate(red,new Vector3(1,0,0),quaternion.identity,this.transform);
            Time.timeScale = 0;
        }
        
        if (Input.GetButtonDown("Yellow"))
        {
            Instantiate(yellow,new Vector3(2,0,0),quaternion.identity,this.transform);
            Time.timeScale = 0;
        }
    }
}
