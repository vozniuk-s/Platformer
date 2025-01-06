using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int kiwiCounter = 0;
    [SerializeField] private Text text;
    [SerializeField] private AudioSource collectEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kiwi"))
        {
            collectEffect.Play();
            Destroy(collision.gameObject);
            ++kiwiCounter;
            text.text = "Kiwi collected: " + kiwiCounter;
        }
    }
}
