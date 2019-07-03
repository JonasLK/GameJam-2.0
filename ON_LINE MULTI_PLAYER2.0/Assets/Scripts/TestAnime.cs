using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnime : MonoBehaviour
{
    public Animator ani;
    public Movement player;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponentInChildren<Animator>();
        player = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.moving)
        {
            if(player.walking)
            {
                AnimationReset();
                ani.SetTrigger("Walk");
            }
            if (player.running)
            {
                AnimationReset();
                ani.SetTrigger("Run");
            }
        }
        else
        {
            AnimationReset();
            ani.SetTrigger("Idle");
        }
    }
    public void AnimationReset()
    {
        ani.ResetTrigger("Walk");
        ani.ResetTrigger("Run");
        ani.ResetTrigger("Idle");
    }
}
