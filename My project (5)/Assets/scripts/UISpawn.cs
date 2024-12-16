using System.Collections;
using System.Collections.Generic;
using Oculus.Platform;
using UnityEngine;

public class UISpawn : MonoBehaviour
{
    [SerializeField] GameObject projectiles;
    [SerializeField] Transform positionright;
    [SerializeField] GameObject UI;
    [SerializeField] Transform positionleft;

    [SerializeField] GameObject otherSpawner;

    [SerializeField] Transform centerEye;
    bool right;
    private Transform CurrentPosition;
    private GameObject UIObject;

    [SerializeField] GameObject SantaHat;
    // Start is called before the first frame update
    public void createUI() {
        if (UIObject != null) Destroy(UIObject); 
        UIObject = Instantiate(UI);
        UIObject.transform.position = CurrentPosition.position;
        UIObject.transform.rotation = centerEye.rotation;
        UIObject.GetComponent<ProjectileGenerator>().setProjectiles(projectiles);
        UIObject.GetComponent<ProjectileGenerator>().setOtherSpawner(otherSpawner);
        UIObject.GetComponent<ProjectileGenerator>().setUISpawner(this.gameObject);
        UIObject.GetComponent<Counter>().setSanta(SantaHat);
    }

    public void switchPosition() {
        if (right) {
            right = false;
            CurrentPosition = positionleft;
            destroyUI();
            createUI();
        }

        else {
            right = true;
            CurrentPosition = positionright;
            destroyUI();
            createUI();
            
        }
    }

    public void destroyUI() {
        Destroy(UIObject);
    }    
    void Start()
    {
        right = false;
        CurrentPosition = positionleft;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
