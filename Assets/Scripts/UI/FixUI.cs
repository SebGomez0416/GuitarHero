using UnityEngine;
using UnityEngine.InputSystem;

public class FixUI : MonoBehaviour
{
   public void Fix(InputAction.CallbackContext callbackContext)
   {
      // esta funcion es creada para correjir un erro interno
      // de unity con la funcion on scrren button.
      Debug.Log("entrada");
   }
}
