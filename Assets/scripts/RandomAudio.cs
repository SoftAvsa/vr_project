using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class RandomAudio : MonoBehaviour
{
    public float min_wait;
    public float max_wait;
    private float timer;
    private float randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        randomNumber = Random.Range(min_wait, max_wait);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= randomNumber)
        {
            timer = 0;
            // Play audio clip
            this.GetComponent<AudioSource>().Play();
            // Get new random interval
            randomNumber = Random.Range(min_wait, max_wait);
        }
    }
}
