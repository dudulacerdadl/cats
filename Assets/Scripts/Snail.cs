using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    private bool colliding;
    private bool playerDestroyed = false;

    public float speed;

    public Transform rightCol;
    public Transform leftCol;
    public AudioSource damageSound;
    public Transform headPoint;

    public LayerMask layer;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per framexsd sa
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag is "Player")
        {
            damageSound.Play();
            float height = col.contacts[0].point.y - headPoint.position.y;

            if (height > 0 && !playerDestroyed)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("die");
                rig.bodyType = RigidbodyType2D.Kinematic;
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;

                Destroy(gameObject, .5f);
            }
            else
            {
                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(col.gameObject);
            }
        }
    }
}
