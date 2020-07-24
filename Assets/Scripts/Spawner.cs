using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject gOInstantiate;
    public bool instantiateBalls = true;
    public Vector2 vectorSpawner;
    float timeTemp;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstantiateBalls());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator InstantiateBalls()
    {
        while(instantiateBalls == true)
        {
            float xPosTemp = Random.Range(-10f,10f);
            vectorSpawner = new Vector2(xPosTemp,transform.position.y);
            Instantiate(gOInstantiate,vectorSpawner, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
