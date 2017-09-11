using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle, 
            Line
        }
        public static void Main()
        {
            Shape.RegisterShape("Rectangle", typeof(Rectangle));
            Shape.RegisterShape("Circle", typeof(Circle));
            Shape.RegisterShape("Line", typeof(Line));

            //Audio System
            SwinGame.OpenAudio();

            Drawing Draw = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;
            
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();

            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                if(SwinGame.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if(SwinGame.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if(SwinGame.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;

                    if(kindToAdd == ShapeKind.Circle)
                    {
                        Circle newCircle = new Circle();                      
                        newShape = newCircle;
                    }
                    else if(kindToAdd == ShapeKind.Rectangle)
                    {
                        Rectangle newRect = new Rectangle();                      
                        newShape = newRect;
                    }
                    else
                    {
                        Line newLine = new Line();
                        newShape = newLine;
                    }
                    newShape.X = SwinGame.MouseX();
                    newShape.Y = SwinGame.MouseY();
                    Draw.AddShape(newShape);
                }

                if (SwinGame.KeyTyped(KeyCode.SpaceKey))
                {
                    Draw.Background = SwinGame.RandomRGBColor(255);
                }

                if (SwinGame.MouseClicked(MouseButton.RightButton))
                {
                    Point2D pt = new Point2D();

                    pt.X = SwinGame.MouseX();
                    pt.Y = SwinGame.MouseY();
                    Draw.SelectShapesAt(pt);
                }
                
                if(SwinGame.KeyTyped(KeyCode.DeleteKey) || SwinGame.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach(Shape s in Draw.SelectedShapes)
                    {
                        Draw.RemoveShape(s);
                    }
                }

                if(SwinGame.KeyTyped(KeyCode.SKey))
                {
                    Draw.Save("C:/Users/Brian/Documents/TestDrawing.txt");
                }

                if(SwinGame.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        Draw.Load("C:/Users/Brian/Documents/TestDrawing.txt");
                    }
                    catch(Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0, 0);
                Draw.Draw();
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}