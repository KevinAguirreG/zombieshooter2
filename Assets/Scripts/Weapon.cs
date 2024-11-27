using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [Header("References")]
    public Transform weaponMuzzle;

    [Header("Sounds & Visuals")]
    public GameObject flashEffect;
    public AudioSource controlSound;
    public AudioClip shotSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Disparamos
        if (Input.GetButton("Fire1"))
        {
            Instantiate(flashEffect, weaponMuzzle.position, Quaternion.Euler(weaponMuzzle.forward), transform);
            if (!controlSound.isPlaying) // Asegúrate de que el sonido no esté ya sonando.
            {
                controlSound.PlayOneShot(shotSound); // Reproduce el sonido de caminar.
            }
        }
    }
}
