using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] FlashImage _flashImage = null;
    // Start is called before the first frame update
    public void flashNow()
    {
        _flashImage.show();
        _flashImage.StartFlash(.25f, .5f, Color.red);
        _flashImage.hide();
    }
}
