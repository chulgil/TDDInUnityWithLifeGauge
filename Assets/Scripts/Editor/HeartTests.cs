using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Editor
{
    public class HeartTests : MonoBehaviour
    {

        protected Image m_image;
        protected Heart m_heart;

        [SetUp]
        public void BeforeEveryTest()
        {
            m_image = new GameObject().AddComponent<Image>();
            m_heart = new Heart(m_image);
        }

        public class TheEmptyHeartPiecesProperty : HeartTests
        {
            [Test]
            public void _100_Percent_Image_Fill_Is_0_Empty_Heart_Pieces()
            {
                m_image.fillAmount = 1;

                Assert.AreEqual(0, m_heart.EmptyHeartPieces);
            }

            [Test]
            public void _75_Percent_Image_Fill_Is_1_Empty_Heart_Piece()
            {
                m_image.fillAmount = 0.75f;

                Assert.AreEqual(1, m_heart.EmptyHeartPieces);
            }
        }


        #region TheReplenishMethod
        public class TheFilledHeartPicecesProperty : HeartTests
        {
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

            [Test]
            public void _Throws_Exeption_For_Negative_Number_Of_Heart_Pieces()
            {
                Assert.Throws<ArgumentOutOfRangeException>(()=> m_heart.Replenish(-1));
            }

        }
        #endregion

        #region TheDepleteMethod
        public class TheDepleteMethod : HeartTests
        {
            [Test]
            public void _0_Sets_Image_With_100_Percent_Fill_To_100_Percent_Fill()
            {
                m_image.fillAmount = 1;
                
                m_heart.Deplete(0);

                Assert.AreEqual(1, m_image.fillAmount);
            }

            [Test]
            public void _1_Sets_Image_With_100_Percent_Fill_To_75_Percent_Fill()
            {
                m_image.fillAmount = 1;

                m_heart.Deplete(1);

                Assert.AreEqual(0.75f, m_image.fillAmount);
            }

            [Test]
            public void _2_Sets_Image_With_75_Percent_Fill_To_25_Percent_Fill()
            {
                m_image.fillAmount = 0.75f;

                m_heart.Deplete(2);

                Assert.AreEqual(0.25f, m_image.fillAmount);
            }

            [Test]
            public void _Throws_Exeption_For_Negative_Number_Of_Heart_Pieces()
            {
                Assert.Throws<ArgumentOutOfRangeException>(()=> m_heart.Deplete(-1));
            }


        }
        #endregion

    }
}
