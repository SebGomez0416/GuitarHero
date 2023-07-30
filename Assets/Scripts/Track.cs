using UnityEngine;

public class Track : MonoBehaviour
{
    public GameObject nota;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
          /*Instantiate(nota,Vector3.zero,quaternion.identity,this.transform);
          Time.timeScale = 0;*/
        }
    }
}
