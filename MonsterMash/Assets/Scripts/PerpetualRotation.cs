using UnityEngine;
using DG.Tweening;

public class PerpetualRotation : MonoBehaviour
{
    void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), 5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear).SetRelative(true);
    }
}
