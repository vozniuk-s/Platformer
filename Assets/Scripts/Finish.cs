using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool levelCompleted = false;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            _audioSource.Play();
            Invoke("CompleteLevel", 2f);
            levelCompleted = true;
        }
    }
     
    private void CompleteLevel()
    {
        int level = SceneManager.GetActiveScene().buildIndex;

        if (level == 2)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
