using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bridge : MonoBehaviour
{
    [SerializeField] private string ColorNote;
    [SerializeField] private Material playNote;
    private MeshRenderer mesh;
    private Material note;
    private bool easyMod;
    public static event Action <string> OnPlayNote;
    private bool isActive;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        note= mesh.material;
        easyMod = SceneManager.GetActiveScene().name == "Es el Amor" ? true : false;
    }
    
    private void Update()
    {
        if (Input.GetButton(ColorNote) && Input.GetAxis("Vertical") * Time.deltaTime != 0 )
        {
            if (!isActive)
            {
                OnPlayNote?.Invoke(ColorNote);
                isActive = true;
            }
            
            mesh.material = playNote;
           transform.position = new Vector3(transform.position.x, -0.45f, transform.position.z);
            
           
        }
        else
        {
            isActive = false;
            mesh.material = note;
            transform.position = new Vector3(transform.position.x, -0.3f, transform.position.z);
        }
    }
}
