using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    
    private void OnParticleCollision(GameObject other) {
        Debug.Log($"I'm hit by {other.gameObject.name }");
        GameObject vfx =  Instantiate(deathVFX,transform.position,Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }

}
