using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Random = UnityEngine.Random;

public class CameraProfile : MonoBehaviour
{
    public PostProcessProfile profile;
    public CinemachineVirtualCamera cineMachine;

    public float basicLensSize = 5.09f;
    public float hiddenLensSize = 4f;
    public float lensSpeed = 2.5f;

    public PlayerMovement playerMovement;
    private Vignette _vignette;

    public float vignetteValue = 0.42f;
    public float transitionSpeed = 0.6f;

    private void Awake()
    {
        _vignette = profile.GetSetting<Vignette>();
        _vignette.intensity.value = 0f;
    }

    private void Update()
    {
        switch (playerMovement.isHidden)
        {
            case true when _vignette.intensity.value < vignetteValue:
                _vignette.intensity.value += Time.deltaTime * transitionSpeed;
                _vignette.color.value = new Color(playerMovement.isRed ? 1f : 0f, playerMovement.isGreen ? 1f : 0f,
                    playerMovement.isBlue ? 1f : 0f);
                if (!GetComponent<AudioSource>().isPlaying)
                {
                    GetComponent<AudioSource>().pitch = Random.Range(0.97f, 1.03f);
                    GetComponent<AudioSource>().Play();
                }
                break;
            case false when _vignette.intensity.value > 0f:
                _vignette.intensity.value -= Time.deltaTime * transitionSpeed;
                break;
        }

        if (playerMovement.underSpot)
        {
            if (playerMovement.isHidden && cineMachine.m_Lens.OrthographicSize > hiddenLensSize)
            {
                cineMachine.m_Lens.OrthographicSize -= Time.deltaTime * lensSpeed;
            }
            else
            {
                //perdu lol
                
            }
        }
        else
        {
            if (playerMovement.isHidden && cineMachine.m_Lens.OrthographicSize < basicLensSize)
            {
                cineMachine.m_Lens.OrthographicSize += Time.deltaTime * lensSpeed;
            }
        }
    }
}