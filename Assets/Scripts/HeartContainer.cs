
using System.Collections.Generic;
using System.Linq;

public class HeartContainer
{
    private readonly List<Heart> m_hearts;

    public HeartContainer(List<Heart> hearts) => m_hearts = hearts;

    public void Replenish(int heartPieces)
    {
        foreach (var heart in m_hearts)
        {
            var toReplenish = heartPieces < heart.EmptyHeartPieces 
                ? heartPieces
                : heart.EmptyHeartPieces;

            heartPieces -= heart.EmptyHeartPieces;
            heart.Replenish(toReplenish);
            if (heartPieces <= 0) break;
        }
    }

    public void Deplete(int heartPieces)
    {
        foreach (var heart in m_hearts.AsEnumerable().Reverse())
        {
            var toDeplete = heartPieces < heart.FilledHeartPieces
                ? heartPieces
                : heart.FilledHeartPieces;

            heartPieces -= heart.FilledHeartPieces;
            heart.Deplete(toDeplete);
            if (heartPieces <= 0) break;
        }        
    }
}