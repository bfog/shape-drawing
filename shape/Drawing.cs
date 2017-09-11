using System;
using SwinGameSDK;
using System.Collections.Generic;


namespace MyGame
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Drawing() : this(Color.White) { }

        public void Draw()
        {
            SwinGame.ClearScreen(_background);
            foreach(Shape s in _shapes)
            {
                s.Draw();
            }
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach(Shape s in _shapes)
            {
                s.Selected = s.IsAt(pt);
                       
            }
        }
        public void RemoveShape(Shape s)
        {
            _shapes.Remove(s);
        }
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach(Shape s in _shapes)
                {
                    if(s.Selected)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }
        public Color Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
        }

        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        public int ShapeCount { get { return _shapes.Count; } }

    }
}
