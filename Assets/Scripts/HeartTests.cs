using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class HeartTests : MonoBehaviour
    {
        public class TheReplenishMethod
        {
            [Test]
            public void _0_Sets_Image_With_0_Fill_To_0_Fill()
            {
                var image = new GameObject().AddComponent<Image>();
                image.fillAmount = 0;
                var heart = new Heart(image);

                heart.Replenish(0);
                Assert.AreEqual(0, image.fillAmount);
            }

            [Test]
            public void _1_Sets_Image_With_0_Fill_To_25_Percent_Fill()
            {
                    var image = new GameObject().AddComponent<Image>();
                    image.fillAmount = 0;
                    var heart = new Heart(image);

                    heart.Replenish(1);
                    Assert.AreEqual(0.25f, image.fillAmount);            
            }

            [Test]
            public void _1_Sets_Image_With_25_Percent_Fill_To_50_Percent_Fill()
            {
                    var image = new GameObject().AddComponent<Image>();
                    image.fillAmount = 0.25f;
                    var heart = new Heart(image);

                    heart.Replenish(1);
                    Assert.AreEqual(0.5f, image.fillAmount);            
            }                  

        }
       

    }
    public class Heart
    {
        private const float FillPerHeartPercentage = 0.25f;
        private readonly Image m_image;

        public Heart(Image image)
        {
            m_image = image;
        }

        public void Replenish(int numberOfHeartPieces)
        {
            m_image.fillAmount += numberOfHeartPieces* FillPerHeartPercentage;
        }
    }    
}
