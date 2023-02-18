using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDoThat : MonoBehaviour
{
    [SerializeField] private bool Portal;
    [SerializeField] private Transform ToGo;

    [SerializeField] private bool Die;

    [SerializeField] private bool Sound;
    [SerializeField] private AudioSource ToPlay;
    
    [SerializeField] private bool Particle;
    [SerializeField] private GameObject ToInstance;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Portal)
        {
            other.gameObject.transform.position = new Vector2(ToGo.position.x, ToGo.position.y);
        }
        
        if (other.CompareTag("Player") && Die)
        {
            Application.Quit();
            Debug.Log("Yum :)");
        }
        
        if (other.CompareTag("Player") && Sound)
        {
            ToPlay.Play();
        }
        
        if (other.CompareTag("Player") && Particle)
        {
            Instantiate(ToInstance, ToInstance.transform.position, Quaternion.identity);
        }
    }
}
