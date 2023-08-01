using System.Collections.Generic;
using UnityEngine;

public class FireNotes : MonoBehaviour
{
    [SerializeField] private List <ParticleSystem> fires;

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

    private void ActiveFire(float color)
    {
        fires[(int)color].Play();
    }
    private  void ActiveTailFire(bool active,float color)
    {
        if (active)
        {
            var main = fires[(int)color].main;
            main.loop = true;
            fires[(int)color].Play();
        }
        else
        {
            var main = fires[(int)color].main;
            main.loop = false;
            fires[(int)color].Stop();
        }
    }
}


