using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FlashImage fl;
    int square;
    int prevSquare;
    bool moving;
    const float speed = 50.0f;
    const int rows = 10;
    const int cols = 10;

    public Animator animator;
    SquareScript [] squares;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        square = 0;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, squares[Mathf.Min(prevSquare + 1, square)].getPosition()) < 0.001f) {
            animator.SetBool("running", false);
            if (square == prevSquare) {
                // HAS BUG NULL EXCEPTION ERROR
                // if (squares[square].isTanod()) {
                //     squares[square].tanodAttack();
                // } else if (squares[square].isDog()) {
                //     squares[square].dogAttack();
                // }
                penalty();
                moving = false;
            } else {
                prevSquare++;
            }
        }
        if (moving) {
            animator.SetBool("running", true);
            transform.position = Vector3.MoveTowards(transform.position, squares[Mathf.Min(prevSquare + 1, square)].getPosition(), speed * Time.deltaTime);
        }
    }

    void penalty() {
        int tmp = square;
        if (squares[square].isTanod()) {
            Debug.Log("Player " + this.name + " was Caught By a Tanod!");
            int col = square % rows;
            int rowBelow = ((square / cols) - 1) * cols;
            square = rowBelow + ((cols - 1) - col);
            // squares[square].tanodAttack();
        } else if (squares[square].isDog()) {
            Debug.Log("Player " + this.name + " was attacked By a Dog!");
            square -= 4;
            // squares[square].dogAttack();
        }
        setPosition(squares[square].getPosition());

        // HAS BUG NULL EXCEPTION ERROR
        // if (squares[tmp].isTanod()) {
        //     squares[square].stopTanodAttack();
        // } else if (squares[tmp].isDog()) {
        //     squares[square].stopDogAttack();
        // }
    }

    public void setup(SquareScript[] board) {
        squares = board;
    }

    public void move(int newSquare) {
        moving = true;
        prevSquare = square;
        setSquare(newSquare);
    }

    public void penalize(int newSquare) {
        // JEROME HERE
        GameObject flash = GameObject.Find("FlashController");
        FlashImage fl = (FlashImage)flash.GetComponent(typeof(FlashImage));
        fl.show();
        fl.StartFlash(.25f, .5f, Color.red);
        setSquare(newSquare);
        setPosition(squares[newSquare].getPosition());
        fl.hide();
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
        transform.position = pos;
    }
}
