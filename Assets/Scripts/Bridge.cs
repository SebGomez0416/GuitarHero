using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Bridge : MonoBehaviour
{
    [SerializeField] private string ColorNote;
    [SerializeField] private Material playNote;

    private MeshRenderer mesh;
    private Material note;
    private Material _cord;
    private bool easyMod;
    public static event Action <string> OnPlayNote;
    public static event Action OnTail;
    private bool isActive;
    

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        note= mesh.material;
        easyMod = SceneManager.GetActiveScene().name == "Es el Amor" ? true : false;
    }

    public void Nota(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            if (!isActive)
            {
                OnPlayNote?.Invoke(ColorNote);
                isActive = true;
            }
            
            mesh.material = playNote;
            transform.position = new Vector3(transform.position.x, -0.45f, transform.position.z);
        }

        if (callbackContext.canceled)
        {   
            isActive = false;
            mesh.material = note;
            OnTail?.Invoke();
            transform.position = new Vector3(transform.position.x, -0.3f, transform.position.z);
        }
    }
}
