using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public static float speed = 8f;
    private float prev_speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < 1.5f && Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right * 0.5f;

        }
        if (transform.position.x > -1.5f && Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left * 0.5f;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<Transform>().tag == "Obstacle")
        {
            Destroy(other.gameObject);

            if(GetComponent<Renderer>().material.color != other.GetComponent<Renderer>().material.color)
            {
                if (speed > 8)
                {
                    speed /= 1.5f;
                }
                prev_speed = speed;
                StartCoroutine(gameEnd());
            }
        }
    }
    IEnumerator gameEnd()
    {
        speed = 0;
        yield return new WaitForSeconds(3);
        speed = prev_speed;
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("SampleScene");
    }

}
