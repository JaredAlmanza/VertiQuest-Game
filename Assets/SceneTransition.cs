using UnityEngine;

public class asdd : MonoBehaviour
{
   void Start()
{
    Time.timeScale = 1f;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
AudioManager.Instance.StopMusic();
    
}

}
