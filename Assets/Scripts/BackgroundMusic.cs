using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip[] sceneMusic; // Array to hold different music for each scene
    private AudioSource audioSource;

    void Awake()
    {
        // Make sure there's only one instance of this object (singleton pattern)
        if (FindObjectsOfType<BackgroundMusic>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the current scene has a corresponding music track
        if (scene.buildIndex < sceneMusic.Length && sceneMusic[scene.buildIndex] != null)
        {
            audioSource.clip = sceneMusic[scene.buildIndex];
            audioSource.Play();
        }
    }
}