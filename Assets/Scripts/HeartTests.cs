using System;
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

        #region TheReplenishMethod
        public class TheReplenishMethod
        {
            private Image m_image;
            private Heart m_heart;

            [SetUp]
            public void BeforeEveryTest()
            {
                m_image = new GameObject().AddComponent<Image>();
                m_heart = new Heart(m_image);
            }
        

            [Test]
            public void _0_Sets_Image_With_0_Fill_To_0_Fill()
            {
                m_image.fillAmount = 0;

                m_heart.Replenish(0);

                Assert.AreEqual(0, m_image.fillAmount);
            }

            [Test]
            public void _1_Sets_Image_With_0_Fill_To_25_Percent_Fill()
            {
                    m_image.fillAmount = 0;

                    m_heart.Replenish(1);

                    Assert.AreEqual(0.25f, m_image.fillAmount);            
            }

            [Test]
            public void _1_Sets_Image_With_25_Percent_Fill_To_50_Percent_Fill()
            {
                    m_image.fillAmount = 0.25f;

                    m_heart.Replenish(1);
                    
                    Assert.AreEqual(0.5f, m_image.fillAmount);            
            }                  

        }
        #endregion

        #region TheDepleteMethod
        public class TheDepleteMethod
        {
            [Test]
            public void _0_Sets_Image_With_1_Fill_To_1_Fill()
            {
                var image = new GameObject().AddComponent<Image>();
                var heart = new Heart(image);
                heart.Deplete(0);

                Assert.AreEqual(1, image.fillAmount);
            }

        }
        #endregion

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

        public void Deplete(int numberOfHeartPieces)
        {

            throw new NotImplementedException();
        }
    }    
}
