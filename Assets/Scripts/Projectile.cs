using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    private void Update()
    {
        // Movimiento hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el proyectil colisiona con un zombie
        if (other.CompareTag("Zombie"))
        {
            other.GetComponent<Zombie>().TakeDamage(damage); // Llama a la función para tomar daño en el zombie
            Destroy(gameObject); // Destruye el proyectil
        }
    }
}
