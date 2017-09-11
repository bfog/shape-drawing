using System;
using System.Collections.Generic;
using System.IO;
using SwinGameSDK;

namespace MyGame
{
    public class Line : Shape
    {
        public Line(Color clr) : base(clr)
        {           
            Color = clr;
        }

        public Line() : this (Color.Purple) { }

        public override void Draw()
        {
            if (Selected) DrawOutline();
            SwinGame.DrawLine(Color, X, Y, X + 100, Y);
        }

        public override void DrawOutline()
        {
            SwinGame.DrawCircle(Color.Yellow, X, Y, 10);
            SwinGame.DrawCircle(Color.Yellow, X + 100, Y, 10);
        }

        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointOnLine(pt, X, Y, X + 100, Y);
        }

        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
        }
    }
}
