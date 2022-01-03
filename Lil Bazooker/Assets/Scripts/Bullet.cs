using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public GameObject explosion;

    public float explosionRadius;
    public float explosionForce;


    private bool isExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.right * speed *Time.deltaTime, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isExploded)
            return;

       if (collision.CompareTag("Player"))
        {
            return;
        }
        
        Instantiate(explosion, transform.position, transform.rotation);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D nearby in colliders)
        {
            Rigidbody2D rb2d = nearby.GetComponent<Rigidbody2D>();
            if(rb2d != null)
            {
                Debug.Log(nearby.name);
                Vector2 direction = nearby.transform.position - transform.position;
                direction = direction.normalized;

                nearby.GetComponent<Rigidbody2D>().AddForce(direction * explosionForce, ForceMode2D.Impulse);
            }
        }
        isExploded = true;
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
