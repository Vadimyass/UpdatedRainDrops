using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raindrops : MonoBehaviour
{ 
    [SerializeField]private GameObject ParticleSystem = null;
    [SerializeField]private GameObject PopSound = null;


    private GameObject particles;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent<Engine>(out Engine GeneralRaindrop))
        {
            Engine.ScoreText.AddScore();
            PlayExplosion();
            PopSoundFunc();
            Destroy(gameObject);

        }
        else if (collision.TryGetComponent<BordersScript>(out BordersScript Border))
        {
            PlayExplosion();
            Destroy(gameObject);
        }
        else
            PlayExplosion();
            Destroy(gameObject);
    }

    public void PlayExplosion()
    {
        particles = Instantiate(ParticleSystem);
        particles.transform.position = transform.position;
        Destroy(particles,2f);
    }
    private void PopSoundFunc()
    {
        GameObject popsound = Instantiate(PopSound);
        Destroy(popsound,2f);
    }
    IEnumerator DelayForDestroyParticleSystem()
    {
        yield return new WaitForSeconds(2f);
    }
    IEnumerator DelayForDestroySound()
    {
        Destroy(this.PopSound);
        yield return new WaitForSeconds(2f);
    }
}
