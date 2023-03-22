using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float ChangeTime;
    public int RestoreTime;
    public float Delay;

    public GameObject hitParticle;
    public GameObject critParticle;

    public AttackTimer attackData;

    private void Start()
    {
        //attackData = GetComponentInParent<AttackTimer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (attackData.willCrit)
            {
                Cinemachine_Shake.Instance.ShakeCam(.8f, .3f);
                Time_Stop.Instance.StopTime(0.1f, 15, 0.1f);
                Instantiate(critParticle, other.transform.position, other.transform.rotation);
            }
            else
            {
                Cinemachine_Shake.Instance.ShakeCam(.3f, .3f);
                Time_Stop.Instance.StopTime(0.3f, 10, 0.1f);
                Instantiate(hitParticle, other.transform.position, other.transform.rotation);
            }
        }
    }
}
