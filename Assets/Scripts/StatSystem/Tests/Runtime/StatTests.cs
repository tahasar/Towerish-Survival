//using System.Collections;
//using NUnit.Framework;
//using StatSystem.Runtime;
//using UnityEditor.SceneManagement;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.TestTools;
//
//namespace StatSystem.Tests
//{
//    public class StatTests
//    {
//        [OneTimeSetUp]
//        public void OneTimeSetup()
//        {
//            EditorSceneManager.LoadSceneInPlayMode("Assets/Scripts/StatSystem/Tests/Scenes/Test.unity",
//                new LoadSceneParameters(LoadSceneMode.Single));
//        }
//        
//        [UnityTest]
//        public IEnumerator Stat_WhenModifierAplied_ChangesValue()
//        {
//            yield return null;
//            StatController statController = GameObject.FindObjectOfType<StatController>();
//            Stat physicalAttack = statController.stats["Physical Attack"];
//            Assert.AreEqual(0, physicalAttack.value);
//            physicalAttack.AddModifier(new StatModifier
//            {
//                magnitude = 5,
//                type = ModifierOperationType.Additive,
//            });
//            Assert.AreEqual(5, physicalAttack.value);
//        }
//    }
//}
//