using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGenerator : MonoBehaviour
{
    [SerializeField] private GameObject otherSpawner;
    [SerializeField] private GameObject Projectiles;
    [SerializeField] private GameObject SnowFlake;
    [SerializeField] private GameObject SnowBall;
    [SerializeField] private GameObject BouncyBall;

    [SerializeField] private Transform positionleft;
    [SerializeField] private Transform positionright;

    [SerializeField] private GameObject UISpawner;

    private Transform CurrentPosition;
    private float coolDown;
    bool right;
    // Start is called before the first frame update
    void Start()
    {
        coolDown = 0;
        CurrentPosition = positionright;
        right = true;
    }

    public void setUISpawner(GameObject UISpaw) {
        this.UISpawner = UISpaw;
    }
    public void changeHands() {
        if (otherSpawner != null) otherSpawner.GetComponent<ProjectileGenerator>().switchPosition();
        this.switchPosition();
        UISpawner.GetComponent<UISpawn>().switchPosition();
    }

    public void setOtherSpawner(GameObject OthSpaw) {
        this.otherSpawner = OthSpaw;
    }

    public void switchPosition() {
        if (right) {
            right = false;
            CurrentPosition = positionleft;
        }

        else {
            right = true;
            CurrentPosition = positionright;
            
        }
    }

    public void setProjectiles(GameObject proj) {
        this.Projectiles = proj;
    }

    public void createSnowBall() {
        if (coolDown <= 0) {
            GameObject sb = Instantiate(SnowBall);
            sb.transform.position = CurrentPosition.position;
            sb.transform.SetParent(Projectiles.transform, true);
            coolDown = 1.5f;
        
        }
            
    }

    public void createSnowFlake() {
        if (coolDown <= 0) {
            GameObject sf = Instantiate(SnowFlake);
            sf.transform.position = CurrentPosition.position;
            sf.transform.SetParent(Projectiles.transform, true);
            coolDown = 1.5f;        
        }
            
    }

    public void destroyProjectiles() {
        foreach(Transform child in Projectiles.gameObject.transform) {
            Destroy(child.gameObject);
        }
    }
    public void createBouncyBall() {
        if (coolDown <= 0) {
            GameObject bb = Instantiate(BouncyBall);
            bb.transform.position = CurrentPosition.position;  
            bb.transform.SetParent(Projectiles.transform, true);
            coolDown = 1.5f;    
        }
       
       // 
        
    }
    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        if (coolDown <= 0) coolDown = 0;
    }
}
