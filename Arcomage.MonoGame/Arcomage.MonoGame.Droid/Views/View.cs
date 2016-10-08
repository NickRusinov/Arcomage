using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Views
{
    public abstract class View
    {
        public float PositionX { get; set; }

        public float PositionY { get; set; }

        public float SizeX { get; set; }

        public float SizeY { get; set; }

        public bool IsVisible { get; set; }
        
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

        public abstract void Draw(Canvas canvas);
    }

    public abstract class View<TViewModel> : PanelView
    {
        private TViewModel viewModel;

        public TViewModel ViewModel
        {
            get { return viewModel; }
            set
            {
                if (viewModel != null)
                    UnbindViewModel(viewModel);

                if (value != null)
                    BindViewModel(value);

                viewModel = value;
            }
        }

        protected virtual void UnbindViewModel(TViewModel viewModel) { }

        protected virtual void BindViewModel(TViewModel viewModel) { }
    }
}
