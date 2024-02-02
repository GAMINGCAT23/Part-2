using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPositionThreshold = 0.2f;
    Vector2 LasPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rigidbody;
    public float speed;
    public AnimationCurve landing;
    float landingTimer;
    public Sprite[] planeSprite = new Sprite[4];
    SpriteRenderer spriteRender;
    public bool AllowLanding = false;
    public float score = 0;
    //aa

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        spriteRender = GetComponent<SpriteRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position + new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0));
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        spriteRender.sprite = planeSprite[(int)Random.Range(0, 4)];
        rigidbody = GetComponent<Rigidbody2D>();
        speed = Random.Range(1, 3);
    }
    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if(points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2( direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }
    private void Update()
    {
        if (AllowLanding)
        {
            landingTimer += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if(transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
                score++;
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if ( points.Count > 0 )
        {
            if (Vector2.Distance(currentPosition, points[0]) < newPositionThreshold) 
            { 
                points.RemoveAt(0);

                for(int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 newPosinion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(LasPosition, newPosinion) > newPositionThreshold)
        {
            points.Add(newPosinion);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosinion);
            LasPosition = newPosinion;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        spriteRender.color = Color.red;
        if (Vector3.Distance(transform.position, collision.gameObject.transform.position) <= 0.75f)
        {
            Destroy(gameObject);
        }
        else
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRender.color = Color.white;
    }
}
