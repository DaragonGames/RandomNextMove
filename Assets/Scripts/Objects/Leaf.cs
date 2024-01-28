using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    public LeafPile pile;
    private float waitTime;
    private float speed;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        waitTime= Random.value;
        speed = 0.5f + Random.value;
        target = pile.transform.position + Vector3.up*1.5f - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pile.done) {return;}
        if (waitTime>0)
        {
            waitTime-=Time.deltaTime;
            return;
        }
        
        transform.position += target*speed*Time.deltaTime;
        if (transform.position.y >= pile.transform.position.y + 1.75f)
        {
            Destroy(gameObject);
        }
    }
}
