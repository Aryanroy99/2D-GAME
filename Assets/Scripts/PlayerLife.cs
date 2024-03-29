using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator  ani;

    [SerializeField] private AudioSource DieSoundEffect;
    
    private void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
       ani = GetComponent<Animator>(); 
    }
       private void OnCollisionEnter2D(Collision2D collision)
       {

         if (collision.gameObject.CompareTag("Trap"))
         {
            Die();
         }

       }

       private void Die()
       {
            DieSoundEffect.Play();
            rb.bodyType = RigidbodyType2D.Static;
            ani.SetTrigger("death"); 
       }
       private void RestartLevel()
       {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }

}
