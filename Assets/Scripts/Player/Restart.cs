using UnityEngine;

public class Restart : MonoBehaviour, IDeadable
{
    public void Dead()
    {
        StageManager.Instance.Restart();
    }
}
