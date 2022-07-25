using UnityEngine;

public class VibrateController : MonoBehaviour
{
    private bool isVibrate = true;

    public void Vibrate()
    {
        if (isVibrate)
        {
            Vibrator.Vibrate();
        }
    }

    public void OnVibrate()
    {
        isVibrate = true;
    }

    public void OffVibrate()
    {
        isVibrate = false;
    }
}
