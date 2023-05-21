using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int square;

    // Start is called before the first frame update
    void Start()
    {
        square = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void move(int newSquare, Vector3 newPos) {
        setSquare(newSquare);
        setPosition(newPos);
    }
    public void setSquare(int pos) {
        square = pos;
    }

    public int getSquare() {
        return square;
    }

    public Vector3 getPosition() {
        return transform.position;
    }

    public void setPosition(Vector3 pos) {
        // Debug.Log(transform.position);
        transform.position = pos;
        // Debug.Log(pos);
    }
}
