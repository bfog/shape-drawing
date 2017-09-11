﻿using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
    public class Circle : Shape
    {
        private int _radius;

        public Circle(Color c, int radius) : base(c)
        {
            _radius = radius;
        }

        public Circle() : this(Color.Blue, 50) { }

        public override void Draw()
        {
            if(Selected) DrawOutline();
            SwinGame.FillCircle(Color, X, Y, _radius);  
        }

        public override void DrawOutline()
        {
            SwinGame.DrawCircle(Color, X, Y, _radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointInCircle(pt, X, Y, Radius);
        }
        public int Radius
        {
            get
            {
                return _radius;
            }

            set
            {
                _radius = value;
            }
        }
    }
}
