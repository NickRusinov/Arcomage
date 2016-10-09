using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Views
{
    public class BuildingsRightView : View<BuildingsViewModel>
    {
        public BuildingsRightView(ContentManager contentManager, BuildingsViewModel buildingsViewModel)
            : base(buildingsViewModel, 300, 488)
        {
            var towerRightImageView = new SpriteView
            {
                PositionX = 0, PositionY = 224, SizeX = 300, SizeY = 488, SourceX = 300, SourceY = 114,
                Texture = contentManager.Load<Texture2D>("TowerRightImage")
            };

            var wallRightImageView = new SpriteView
            {
                PositionX = 0, PositionY = 321, SizeX = 300, SizeY = 488, SourceX = 300, SourceY = 17,
                Texture = contentManager.Load<Texture2D>("WallRightImage")
            };

            Items.Add(towerRightImageView);
            Items.Add(wallRightImageView);
        }
    }
}
