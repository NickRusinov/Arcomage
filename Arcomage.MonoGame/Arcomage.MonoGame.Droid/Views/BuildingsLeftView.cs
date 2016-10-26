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
        private readonly SpriteView towerImageView;

        private readonly SpriteView wallImageView;

        private readonly TextView towerTextView;

        private readonly TextView wallTextView;

        public BuildingsLeftView(ContentManager contentManager, BuildingsViewModel buildingsViewModel)
            : base(buildingsViewModel, 300, 488)
        {
            towerImageView = new SpriteView
            {
                PositionX = 0, PositionY = 224 - CalculateTowerHeight(buildingsViewModel),
                SourceX = 300, SourceY = 114 + CalculateTowerHeight(buildingsViewModel),
                SizeX = 300, SizeY = 488,
                Texture = contentManager.Load<Texture2D>("TowerLeftImage")
            };

            wallImageView = new SpriteView
            {
                PositionX = 0, PositionY = 321 - CalculateWallHeight(buildingsViewModel),
                SourceX = 300, SourceY = 17 + CalculateWallHeight(buildingsViewModel),
                SizeX = 300, SizeY = 488,
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

            Items.Add(towerImageView);
            Items.Add(wallImageView);
            Items.Add(towerTextView);
            Items.Add(wallTextView);
        }

        protected override void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            towerTextView.Text = $"{ ViewModel.Tower }";
            towerImageView.PositionY = 224 - CalculateTowerHeight(ViewModel);
            towerImageView.SourceY = 114f + CalculateTowerHeight(ViewModel);

            wallTextView.Text = $"{ ViewModel.Wall }";
            wallImageView.PositionY = 321f - CalculateWallHeight(ViewModel);
            wallImageView.SourceY = 17f + CalculateWallHeight(ViewModel);
        }

        private static float CalculateTowerHeight(BuildingsViewModel buildingsViewModel)
        {
            return 224f * buildingsViewModel.Tower / buildingsViewModel.MaxTower;
        }

        private static float CalculateWallHeight(BuildingsViewModel buildingsViewModel)
        {
            return 224f * buildingsViewModel.Wall / buildingsViewModel.MaxWall;
        }
    }
}
