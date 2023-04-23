using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private GameObject _doubleBulletPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _nextFire = 0.0f;
    [SerializeField]
    private int _lives = 1;
    private SpawnManager _spawnManager;
    private bool _doubleBulletActive = false;
    [SerializeField]
    private int _punti;
    private int _record;
    private UIManager _uiManager;
    [SerializeField]
    private Sprite[] spriteArray;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private AudioClip _bulletSound;
    private AudioSource _audioSource;
    [SerializeField]
    private GameObject _explosionPrefab;
    private GameObject _explosion;

    void Start()
    {
        transform.position = new Vector3(-7.21f, 2.35f, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _bulletSound;
    }

    void Update()
    {
        Movement();
        NextFire();
        SpriteMovement();
    }


    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-8f,8f), Mathf.Clamp(transform.position.y, -2f, 3.7f), transform.position.z);
    }

    void SpriteMovement()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeSpriteDown();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            ChangeSprite();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeSpriteUp();
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            ChangeSprite();
        }
    }

    void ChangeSpriteUp()
    {
        spriteRenderer.sprite = spriteArray[2];
    }

    void ChangeSpriteDown()
    {
        spriteRenderer.sprite = spriteArray[1];
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = spriteArray[0];
    }

    void Fire()
    {
        _nextFire = Time.time + _fireRate;

        if (_doubleBulletActive == true)
        {
            Instantiate(_doubleBulletPrefab, transform.position + new Vector3(-9.55f, 1.24f, 0), Quaternion.identity);
        }
        else 
        {
            Instantiate(_bulletPrefab, transform.position + new Vector3(1.3f, -0.3f, 0), Quaternion.identity);
        }
        _audioSource.Play();
    }

    void NextFire()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > _nextFire)
        {
            Fire();
        }
    }

    public void doubleBulletActive()
    {
        _doubleBulletActive = true;
        StartCoroutine(doubleBulletPowerUpRoutine());
    }

    IEnumerator doubleBulletPowerUpRoutine()
    {
        yield return new WaitForSeconds(7.0f);
        _doubleBulletActive = false;
    }

    public void Damage()
    {
        _lives--;
        _uiManager.UpdateLives(_lives);

        if (_lives == 0)
        {
            _explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _explosion.GetComponent<AudioSource>().PlayDelayed(0.35f);
            Destroy(_explosion, 1.26f);
            Destroy(this.gameObject);
            _spawnManager.PlayerDeath();
            AddRecord();
            _uiManager.Lose();
        }
    }

    public void AddLives ()
    {
        _lives++;
        _uiManager.UpdateLives(_lives);
    }


    public void AddPunti()
    {
        _punti += 100;
        _uiManager.UpdatePunti(_punti);

    }

    public void AddPunti2()
    {
        _punti += 200;
        _uiManager.UpdatePunti(_punti);

    }
    public void AddRecord()
    {
        if (_punti > _record)
        {
            _record = _punti;
            _uiManager.UpdateRecord(_record);
        }
    }
}

