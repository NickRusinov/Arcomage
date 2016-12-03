using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    [RequireComponent(typeof(TextMesh))]
    public class TextWrapScript : MonoBehaviour
    {
        [SerializeField]
        public int maxSymbols;

        private TextMesh textMesh;

        private string prevText;

        public void Awake()
        {
            textMesh = GetComponent<TextMesh>();
        }

        public void Start()
        {
            UpdateText();
        }

        public void Update()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            if (prevText == textMesh.text)
                return;

            var symbols = 0;
            var builder = new StringBuilder();
            var parts = textMesh.text.Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                if (symbols + part.Length > maxSymbols)
                {
                    symbols = 0;
                    builder.Append('\n');
                }
                else
                {
                    builder.Append(' ');
                }

                symbols += part.Length;
                builder.Append(part);
            }

            prevText = builder.ToString();
            textMesh.text = builder.ToString();
        }
    }
}