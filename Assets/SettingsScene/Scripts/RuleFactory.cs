using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Rules;
using Arcomage.Unity.SettingsScene.Views;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.SettingsScene.Scripts
{
    public class RuleFactory : MonoBehaviour
    {
        [Tooltip("Префаб колоды")]
        public GameObject Prefab;

        [Tooltip("Аниматор, анимирующие появление и скрытие списка выбора правил")]
        public Animator Animator;
        
        public GameObject CreateRule(Transform transform, ClassicRuleInfo ruleInfo)
        {
            var ruleObject = (GameObject)Instantiate(Prefab, transform);
            ruleObject.transform.localScale = Vector3.one;
            ruleObject.name = "Rule" + ruleInfo.Identifier;

            var ruleView = ruleObject.GetComponent<RuleView>();
            ruleView.Initialize(ruleInfo);

            var ruleButton = ruleObject.GetComponent<Button>();
            ruleButton.onClick.AddListener(() => Settings.Instance.Rule = ruleInfo);
            ruleButton.onClick.AddListener(() => Animator.Play("HideRuleAnimation"));

            return ruleObject;
        }
    }
}
