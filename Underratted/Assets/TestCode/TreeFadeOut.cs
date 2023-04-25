using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeFadeOut : MonoBehaviour
{

    public GameObject cameraRef = default;
    public GameObject playerRef = default;
    public SpriteRenderer render = default;
    [SerializeField] private float treeToCameraDist = 15f;

    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        cameraRef = GameObject.FindGameObjectWithTag("Camera");
        playerRef = GameObject.FindGameObjectWithTag("Player");
        render = this.gameObject.GetComponent<SpriteRenderer>();

        originalColor = render.color;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.Distance(transform.position, cameraRef.transform.position);

        //float dist = Vector3.Distance(transform.position, cameraRef.transform.position);
        //float dist = Vector3.Distance(cameraRef.transform.position, transform.position);
        //float dist = Mathf.Abs(cameraRef.transform.position.z - transform.position.z);
        float dist = Mathf.Abs(transform.position.z - cameraRef.transform.position.z);

        if (dist < treeToCameraDist)
        {
            //float zDist = Mathf.Abs(cameraRef.transform.position.z - transform.position.z);

            float zDist = Mathf.Abs(treeToCameraDist - dist);

            //Debug.Log(dist);

            //Color newColor = new Color(0,0,0,zDist);
            render.color = Color.clear;
            //render.color = newColor;
        }
        else
        {
            render.color = originalColor;
        }

        Debug.Log(dist);
        //Debug.Log(Vector3.Distance(transform.position, cameraRef.transform.position));
    }
}
