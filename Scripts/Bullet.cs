using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;
    private bool _isEnemy = false;
    [SerializeField]
    private GameObject _explosionPrefab;
    private GameObject _explosion;
    [SerializeField]
    private Enemy2 _enemy2;

    void Update()
    {
        CalculateMovement();
        
    }

    void CalculateMovement()
    {
        if (_isEnemy == true)
        {
            MovementLeft();
        }
        else
        {
            MovementRight();
        }
    }

    void MovementRight()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);

        if (transform.position.x > 10f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
    }

    void MovementLeft()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
    }

    public void EnemyBullet()
    {
        _isEnemy = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player _player = GameObject.Find("Player").GetComponent<Player>();
 
        if (other.tag == "Player" && _isEnemy == true)
        {
            if (_player != null)
            {
                _player.Damage();
            }

            Destroy(this.gameObject);
        }

        if (other.tag == "Enemy" && _isEnemy == false)
        {
            if (_player != null)
            {
                _player.AddPunti();
            }
            _explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _explosion.GetComponent<AudioSource>().Play();
            Destroy(_explosion, 0.45f);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.tag == "En2" && _isEnemy == false)
        {

            _enemy2 = other.gameObject.GetComponent<Enemy2>();
            _enemy2.Damage();
            Destroy(this.gameObject);
        }

        if (other.tag == "Enemy" && _isEnemy == true)
        {
           Destroy(this.gameObject);
        }

        if (other.tag == "En2" && _isEnemy == true)
        {
            Destroy(this.gameObject);
        }

    }
}