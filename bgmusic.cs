using UnityEngine;
using System.Collections;

public class bgmusic : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float minPitch = 0.89f; // Minimum pitch value
    [SerializeField]
    private float maxPitch = 1.64f; // Maximum pitch value

    [SerializeField]
    private float delayTime = 120f; // 2 minutes in seconds

    [SerializeField]
    private float pitchChangeInterval = 10f; // Interval between pitch changes

    private float currentPitch;

    void Start()
    {
        StartCoroutine(PlayAudioWithDelay());
        StartCoroutine(ChangePitchContinuously());
    }

    private IEnumerator PlayAudioWithDelay()
    {
        yield return new WaitForSeconds(delayTime);
        audioSource.Play();
    }

    private IEnumerator ChangePitchContinuously()
    {
        yield return new WaitForSeconds(delayTime);

        while (true)
        {
            currentPitch = Random.Range(minPitch, maxPitch);
            audioSource.pitch = currentPitch;

            yield return new WaitForSeconds(pitchChangeInterval);
        }
    }
}



/*
using UnityEngine;
using System.Collections;

public class bgmusic : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float minPitch = 0.89f; // Minimum pitch value
    [SerializeField]
    private float maxPitch = 1.64f; // Maximum pitch value

    [SerializeField]
    private float pitchChangeInterval = 10f; // Interval between pitch changes

    private float currentPitch;

    void Start()
    {
        audioSource.Play();
        StartCoroutine(ChangePitchContinuously());
    }

    private IEnumerator ChangePitchContinuously()
    {
        while (true)
        {
            currentPitch = Random.Range(minPitch, maxPitch);
            audioSource.pitch = currentPitch;

            yield return new WaitForSeconds(pitchChangeInterval);
        }
    }
}



using UnityEngine;
using System.Collections;

public class bgmusic : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float delayTime = 120f; // 2 minutes in seconds

    void Start()
    {
        StartCoroutine(PlayAudioWithDelay());
    }

    private IEnumerator PlayAudioWithDelay()
    {
        yield return new WaitForSeconds(delayTime);
        audioSource.Play();
    }
}
*/
