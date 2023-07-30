using UnityEngine;

public class GreenNote : MonoBehaviour
{
    [SerializeField] private ParticleSystem fire;
    
    private void OnEnable()
    {
        Nota.OnFire += ActiveFire;
        Tail.OnFire += ActiveTailFire;
    }

    private void OnDisable()
    {
        Nota.OnFire -= ActiveFire;
        Tail.OnFire -= ActiveTailFire;
    }

    private void ActiveFire()
    {
        fire.Play();
    }

    private  void ActiveTailFire(bool active)
    {
        if (active)
        {
            var main = fire.main;
            main.loop = true;
            fire.Play();
        }
        else
        {
            var main = fire.main;
            main.loop = false;
            fire.Stop();
        }
    }
}


