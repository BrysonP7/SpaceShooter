using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Inscribed")]
    public float speed = 10f;
    public float fireRate = 0.3f;
    public float health = 10;
    public int score = 100;

    private BoundsCheck bndCheck;
    
    public Vector3 pos{
        get{
            return this.transform.position;
        }
        set{
            this.transform.position = value;
        }
    }

    void Awake(){
        bndCheck = GetComponent<BoundsCheck>();
    }

    // Start is called before the first frame update
    void Update()
    {
        Move();

        // if(!bndCheck.isOnScreen){
        //     if(pos.y < bndCheck.camHeight - bndCheck.radius){
        //         Destroy(gameObject);
        //     }
        // }

        if(bndCheck.LocIs(BoundsCheck.eScreenLocs.offDown)){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    void OnCollisionEnter(Collision coll){
        GameObject otherGO = coll.gameObject;
        if(otherGO.GetComponent<ProjectileHero>() != null){
            Destroy(otherGO);
            Destroy(gameObject);
        }else{
            Debug.Log("Enemy hit by non-ProjectileHero " + otherGO.name);
        }
    }
}
