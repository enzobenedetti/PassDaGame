using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float speed = 30f;

    public bool isRed;
    public bool isGreen;
    public bool isBlue;
    [HideInInspector]public bool isHidden;

    private ZoneColor _zoneColor;
    private int _zoneNumber;
    
    private SpriteRenderer _persoSprite;
    public List<Sprite> sprites;
    public List<Image> uiColor;

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
            isRed = !isRed;
            ChangeSprite();
        }

        //Dealing with green button
        if (Input.GetButtonDown("Green"))
        {
            isGreen = !isGreen;
            ChangeSprite();
        }

        //Dealing with blue button
        if (Input.GetButtonDown("Blue"))
        {
            isBlue = !isBlue;
            ChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        if (isRed)
        {
            if (isGreen)
            {
                _persoSprite.sprite = isBlue ? sprites[0] : sprites[1];
            }
            else
            {
                _persoSprite.sprite = isBlue ? sprites[2] : sprites[3];
            }
        }
        else
        {
            if (isGreen)
            {
                _persoSprite.sprite = isBlue ? sprites[4] : sprites[5];
            }
            else
            {
                _persoSprite.sprite = isBlue ? sprites[6] : sprites[7];
            }
        }
        
        UpdateUI();
        isHidden = _persoSprite.sprite.name == _zoneColor.ToString();
    }

    void UpdateUI()
    {
        Color shadow = new Color(0.25f, 0.25f, 0.25f);
        if (isRed)//Is red
        {
            uiColor[0].color = Color.white;
            if (isGreen)
            {
                uiColor[1].color = Color.white;
                uiColor[2].color = Color.white;
                if (isBlue)
                {
                    uiColor[3].color = Color.white;
                    uiColor[4].color = Color.white;
                    uiColor[5].color = Color.white;
                    uiColor[6].color = Color.white;
                }
                else
                {
                    uiColor[3].color = shadow;
                    uiColor[4].color = shadow;
                    uiColor[5].color = shadow;
                    uiColor[6].color = shadow;
                }
            }
            else
            {
                uiColor[1].color = shadow;
                uiColor[2].color = shadow;
                uiColor[5].color = shadow;
                uiColor[6].color = shadow;
                if (isBlue)
                {
                    uiColor[3].color = Color.white;
                    uiColor[4].color = Color.white;
                }
                else
                {
                    uiColor[3].color = shadow;
                    uiColor[4].color = shadow;
                }
            }
        }
        else//Is not red
        {
            uiColor[0].color = shadow;
            uiColor[2].color = shadow;
            uiColor[4].color = shadow;
            uiColor[6].color = shadow;
            if (isGreen)
            {
                uiColor[1].color = Color.white;
                if (isBlue)
                {
                    uiColor[3].color = Color.white;
                    uiColor[5].color = Color.white;
                }
                else
                {
                    uiColor[3].color = shadow;
                    uiColor[5].color = shadow;
                }
            }
            else
            {
                uiColor[1].color = shadow;
                uiColor[5].color = shadow;
                if (isBlue)
                {
                    uiColor[3].color = Color.white;
                }
                else
                {
                    uiColor[3].color = shadow;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ZoneColor"))
        {
            _zoneNumber++;
            _zoneColor = other.GetComponent<SneakZone>().color;
            isHidden = _persoSprite.sprite.name == _zoneColor.ToString();
        }
        if (other.CompareTag("Spot")) Debug.Log("T'as perdu lol");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ZoneColor"))
        {
            _zoneNumber--;
            if (_zoneNumber <= 0) _zoneColor = ZoneColor.None;
            isHidden = _persoSprite.sprite.name == _zoneColor.ToString();
        }
    }
}
