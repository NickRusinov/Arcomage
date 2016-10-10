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
    public class ResourcesLeftView : View<ResourcesViewModel>
    {
        private readonly TextView quarryTextView;

        private readonly TextView bricksTextView;

        private readonly TextView magicTextView;

        private readonly TextView gemsTextView;

        private readonly TextView dungeonsTextView;

        private readonly TextView recruitsTextView;

        public ResourcesLeftView(ContentManager contentManager, ResourcesViewModel resourcesViewModel)
            : base(resourcesViewModel, 170, 377)
        {
            var resourcesLeftImageView = new SpriteView
            {
                PositionX = 0, PositionY = 0, SizeX = 170, SizeY = 377, SourceX = 170, SourceY = 377,
                Texture = contentManager.Load<Texture2D>("ResourcesLeftImage")
            };

            quarryTextView = new StrokeTextView
            {
                PositionX = 25, PositionY = 45, SizeX = 25, SizeY = 25,
                Color = Color.White, StrokeColor = Color.Black, Text = $"+{ ViewModel.Quarry }",
                Font = contentManager.Load<SpriteFont>("ResourcesFont")
            };

            bricksTextView = new StrokeTextView
            {
                PositionX = 120, PositionY = 110, SizeX = 25, SizeY = 25,
                Color = Color.White, StrokeColor = Color.Black, Text = $"{ ViewModel.Bricks }",
                Font = contentManager.Load<SpriteFont>("ResourcesFont")
            };
            
            magicTextView = new StrokeTextView
            {
                PositionX = 25, PositionY = 160, SizeX = 25, SizeY = 25,
                Color = Color.White, StrokeColor = Color.Black, Text = $"+{ ViewModel.Magic }",
                Font = contentManager.Load<SpriteFont>("ResourcesFont")
            };

            gemsTextView = new StrokeTextView
            {
                PositionX = 120, PositionY = 225, SizeX = 25, SizeY = 25,
                Color = Color.White, StrokeColor = Color.Black, Text = $"{ ViewModel.Gems }",
                Font = contentManager.Load<SpriteFont>("ResourcesFont")
            };
            
            dungeonsTextView = new StrokeTextView
            {
                PositionX = 25, PositionY = 275, SizeX = 25, SizeY = 25,
                Color = Color.White, StrokeColor = Color.Black, Text = $"+{ ViewModel.Dungeons }",
                Font = contentManager.Load<SpriteFont>("ResourcesFont")
            };

            recruitsTextView = new StrokeTextView
            {
                PositionX = 120, PositionY = 340, SizeX = 25, SizeY = 25,
                Color = Color.White, StrokeColor = Color.Black, Text = $"{ ViewModel.Recruits }",
                Font = contentManager.Load<SpriteFont>("ResourcesFont")
            };
            
            Items.Add(resourcesLeftImageView);
            Items.Add(quarryTextView);
            Items.Add(bricksTextView);
            Items.Add(magicTextView);
            Items.Add(gemsTextView);
            Items.Add(dungeonsTextView);
            Items.Add(recruitsTextView);
        }

        protected override void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            quarryTextView.Text = $"+{ ViewModel.Quarry }";
            bricksTextView.Text = $"{ ViewModel.Bricks }";
            magicTextView.Text = $"+{ ViewModel.Magic }";
            gemsTextView.Text = $"{ ViewModel.Gems }";
            dungeonsTextView.Text = $"+{ ViewModel.Dungeons }";
            recruitsTextView.Text = $"{ ViewModel.Recruits }";
        }
    }
}
