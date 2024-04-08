using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesPlayer : MonoBehaviour
{
    [SerializeField] ParticleSystem _ps;

    public void Play()
    {
        _ps.Play();
    }
}
