using UnityEngine;

public class BlueNote : MonoBehaviour
{
    [SerializeField] private ParticleSystem fire;
    private bool note;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && note)
        {
            fire.Play();
            note = false;
        }
           

    }

    private void OnTriggerEnter(Collider other)
    {
        note = true;
    }

    private void OnTriggerExit(Collider other)
    {
        note = false;
    }
}


