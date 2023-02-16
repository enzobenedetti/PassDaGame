using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float speed = 30f;

    private bool _isRed;
    private bool _isGreen;
    private bool _isBlue;

    private SpriteRenderer _persoSprite;
    public List<Sprite> sprites;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _persoSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed);

        //Dealing with red Button
        if (Input.GetButtonDown("Red"))
        {
            _isRed = !_isRed;
            ChangeSprite();
        }

        //Dealing with green button
        if (Input.GetButtonDown("Green"))
        {
            _isGreen = !_isGreen;
            ChangeSprite();
        }

        //Dealing with blue button
        if (Input.GetButtonDown("Blue"))
        {
            _isBlue = !_isBlue;
            ChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        if (_isRed)
        {
            if (_isGreen)
            {
                _persoSprite.sprite = _isBlue ? sprites[0] : sprites[1];
            }
            else
            {
                _persoSprite.sprite = _isBlue ? sprites[2] : sprites[3];
            }
        }
        else
        {
            if (_isGreen)
            {
                _persoSprite.sprite = _isBlue ? sprites[4] : sprites[5];
            }
            else
            {
                _persoSprite.sprite = _isBlue ? sprites[6] : sprites[7];
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("lesgo");
    }
}
