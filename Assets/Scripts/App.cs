using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class App : MonoBehaviour
{
    [SerializeField] private List<Image> m_images;
    [SerializeField] private int m_amount;
    private HeartContainer m_heartContainer;
    
    private void Start() 
    {
        m_heartContainer = new HeartContainer(
            m_images.Select(image => new Heart(image)).ToList());
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_heartContainer.Replenish(m_amount);
            Debug.Log("UpArrow : " + m_amount.ToString());
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_heartContainer.Deplete(m_amount);
            Debug.Log("DownArrow : " + m_amount.ToString());

        }
    }
}
