using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float verticalSpeed = 6.0f, horizontalSpeed = 10.0f;
    public string inputid;
    public AudioClip smash, jet, boost, ring;

    private Rigidbody rb;
    private Coroutine nitroCountdown;
    private Vector3 checkpointPos= Vector3.zero;
    GameManager gameManager;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager=FindObjectOfType<GameManager>();
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal" + inputid);
        float verticalInput = Input.GetAxis("Vertical" + inputid);
        
        rb.velocity = (transform.right * speed);
        //rb.AddForce(transform.up * verticalInput * verticalRotationSpeed);
        rb.AddForce(Vector3.right * horizontalInput * horizontalSpeed);

        transform.Rotate(Vector3.forward * -verticalInput * verticalSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * -horizontalInput * 15 * Time.deltaTime);

        transform.Rotate(Vector3.up * horizontalInput * horizontalSpeed * Time.deltaTime);

        audioSource.clip = jet;
        /*Debug.Log(transform.rotation.eulerAngles.z);

        if (transform.rotation.eulerAngles.z -360 < - clampValue)
            transform.rotation.SetEulerRotation(0, 0, 360 - clampValue + 5);
        else if (transform.rotation.eulerAngles.z > clampValue)
            transform.rotation.SetEulerRotation(0, 0, clampValue - 5);*/

    }


    void ResetPos()
    {
        transform.position = checkpointPos;
        transform.rotation= Quaternion.identity;
        Boost();
    }

    void Boost()
    {
        speed *= 3;
        horizontalSpeed *= 2;
        verticalSpeed *= 2;

        if (nitroCountdown != null)
            StopCoroutine(nitroCountdown);
        nitroCountdown = StartCoroutine(BoostTimer());
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(smash, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ring"))
        {
            audioSource.PlayOneShot(ring, 0.5f);
            checkpointPos = other.transform.position;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Booster"))
        {
            audioSource.PlayOneShot(boost, 0.5f);
            Destroy(other.gameObject);
            Boost();
        }

        if (other.gameObject.CompareTag("Start"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
            ResetPos();
    }

    IEnumerator BoostTimer()
    {
        yield return new WaitForSeconds(5.0f);
        speed /= 3;
        horizontalSpeed /= 2;
        verticalSpeed /= 2;
    }
}
