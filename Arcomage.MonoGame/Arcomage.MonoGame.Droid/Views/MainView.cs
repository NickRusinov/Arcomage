using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Handlers;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Views
{
    public class MainView : View
    {
        public View View { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public override void Animate(GameTime gameTime) => View.Animate(gameTime);

        public override bool Handle(Handler handler, HandlerData handlerData) => View.Handle(handler, handlerData);

        public override void Draw(Canvas canvas) => View.Draw(canvas);
    }
}