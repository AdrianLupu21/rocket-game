using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;

    [SerializeField]
    GameObject winnerMenuUI;

    [SerializeField]
    GameObject loserMenuUI;

    [SerializeField]
    float rthrust = 100f;

    [SerializeField]
    HealthBar healthBar;

    private int maxHealth = 100;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.setHealthBarUI(true);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Foe":
                print("taking damage");
                TakeDamage(10);
                break;
            case "Finish":
                print("race done");
                if (rigidBody.position.y > 0)
                {
                    PauseMenu.isPaused = true;
                    Time.timeScale = 0f;
                    winnerMenuUI.SetActive(true);
                }
                break;
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            PauseMenu.isPaused = true;
            loserMenuUI.SetActive(true);
        }
    }


    private void Rotate()
    {
        float rotationSpeed = rthrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.left * rotationSpeed);
        }
    }

    private void Thrust() {

        rigidBody.freezeRotation = true; // take manual control of rotation

        if (Input.GetKey(KeyCode.Space) && !PauseMenu.isPaused)
        {
            rigidBody.AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying)
            {
                print(audioSource.volume);
                audioSource.Play();
            }
        }
        else if(Input.GetKey(KeyCode.LeftShift))
        {
            rigidBody.AddRelativeForce(-Vector3.up);
            audioSource.Stop();
        }
        else
        {
            audioSource.Stop();
        }

        rigidBody.freezeRotation = false;
    }
}
