using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  
    [SerializeField] ParticleSystem crashVFX;
    
     private void OnCollisionEnter(Collision other) {
        
        Debug.Log(this.gameObject.name + "collided with " + other.gameObject.name);

    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(this.gameObject.name + "triggered " + other.gameObject.name);
        
       StartCrashSequence();

    }
    private void StartCrashSequence()
    {
        crashVFX.Play();
        GetComponent<PlayerControls>().enabled = false;
        foreach (Transform child in transform)
        {
         MeshRenderer renderer = child.GetComponent<MeshRenderer>();

         if (renderer != null)
         {
            renderer.enabled = false;
        }
        }
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel",1f);
    }

        void ReloadLevel()
    {
       
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Debug.Log("RELOAD");
    }

    
}
