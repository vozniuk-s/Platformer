using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private AudioSource deathEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            deathEffect.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
