using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    private Player _player;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _fireRate = 3f;
    private float _nextFire = -1f;
    [SerializeField]
    private int _lives = 2;
    private GameObject _enemyBullet;
    [SerializeField]
    private GameObject _explosionPrefab;
    private GameObject _explosion;
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        Movement();
        NextFire();
        
    }

    void Movement()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        {
            _player.AddPunti2();
            _explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _explosion.GetComponent<AudioSource>().Play();
            Destroy(_explosion, 0.40f);
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
    }

    void Fire()
    {
        _nextFire = Time.time + _fireRate;
        _enemyBullet = Instantiate(_bulletPrefab, transform.position + new Vector3(-2.03f, -0.02f, 0), Quaternion.identity);
        Bullet[] bullets = _enemyBullet.GetComponentsInChildren<Bullet>();

        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].EnemyBullet();
        }
    }

    void NextFire()
    {
        if (Time.time > _nextFire)
        {
            Fire();
        }
    }


}
