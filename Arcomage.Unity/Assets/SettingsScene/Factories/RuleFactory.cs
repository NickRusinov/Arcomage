using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Rules;
using Arcomage.Unity.SettingsScene.Views;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.SettingsScene.Factories
{
    public class RuleFactory : MonoBehaviour
    {
        [Tooltip("Префаб колоды")]
        public GameObject Prefab;

        [Tooltip("Аниматор, анимирующие появление и скрытие списка выбора правил")]
        public Animator Animator;
        
        public GameObject CreateRule(Transform transform, SingleSettings singleSettings, ClassicRuleInfo ruleInfo)
        {
            var ruleObject = (GameObject)Instantiate(Prefab, transform);
            ruleObject.transform.localScale = Vector3.one;
            ruleObject.name = "Rule" + ruleInfo.Identifier;

            var ruleView = ruleObject.GetComponent<RuleView>();
            ruleView.Initialize(ruleInfo);

            var ruleButton = ruleObject.GetComponent<Button>();
            ruleButton.onClick.AddListener(() => singleSettings.Rule = ruleInfo);
            ruleButton.onClick.AddListener(() => Animator.Play("HideRuleAnimation"));

            return ruleObject;
        }
    }
}
