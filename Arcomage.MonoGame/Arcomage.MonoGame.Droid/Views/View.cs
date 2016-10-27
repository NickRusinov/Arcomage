using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.MonoGame.Droid.Handlers;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Views
{
    public abstract class View
    {
        public float PositionX { get; set; }

        public float PositionY { get; set; }

        public float SizeX { get; set; }

        public float SizeY { get; set; }

        public float Opacity { get; set; } = 1f;

        public bool IsVisible { get; set; } = true;
        
        public Vector2 Position
        {
            get { return new Vector2(PositionX, PositionY); }
            set { PositionX = value.X; PositionY = value.Y; }
        }

        public Vector2 Size
        {
            get { return new Vector2(SizeX, SizeY); }
            set { SizeX = value.X; SizeY = value.Y; }
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)PositionX, (int)PositionY, (int)SizeX, (int)SizeY); }
            set { PositionX = value.X; PositionY = value.Y; SizeX = value.Width; SizeY = value.Height; }
        }

        public virtual bool Handle(Handler handler, HandlerData handlerData) => false;

        public virtual void Animate(GameTime gameTime) { }

        public abstract void Draw(Canvas canvas);
    }

    public abstract class View<TViewModel> : PanelView
        where TViewModel : ViewModel
    {
        protected View(TViewModel viewModel, float originalSizeX, float originalSizeY)
            : base(originalSizeX, originalSizeY)
        {
            ViewModel = viewModel;
            ViewModel.PropertyChanged += ViewModelOnPropertyChanged;
        }

        public TViewModel ViewModel { get; }

        protected virtual void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs) { }
    }
}
