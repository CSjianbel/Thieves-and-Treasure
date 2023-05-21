using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    SquareScript [] squares;
    // Start is called before the first frame update
    void Start()
    {
        squares = GetComponentsInChildren<SquareScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
