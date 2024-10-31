using UnityEngine;

public class BGMLoopController : MonoBehaviour
{
    [SerializeField] Director Director;
    public AudioSource AudioSource;
    public int LoopEndSamples; // A
    public int LoopLengthSamples; // B
    private void Update()
    {
        if (AudioSource.timeSamples >= LoopEndSamples)
        {
            AudioSource.timeSamples = LoopLengthSamples;
        }
        if (Director.getgameover)
        {
            AudioSource.volume -= 0.01f;
        }
    }
}