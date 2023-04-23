using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.5f;
    [SerializeField]
    private AudioClip _collectSound;



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
        Player _player = GameObject.Find("Player").GetComponent<Player>();

        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(_collectSound, transform.position);
            if (_player != null)
            {
                _player.doubleBulletActive();
            }

            Destroy(this.gameObject);
        }

        if (other.tag == "Player" && this.tag == "LivesPowerUp")
        {
            AudioSource.PlayClipAtPoint(_collectSound, transform.position);
            if (_player != null)
            {
                _player.AddLives();
            }

            Destroy(this.gameObject);
        }
    }
}
