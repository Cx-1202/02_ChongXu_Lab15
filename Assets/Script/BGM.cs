using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    int rand;

    public AudioSource BGM1;
    public AudioClip[] BGMArr;
    // Start is called before the first frame update
    void Start()
    {
        BGM1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rand = Random.Range(0, BGMArr.Length);

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            BGM1.Stop();
            BGM1.PlayOneShot(BGMArr[rand]);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            BGM1.GetComponent<AudioSource>().volume = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            BGM1.GetComponent<AudioSource>().volume = 0;
        }
    }
}
