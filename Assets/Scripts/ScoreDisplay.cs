using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public static ScoreDisplay instance;
    
    public Text scoreText;
    int score = 0;

    public AudioClip hitSound;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scoreText.text = "Score: " + score.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        goal();
    }

    public void AddPoint()
    {
        if (hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        score += 10;
        scoreText.text = "Score: " + score.ToString();
    }

    public void SpinAddPoint()
    {
        if (hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        score += 50;
        scoreText.text = "Score: " + score.ToString();
    }

    public void goal()
    {
        if(score >= 1000)
        {
            StartCoroutine(ExecuteAfterTime(0.5f));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Win Screen");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
