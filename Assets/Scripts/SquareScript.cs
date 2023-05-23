using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareScript : MonoBehaviour
{
    bool hasTanod;
    bool hasDog;
    bool hasRope;

    public GameObject Tanod;
    public GameObject Dog;
    public GameObject Rope;
    GameObject tanod;
    GameObject dog;
    GameObject rope;

    Tanod tanodScript;
    Dog dogScript;


    const float dogYOffset = 3.0f;
    // public GameObject Dog;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getPosition() {
        return transform.position;
    }
    public void setRope()
    {
        rope = Instantiate(Rope, transform.position, transform.rotation);
        //tanodScript = tanod.GetComponent<Tanod>();
        hasRope = true;
    }

    public bool isRope()
    {
        return hasRope;
    }

    public void setTanod() {
        tanod = Instantiate(Tanod, transform.position, transform.rotation);
        tanodScript = tanod.GetComponent<Tanod>();
        hasTanod = true;
    }

    public bool isTanod() {
        return hasTanod;
    }

    public void setDog() {
        hasDog = true;
        Vector3 offset = new Vector3(0f, -dogYOffset, 0f);
        dog = Instantiate(Dog, transform.position + offset, transform.rotation);
        dogScript = dog.GetComponent<Dog>();
    }
    public bool isDog() {
        return hasDog;
    }

    public void tanodAttack() {
        tanodScript.attack();
    }

    public void dogAttack() {
        dogScript.attack();
    }

    public void stopTanodAttack() {
        tanodScript.stopAttack();
    }

    public void stopDogAttack() {
        dogScript.stopAttack();
    }
}
