using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.Framework.Bindings;
using UnityEngine;

namespace Arcomage.Unity.Framework.Scripts
{
    [RequireComponent(typeof(TextMesh))]
    public class TextWrapScript : View
    {
        [Tooltip("Количество символов в строке")]
        public int maxSymbols;

        public void Awake()
        {
            var textMesh = GetComponent<TextMesh>();

            Bind(textMesh, tm => tm.text)
                .OnChangedAndInit(s => textMesh.text = UpdateText(s));
        }

        private string UpdateText(string text)
        {
            var symbols = 0;
            var builder = new StringBuilder();
            var parts = text.Replace("-", "- ").Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                if (symbols + part.Length > maxSymbols)
                {
                    symbols = 0;
                    builder.Append('\n');
                }
                else if (part[part.Length - 1] != '-')
                {
                    builder.Append(' ');
                }

                symbols += part.Length;
                builder.Append(part);
            }

            return builder.ToString().Trim(' ', '\n');
        }
    }
}
