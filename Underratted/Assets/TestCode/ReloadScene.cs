using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public int fallDamage = 1;
    public CardOverseer overSeer;


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Fell in void");
        if (collision.CompareTag("Player"))
        {
            var healthComp = collision.GetComponent<PlayerHealth>();
            if (healthComp != null && healthComp.IsLuluDead() ==false)
            {
                //Debug.Log("Health decreased");
                if (healthComp.GetCurrentHealth() > 1)
                {
                    healthComp.TakeDamage(fallDamage);
                    overSeer.CurrentHealth = healthComp.GetCurrentHealth();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                else
                {
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    healthComp.TakeDamage(fallDamage);
                }
            }
        }
    }
}
