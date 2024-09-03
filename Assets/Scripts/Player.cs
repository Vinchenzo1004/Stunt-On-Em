using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public float moveSpeed = 15.0f;

    public float rotationSpeed = 360f;
    public bool isRotating = false;

    public Rigidbody2D player;

    public AudioClip hitSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    public void MovePlayer()
    {
        player.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
    }

    public void RotatePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
        {
            StartCoroutine(RotateOverTime(1f, 360f)); // 1 second for a full 360-degree rotation
        }

        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            StartCoroutine(RotateOverTime(1f, -360f)); // 1 second for a full -360-degree rotation
        }
    }

    private IEnumerator RotateOverTime(float duration, float angle)
    {
        isRotating = true;
        float startRotation = transform.eulerAngles.z;
        float endRotation = startRotation + angle;
        float t = 0.0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float zRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);
            yield return null;
        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, endRotation % 360.0f);
        isRotating = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy Projectile")
        {
            if (isRotating == true)
            {
                ScoreDisplay.instance.SpinAddPoint();
                Object.Destroy(collision.gameObject);
            }
            else
            {
                LivesManager lm = FindObjectOfType<LivesManager>();
                Object.Destroy(collision.gameObject);
                if (lm != null)
                {
                    lm.LoseLife();

                    if (hitSound != null)
                    {
                        audioSource.PlayOneShot(hitSound);
                    }
                }
            }
        }
    }
}