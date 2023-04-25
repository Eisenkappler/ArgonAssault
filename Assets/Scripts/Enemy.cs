using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scoreincrease = 1;
    [SerializeField] int healthPoints = 3;

    ScoreBoard scoreBoard;
    Rigidbody rigidBody;

    private void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();   
        rigidBody  = gameObject.AddComponent<Rigidbody>();
        rigidBody.useGravity =false;
        rigidBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }
    
    private void OnParticleCollision(GameObject other) {
        ProcessHit();
       
    }


    private void ProcessHit()
    {
        healthPoints--;
        if (healthPoints < 0)
        {
            KillEnemy();
            return;
        }
        scoreBoard.IncreaseScore(scoreincrease);
    }

    private void KillEnemy()
    {
        
        GameObject vfx =  Instantiate(deathVFX,transform.position,Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }

}
