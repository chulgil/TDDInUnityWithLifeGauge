
using System.Collections.Generic;

public class HeartContainer
{
    private readonly List<Heart> m_hearts;

    public HeartContainer(List<Heart> hearts) => m_hearts = hearts;

    public void Replenish(int numberOfHeartPieces)
    {
        var numberOfHeartPiecesRemaining = numberOfHeartPieces;
        foreach (var heart in m_hearts)
        {
            numberOfHeartPiecesRemaining -= (4 - heart.CurrentNumberOfHeartPieces);
            heart.Replenish(numberOfHeartPieces);
            if (numberOfHeartPiecesRemaining <= 0) break;
        }
            
    }
}