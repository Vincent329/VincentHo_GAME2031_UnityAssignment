using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    // movement variables
    private Rigidbody2D m_rb;
    [SerializeField] private Vector2 m_vel;
    [SerializeField] private float m_fSpeedValue;
    [SerializeField] private float m_fMoveValue;

    // chain variables
    private float speed;
    [SerializeField] private Chain chain;

    // sprite variables
    [SerializeField] private Animator m_anim;
    private SpriteRenderer m_render;

    // collision check
    [SerializeField] private LayerMask layerCheck;

    // Text Display
    [SerializeField] private TextMeshProUGUI m_PointsText;
    [SerializeField] private int m_points;

    // Call Game Over to appear once 
    [SerializeField] private GameOverText gameOverTick;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        m_render = GetComponent<SpriteRenderer>();
        speed = 0.0f;
        UpdatePoints(0);
    }

    // Update is called once per frame
    void Update()
    {
        //HandleInputs();
        HandleTouchInputs();
        speed = Mathf.Abs(m_vel.x);
        m_anim.SetFloat("Speed", speed);

    }

    private void FixedUpdate()
    {
        AddForceToVelocity(m_rb, m_vel, 5.0f);
    }

    private void AddForceToVelocity(Rigidbody2D rb, Vector3 maxVelocity, float AppForce = 1, ForceMode2D mode = ForceMode2D.Force)
    {
        if (AppForce == 0 || maxVelocity.magnitude == 0)
            return;

        // factor down the maximum velocity
        maxVelocity = maxVelocity + maxVelocity.normalized * 0.2f * rb.drag;
        AppForce = Mathf.Clamp(AppForce, -rb.mass / Time.fixedDeltaTime, rb.mass / Time.fixedDeltaTime);

        if (rb.velocity.magnitude == 0)
        {
            rb.AddForce(maxVelocity * AppForce, mode);
        }
        else
        {
            Vector3 velocityProjectedToTarget = (maxVelocity.normalized * Vector3.Dot(maxVelocity, rb.velocity) / maxVelocity.magnitude);
            rb.AddForce((maxVelocity - velocityProjectedToTarget) * AppForce, mode);
        }
    }

    private void HandleInputs()
    {
        //if (Input.touchCount > 0)
        //{
        //    Touch t = Input.GetTouch(0);
        //    Vector2 tpos = Camera.main.ScreenToWorldPoint(t.position);
        //    if (t.phase == TouchPhase.Began)
        //    Instantiate(gObject, tpos, Quaternion.identity);
        //}
    }

    public void MoveLeft()
    {
        m_fMoveValue = -1;
        m_vel = new Vector2(m_fMoveValue * m_fSpeedValue, 0.0f);
        m_render.flipX = true;
    }

    public void MoveRight()
    {
        m_fMoveValue = 1;
        m_vel = new Vector2(m_fMoveValue * m_fSpeedValue, 0.0f);
        m_render.flipX = false;
    }

    public void Shoot()
    {
        m_anim.SetTrigger("Shoot");
        chain.SetIsFired(true);
    }
    private void HandleTouchInputs()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            Vector2 tpos = Camera.main.ScreenToWorldPoint(t.position);

            if (tpos.x > 4.0f && tpos.y > -3.0f)
            {
                MoveRight();
            } 
            else if (tpos.x <= -4.0f && tpos.y > -3.0f)
            {
                MoveLeft();
            }

            if (t.phase == TouchPhase.Ended)
            {
                m_fMoveValue = 0;
                m_vel = new Vector2(m_fMoveValue * m_fSpeedValue, 0.0f);
            }
        }
    }

    public void UpdatePoints(int value)
    {
        m_points += value;
        m_PointsText.text = "Points: " + m_points;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (layerCheck.value == 1 << collision.gameObject.layer)
        {
            Debug.Log("HitBall");
            gameOverTick.DisplayFinalScore(m_points);
            m_PointsText.enabled = false;

            Destroy(gameObject);
        }
    }
}
