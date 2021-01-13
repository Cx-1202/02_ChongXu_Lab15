using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int spacecount = 0;
    int jumpcount =0;
    int jumpspeed = 10;
    int gravitymodlfier = 5;
    int rand;

    public Text JumpText;
    public AudioClip[] AudioClipArr;
    public AudioSource Jumpsound;
    public Rigidbody PlayerRB;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravitymodlfier;
        PlayerRB.GetComponent<Rigidbody>();

        Jumpsound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        jumping();

        JumpText.GetComponent<Text>().text = "Jump : " + spacecount;
        rand = Random.Range(0, AudioClipArr.Length);
    }

    private void jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpcount == 0)
        {
            // Jumpsound.Play();
            Jumpsound.PlayOneShot(AudioClipArr[rand]);
            PlayerRB.AddForce(Vector3.up * jumpspeed, ForceMode.Impulse);
            jumpcount++;
            spacecount++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpcount = 0;
        }
    }
}
