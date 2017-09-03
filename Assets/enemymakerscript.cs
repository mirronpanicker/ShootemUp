using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymakerscript : MonoBehaviour
{

    public GameObject enemygo;
    public Sprite[] myimages;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating ("makeAnEnemyAction", 0, 3);
    }

    void makeAnEnemyAction()
    {
        GameObject newEnemyGO = (GameObject) Instantiate (enemygo) as GameObject;
        float x = Random.Range(-10.0f, 10.0f);
        float y = -5;
        float z = 0;

        newEnemyGO.transform.position = new Vector3(x, y, z);
        newEnemyGO.GetComponent<SpriteRenderer>().sprite = myimages[Random.Range(0,myimages.Length)];
        newEnemyGO.GetComponent<Rigidbody2D>().AddForce(Vector3.up*650);
    }
    // Update is called once per frame
}