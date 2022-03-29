using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AntEaterCollision : MonoBehaviour
{
    public AnteaterScript patrollerScript;
    public AudioSource audioSource;
   
   
    public AudioClip sfxHit;
    public AudioClip sfxEat;

    void Start()
    {
 
    }

    void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Car")
        {
            audioSource.PlayOneShot(sfxHit);
            Debug.Log("Anteater Hit Car");
            patrollerScript.speed = 0;
            loseLevel();
        }

        if (collisionInfo.gameObject.tag == "Anthill")
        {
            audioSource.PlayOneShot(sfxEat);
            Debug.Log("Anteater Hit Anthill");
            StartCoroutine(eatAnthill(collisionInfo));
            GetComponent<AudioSource>().Play();
        }


    }

    IEnumerator eatAnthill(UnityEngine.Collision collision)
    {
        float maxSpeed = patrollerScript.speed;
        patrollerScript.speed = 0;
        yield return new WaitForSeconds(0.5f);
        Destroy(collision.gameObject);

        do
        {
            patrollerScript.speed += 1;
            yield return new WaitForSeconds(1.0f);
        }
        while (maxSpeed != patrollerScript.speed);
        
    }

    void loseLevel()
    {
        SceneManager.LoadScene("LoseState"); //load win state 
    }
}
