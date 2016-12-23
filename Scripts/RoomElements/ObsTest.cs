/*
using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{

    public int health = 3;

    //NEED public AudioClip sound1;
    //NEED public AudioClip sound2;

    private int time = 0;
    private Animator animator;
    private bool isTrigger = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Test());
    }


    void Update()
    {

    }

    IEnumerator Test()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Debug.Log("TEST");
            if ((int)Input.GetAxisRaw("Fire1") > 0)
            {
                Debug.Log("Fire1");
                ChangeHealth(-1);
            }
        }


    }

    public void ChangeHealth(int damage)
    {
        //NEED SoundManager.instance.RandomizeSfx(sound1, sound2);
        if (time == 0)
        {
            animator.SetTrigger("Obstacle1");
            Debug.Log("Obstacle1");
        }

        else if (time == 1)
            animator.SetTrigger("Obstacle2");
        else
            animator.SetTrigger("Obstacle3");


        health += damage;
        time++;

        if (health <= 0)
            gameObject.SetActive(false);
    }
}
 */
