using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scoreincrease = 1;

    ScoreBoard scoreBoard;

    private void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();   
    }
    
    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        KillEnemy();
       
    }


    private void ProcessHit()
    {
        scoreBoard.IncreaseScore(scoreincrease);
    }

    private void KillEnemy()
    {
        
        GameObject vfx =  Instantiate(deathVFX,transform.position,Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }

}
