using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject SantaHat;
    public TMP_Text Score;
    public void setSanta(GameObject santa) {
        SantaHat = santa;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int points = SantaHat.GetComponent<TargetCollision>().getScore();
        Score.text = "Score: " + points;
    }
}
