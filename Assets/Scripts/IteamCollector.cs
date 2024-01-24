using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class IteamCollector : MonoBehaviour 
{
    private int Cherries = 0;
    [SerializeField] private Text cherriesText; 
    [SerializeField] private AudioSource CollectionSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cherry"))
        {
            CollectionSoundEffect.Play();
            Destroy(collision.gameObject);
            Cherries++;
            cherriesText.text = "Cherries:" + Cherries;
        }
    }
}
    