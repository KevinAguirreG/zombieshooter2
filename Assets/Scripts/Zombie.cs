using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    private int health = 3;

    [Header("Sounds")]
    public AudioSource controlSound;
    public AudioClip moanSound;


    public float minDelay = 1f; 
    public float maxDelay = 10f;
    private float nextPlayTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>().transform;
        ScheduleNextSound();
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
        if (!controlSound.isPlaying)
        {
            if (Time.time >= nextPlayTime)
            {
                controlSound.PlayOneShot(moanSound);
                ScheduleNextSound();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            player.GetComponent<Player>().IncrementScore();
            Destroy(gameObject);
        }
    }


    void ScheduleNextSound()
    {
        // Programar el tiempo para el próximo sonido aleatorio
        float delay = Random.Range(minDelay, maxDelay);
        nextPlayTime = Time.time + delay;
    }
}
