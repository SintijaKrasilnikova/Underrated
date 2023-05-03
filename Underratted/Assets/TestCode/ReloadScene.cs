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
        if (collision.CompareTag("Player"))
        {
            var healthComp = collision.GetComponent<PlayerHealth>();
            if (healthComp != null)
            {
                //Debug.Log("Health decreased");
                healthComp.TakeDamage(fallDamage);
                overSeer.CurrentHealth = healthComp.GetCurrentHealth();
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
