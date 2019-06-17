using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class App : MonoBehaviour
{
    [SerializeField] private List<Image> m_images;
    [SerializeField] private int m_amount;
    private HeartContainer m_heartContainer;
    private Player m_player;
    
    private void Start() 
    {
        m_player = new Player(20, 20);
        m_heartContainer = new HeartContainer(
            m_images.Select(image => new Heart(image)).ToList());

        m_player.Healed += (sender, args) => m_heartContainer.Replenish(args.Amount);
        m_player.Damaged += (sender, args) => m_heartContainer.Deplete(args.Amount);
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_player.Heal(m_amount);
            Debug.Log("UpArrow : " + m_amount.ToString());
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_player.Damage(m_amount);
            Debug.Log("DownArrow : " + m_amount.ToString());

        }
    }
}
