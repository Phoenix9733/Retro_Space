using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    private Player _player;
  
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (_player != null)
            {
                _player.Damage();
            }

            Destroy(this.gameObject);
        }

        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
