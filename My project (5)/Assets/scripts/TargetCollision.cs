using System.Collections;
using System.Collections.Generic;
using Meta.WitAi;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TargetCollision : MonoBehaviour
{
    private int score;
    public AudioSource scoreSound;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if (other.tag == "projectile") {
            score +=1;
            Destroy(other.transform.parent.gameObject);
            scoreSound.Play(0);
        }
    }

    public int getScore() {
        return score;
    }
}
