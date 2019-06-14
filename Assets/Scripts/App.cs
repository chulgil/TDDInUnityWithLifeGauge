using UnityEngine;
using UnityEngine.UI;

public class App : MonoBehaviour
{
    [SerializeField] private Image m_image;
    private Heart m_heart;
    
    private void Start() 
    {
        m_heart = new Heart(m_image);
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_heart.Replenish(1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_heart.Deplete(1);
        }
    }
}
