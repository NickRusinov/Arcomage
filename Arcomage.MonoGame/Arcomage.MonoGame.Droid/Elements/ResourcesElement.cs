using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.ViewModels;

namespace Arcomage.MonoGame.Droid.Elements
{
    public class ResourcesElement : PanelElement
    {
        public ResourcesElement(ResourcesViewModel resourcesViewModel, bool flipped)
        {
            var bricksResourceElement = new ResourceElement(resourcesViewModel.Bricks, flipped)
                { PositionX = 0.0f, PositionY = 0.0f, SizeX = 1.0f, SizeY = 0.36f };

            var gemsResourceElement = new ResourceElement(resourcesViewModel.Gems, flipped)
                { PositionX = 0.0f, PositionY = 0.33f, SizeX = 1.0f, SizeY = 0.36f };

            var recruitsResourceElement = new ResourceElement(resourcesViewModel.Recruits, flipped)
                { PositionX = 0.0f, PositionY = 0.66f, SizeX = 1.0f, SizeY = 0.36f };

            Elements = new List<Element> { bricksResourceElement, gemsResourceElement, recruitsResourceElement };
        }
    }
}
