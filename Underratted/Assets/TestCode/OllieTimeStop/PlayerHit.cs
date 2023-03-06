using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float ChangeTime;
    public int RestoreTime;
    public float Delay;

    public GameObject hitParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Time_Stop.Instance.StopTime(0.05f, 10, 0.1f);
            Instantiate(hitParticle, other.transform.position, other.transform.rotation);
        }
    }
}
