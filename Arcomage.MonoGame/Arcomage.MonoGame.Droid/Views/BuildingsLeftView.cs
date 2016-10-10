using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Views
{
    public class BuildingsLeftView : View<BuildingsViewModel>
    {
        private readonly TextView towerTextView;

        private readonly TextView wallTextView;

        public BuildingsLeftView(ContentManager contentManager, BuildingsViewModel buildingsViewModel)
            : base(buildingsViewModel, 300, 488)
        {
            var towerLeftImageView = new SpriteView
            {
                PositionX = 0, PositionY = 224, SizeX = 300, SizeY = 488, SourceX = 300, SourceY = 114,
                Texture = contentManager.Load<Texture2D>("TowerLeftImage")
            };

            var wallLeftImageView = new SpriteView
            {
                PositionX = 0, PositionY = 321, SizeX = 300, SizeY = 488, SourceX = 300, SourceY = 17,
                Texture = contentManager.Load<Texture2D>("WallLeftImage")
            };
            
            towerTextView = new StrokeTextView
            {
                PositionX = 83, PositionY = 311, SizeX = 80, SizeY = 30,
                Color = Color.White, StrokeColor = Color.Black, Text = $"{ ViewModel.Tower }",
                Font = contentManager.Load<SpriteFont>("BuildingsFont")
            };

            wallTextView = new StrokeTextView
            {
                PositionX = 181, PositionY = 311, SizeX = 60, SizeY = 30,
                Color = Color.White, StrokeColor = Color.Black, Text = $"{ ViewModel.Wall }",
                Font = contentManager.Load<SpriteFont>("BuildingsFont")
            };

            Items.Add(towerLeftImageView);
            Items.Add(wallLeftImageView);
            Items.Add(towerTextView);
            Items.Add(wallTextView);
        }

        protected override void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            towerTextView.Text = $"{ ViewModel.Tower }";
            wallTextView.Text = $"{ ViewModel.Wall }";
        }
    }
}
