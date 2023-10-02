using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    void Start()
    {
        StartCoroutine(SelfDestroyTimer());
    }

    IEnumerator SelfDestroyTimer()
    {
       yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(30);
            Destroy(gameObject);
        }
    }
}
