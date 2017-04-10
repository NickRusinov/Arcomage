using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.SettingsScene.ViewModels;
using Arcomage.Unity.SettingsScene.Views;
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
        
        public GameObject CreateRule(Transform transform, RuleViewModel viewModel)
        {
            var ruleObject = (GameObject)Instantiate(Prefab, transform);
            ruleObject.transform.localScale = Vector3.one;
            ruleObject.name = "Rule" + viewModel.RuleInfo.Identifier;

            var ruleView = ruleObject.GetComponent<RuleView>();
            ruleView.ViewModel = viewModel;

            var ruleButton = ruleObject.GetComponent<Button>();
            ruleButton.onClick.AddListener(() => viewModel.Settings.Rule = viewModel.RuleInfo);
            ruleButton.onClick.AddListener(() => Animator.Play("HideRuleAnimation"));

            return ruleObject;
        }
    }
}
