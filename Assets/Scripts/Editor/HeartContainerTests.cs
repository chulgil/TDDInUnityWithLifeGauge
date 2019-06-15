using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Editor.Infrastructure; 

namespace Editor
{
    public class HeartContainerTests : MonoBehaviour
    {
        public class TheCurrentNumberOfHeartPiecesProperty : HeartTests
        {
            [Test]
            public void _0_Image_Fill_Is_0_Heart_Pieces()
            {
                m_image.fillAmount = 0;

                Assert.AreEqual(0, m_heart.CurrentNumberOfHeartPieces);

            }

            [Test]
            public void _25_Percent_Image_Fill_Is_1_Heart_Piece()
            {
                m_image.fillAmount = 0.25f;

                Assert.AreEqual(1, m_heart.CurrentNumberOfHeartPieces);
            }

            [Test]
            public void _75_Percent_Image_Fill_Is_3_Heart_Piece()
            {
                m_image.fillAmount = 0.75f;

                Assert.AreEqual(3, m_heart.CurrentNumberOfHeartPieces);
            }            

        }

        #region TestReplenishMethod
        public class TestReplenishMethod : HeartTests
        {
            protected Image Target;

            [SetUp]
            public void BeforeEveryTest()
            {
                Target = An.Image();
            }

            [Test]
            public void _0_Sets_Image_With_0_Fill_To_0_Fill()
            {
                Target.fillAmount = 0;
                var heart = new Heart(Target);
                var HeartContainer = new HeartContainer(new List<Heart> {heart});

                HeartContainer.Replenish(0);

                Assert.AreEqual(0, Target.fillAmount);
            }

            [Test]
            public void _1_Sets_Image_With_0_Fill_To_25_Percent_Fill()
            {
                Target.fillAmount = 0;
                var heart = new Heart(Target);
                var heartContainer = new HeartContainer(new List<Heart> {heart});

                heartContainer.Replenish(1);

                Assert.AreEqual(0.25f, Target.fillAmount);
            }


            [Test]
            public void _Empty_Hearts_Are_Replenished()
            {
                Target.fillAmount = 0;
                var image = new GameObject().AddComponent<Image>();
                image.fillAmount = 1;
                var heartContainer = new HeartContainer(
                    new List<Heart> {new Heart(image), new Heart(Target)});
                heartContainer.Replenish(1);

                Assert.AreEqual(0.25f, Target.fillAmount);
            }

            [Test]
            public void _Hearts_Are_Replenished_In_Order()
            {
                var heartContainer = new HeartContainer(
                    new List<Heart> { A.Heart(), A.Heart().With(Target) });
                heartContainer.Replenish(1);

                Assert.AreEqual(0, Target.fillAmount);
            }

            [Test]
            public void _Hearts_Are_Replenished_One_At_A_Time()
            {
                Target.fillAmount = 0;
                var image = new GameObject().AddComponent<Image>();
                image.fillAmount = 0;
                var heartContainer = new HeartContainer(
                    new List<Heart> {new Heart(image), new Heart(Target)});
                heartContainer.Replenish(0);

                Assert.AreEqual(0, Target.fillAmount);
            }
        }
        #endregion


    }
}
