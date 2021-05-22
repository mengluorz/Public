using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton class:GameManager
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion
    Camera cam;
    public Trajectory trajectory;
    public Ball ball;
    [SerializeField] float pushForce = 4f;
    public bool isDragging = false;
    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    private void Start()
    {
        cam = Camera.main;
        ball.DesactivateRb();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            OnDragStart();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnDragEnd();
        }
        if (isDragging)
            OnDrag();
    }
    void OnDragStart()
    {
        ball.DesactivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        trajectory.Show();

    }
    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;
        Debug.DrawLine(startPoint, endPoint);
        trajectory.UpdateDots(ball.Pos, force);
    }
    void OnDragEnd()
    {
        ball.ActivateRb();
        ball.Push(force);
        trajectory.Hide();
    }

}
