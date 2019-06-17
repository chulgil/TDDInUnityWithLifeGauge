using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Editor.Infrastructure; 

namespace Editor
{
    public class HeartContainerTests
    {
        public class TheCurrentNumberOfHeartPiecesProperty : HeartTests
        {
            [Test]
            public void _0_Image_Fill_Is_0_Heart_Pieces()
            {
                m_image.fillAmount = 0;

                Assert.AreEqual(0, m_heart.FilledHeartPieces);

            }

            [Test]
            public void _25_Percent_Image_Fill_Is_1_Heart_Piece()
            {
                m_image.fillAmount = 0.25f;

                Assert.AreEqual(1, m_heart.FilledHeartPieces);
            }

            [Test]
            public void _75_Percent_Image_Fill_Is_3_Heart_Piece()
            {
                m_image.fillAmount = 0.75f;

                Assert.AreEqual(3, m_heart.FilledHeartPieces);
            }            

        }

        #region TestReplenishMethod
        public class TestReplenishMethod
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
                // Target.fillAmount = 0;
                // var heart = new Heart(Target);
                // var HeartContainer = new HeartContainer(new List<Heart> {heart});

                ((HeartContainer)A.HeartContainer().With(
                    A.Heart().With(Target))).Replenish(0);

                Assert.AreEqual(0, Target.fillAmount);
            }

            [Test]
            public void _1_Sets_Image_With_0_Fill_To_25_Percent_Fill()
            {
                // Target.fillAmount = 0;
                // var heart = new Heart(Target);
                // var heartContainer = new HeartContainer(new List<Heart> {heart});
                // heartContainer.Replenish(1);

                ((HeartContainer) A.HeartContainer()
                    .With(A.Heart().With(Target))).Replenish(1);

                Assert.AreEqual(0.25f, Target.fillAmount);
            }


            [Test]
            public void _Empty_Hearts_Are_Replenished()
            {
                // Target.fillAmount = 0;
                // var image = new GameObject().AddComponent<Image>();
                // image.fillAmount = 1;
                // var heartContainer = new HeartContainer(
                //     new List<Heart> {new Heart(image), new Heart(Target)});
                // heartContainer.Replenish(1);
                
                ((HeartContainer) A.HeartContainer()
                    .With(
                        A.Heart().With(An.Image().WithFillAmount(1)),
                        A.Heart().With(Target))).Replenish(1);

                Assert.AreEqual(0.25f, Target.fillAmount);
            }

            [Test]
            public void _Hearts_Are_Replenished_In_Order()
            {
                // var heartContainer = new HeartContainer(
                //     new List<Heart> { A.Heart(), A.Heart().With(Target) });
                // heartContainer.Replenish(1);

                ((HeartContainer) A.HeartContainer().With(
                    A.Heart(), A.Heart().With(Target))).Replenish(1);

                Assert.AreEqual(0, Target.fillAmount);
            }

            [Test]
            public void _Distributes_Heart_Pieces_Across_Multiple_Unfilled_Hearts()
            {
                 ((HeartContainer) A.HeartContainer()
                    .With(
                        A.Heart().With(An.Image().WithFillAmount(0.75f)),
                        A.Heart().With(Target))).Replenish(2);
                Assert.AreEqual(0.25f, Target.fillAmount);
            }

            public class TheDepleteMethod
            {
                protected Image Target;

                [SetUp]
                public void BeforeEveryTest()
                {
                    Target = An.Image().WithFillAmount(1);
                }

                [Test]
                public void _0_Sets_Full_Image_To_100_Percent_Fill()
                {
                    ((HeartContainer) A.HeartContainer()
                        .With(
                            A.Heart().With(Target))).Deplete(0);

                    Assert.AreEqual(1, Target.fillAmount);
                }

                [Test]
                public void _1_Sets_Full_Image_To_75_Percent_Fill()
                {
                    ((HeartContainer) A.HeartContainer()
                        .With(
                            A.Heart().With(Target))).Deplete(1);

                    Assert.AreEqual(0.75f, Target.fillAmount);
                }
            }

        }
        #endregion


    }
}
