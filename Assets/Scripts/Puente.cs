using UnityEngine;

public class Puente : MonoBehaviour
{
    private bool note;
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (note)
            {
                Debug.Log("bien..........");
            }else  Debug.Log("mal..........");
        }

    }

    private void OnTriggerEnter(Collider c)
    {
        note = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        note = false;
        
    }
}


