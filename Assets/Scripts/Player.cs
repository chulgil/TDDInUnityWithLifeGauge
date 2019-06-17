
public class Player
{
    public int CurrentHealth { get; private set; }
    public int MaximumHealth { get; private set; }

    public event System.EventHandler<HealedEventArgs> Healed;
    public event System.EventHandler<DamagedEventArgs> Damaged;

    public Player(int currentHealth, int maximumHealth = 12)
    {
        if (currentHealth < 0) throw new System.ArgumentOutOfRangeException("currentHealth");
        if (currentHealth > maximumHealth) throw new System.ArgumentOutOfRangeException("currentHealth");
        CurrentHealth = currentHealth;
        MaximumHealth = maximumHealth;
    }

    public void Heal(int amount)
    {
        var newHealth = System.Math.Min(CurrentHealth + amount, MaximumHealth);
        if (Healed != null)
            Healed(this, new HealedEventArgs(newHealth - CurrentHealth));

        CurrentHealth = newHealth;
    }

    public void Damage(int amount)
    {
        var newHealth = System.Math.Max(CurrentHealth - amount, 0);
        if (Damaged != null)
            Damaged(this, new DamagedEventArgs(CurrentHealth - newHealth));

        CurrentHealth = newHealth;
    }

    public class HealedEventArgs : System.EventArgs
    {
        public HealedEventArgs(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; private set; }
    }

    public class DamagedEventArgs : System.EventArgs
    {
        public DamagedEventArgs(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; private set; }
    }

}