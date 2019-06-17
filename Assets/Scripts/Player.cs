
using UnityEngine;

public class Player
{
    public int CurrentHealth { get; private set; }
    public int MaximumHealth { get; private set; }

    public Player(int currentHealth, int maximumHealth = 12)
    {
        if (currentHealth < 0) throw new System.ArgumentOutOfRangeException("currentHealth");
        if (currentHealth > maximumHealth) throw new System.ArgumentOutOfRangeException("currentHealth");
        CurrentHealth = currentHealth;
        MaximumHealth = maximumHealth;
    }

    public void Heal(int amount)
    {
        CurrentHealth = Mathf.Min(CurrentHealth + amount, MaximumHealth);
        // if (CurrentHealth + amount > MaximumHealth)
        // {
        //     CurrentHealth = MaximumHealth;
        // }
        // else
        // {
        //     CurrentHealth += amount;
        // }
    }

    public void Damage(int amount)
    {
        CurrentHealth = Mathf.Max(CurrentHealth - amount, 0);
    }


    
}