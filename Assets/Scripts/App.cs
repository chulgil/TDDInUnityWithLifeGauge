using UnityEngine;
using UnityEngine.UI;

public class App : MonoBehaviour
{
    [SerializeField] private Image m_image;

    private void Update() 
    {
        var heart = new Heart(m_image);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            heart.Replenish(1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            heart.Deplete(1);
        }

    }
}
