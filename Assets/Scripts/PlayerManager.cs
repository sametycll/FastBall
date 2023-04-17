using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField][Range(0f, 1f)] float maxSpeed;

    float velocity;
    Transform ball;
    Vector3 startMousePos, startBallPos;
    bool moveTheBall;
    Rigidbody rb;
    Collider cd;
    PathManager _pathManager;



    void Start()
    {
        ball = transform;
        rb = GetComponent<Rigidbody>();
        cd = GetComponent<Collider>();
        _pathManager = FindObjectOfType<PathManager>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && MenuManager.startState) //&& mm.gameState
        {
            moveTheBall = true;
            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlan.Raycast(ray, out var distance))
            {
                startMousePos = ray.GetPoint(distance);
                startBallPos = ball.position;

            }
        }
        else if (Input.GetMouseButtonUp(0) && MenuManager.startState)
        {
            moveTheBall = false;
        }

        if (moveTheBall)
        {
            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlan.Raycast(ray, out var distance))
            {
                Vector3 mouseNewPos = ray.GetPoint(distance);
                Vector3 MouseNewPos = mouseNewPos - startMousePos;
                Vector3 DesireBallPos = MouseNewPos + startBallPos;

                DesireBallPos.x = Mathf.Clamp(DesireBallPos.x, -1.5f, 1.5f);

                ball.position = new Vector3(Mathf.SmoothDamp(ball.position.x, DesireBallPos.x, ref velocity, maxSpeed), ball.position.y, ball.position.z);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            //Debug.Log("trigger enter");
            gameObject.SetActive(false);
            Time.timeScale = 0;
            //gameoverMenu
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Path"))
        {
            //Debug.Log("trigger exit");
            rb.isKinematic = cd.isTrigger = false;

            rb.velocity = new Vector3(0f,8.5f,0f);
            _pathManager.pathSpeed *= 2; 
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Path"))
        {
            //Debug.Log("cl enter");
            rb.isKinematic = cd.isTrigger = true;
            _pathManager.pathSpeed /= 2;

        }
    }

}
