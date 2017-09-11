using System;
using SwinGameSDK;
using System.Collections.Generic;
using System.IO;

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

        public void Save(string filename)
        {
            StreamWriter writer;

            writer = new StreamWriter(filename);

            writer.WriteLine(Background.ToArgb());
            writer.WriteLine(ShapeCount);

            try
            {
                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            finally
            {
                writer.Close();
            }
        }

        public void Load(string filename)
        {
            StreamReader reader;
            int count;
            Shape s;
            string kind;

            _shapes.Clear();

            reader = new StreamReader(filename);

            Background = Color.FromArgb(reader.ReadInteger());
            count = reader.ReadInteger();

            try
            {
                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();

                    s = Shape.CreateShape(kind);

                    s.LoadFrom(reader);
                    AddShape(s);
                }
            }
            finally
            {
                reader.Close();
            }
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
