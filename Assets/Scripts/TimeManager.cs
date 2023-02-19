using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private GameObject VotreTicketIciSVP;
    private TicketForZeMemesMuseum Verification;

    private void Start()
    {
        if (VotreTicketIciSVP == null) return; 
        Verification = (TicketForZeMemesMuseum) VotreTicketIciSVP.GetComponent(typeof(TicketForZeMemesMuseum));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Verification != null && other.CompareTag("Player"))
        {
            SceneManager.LoadScene("ZeMemesMuseum");
        }
        
        if (Verification == null && other.CompareTag("Player"))
        {
            Debug.LogWarning("Pour entrez, veuillez poser un ticket valide SVP");
        }
    }
}
