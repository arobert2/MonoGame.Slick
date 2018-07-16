using SlickEngine.UI.UIInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.UI
{
    public class UIObjectFactory
    {
        public static UITextures DefaultTextures { get; set; }

        public UIObjectFactory(UITextures defaulttextures)
        {
            DefaultTextures = defaulttextures;
        }

        public UIObjectFactory()
        {
        }

        public IUIObject Generate(Type t, int height, int width)
        {
            if(t == typeof(Panel))
            {
                return GeneratePanel(height, width);
            }

            if(t == typeof(Button))
            {
                return GenerateButton(height, width);
            }

            if(t == typeof(Window))
            {
                return GenerateWindow(height, width);
            }

            throw new UIGenerationException("Invalid object type.");
        }

        private Panel GeneratePanel(int height, int width)
        {
            var panel = new Panel(height, width);
            panel.Texture = DefaultTextures.PanelBackground;
            return panel;
        }

        private Button GenerateButton(int height, int width)
        {
            var button = new Button(height, width);
            button.TextureClick = DefaultTextures.ButtonClick;
            button.TextureUnClick = DefaultTextures.Button;
            return button;
        }

        private Window GenerateWindow(int height, int width)
        {
            var toolbar = GenerateWindowBar(20, width);
            var Window = new Window(height, width);
            Window.Texture = DefaultTextures.PanelBackground;
            Window.AddChild(toolbar, 0, 0);
            return Window;
        }

        private WindowBar GenerateWindowBar(int height, int width)
        {
            var toolbar = new WindowBar(height, width);
            toolbar.Texture = DefaultTextures.Toolbar;
            toolbar.Font = DefaultTextures.ToolbarFont;

            //Close button
            var xbutton = GenerateButton(height - 5, height - 5);
            xbutton.TextureClick = DefaultTextures.ToolbarCloseButtonClicked;
            xbutton.TextureUnClick = DefaultTextures.ToolbarCloseButton;
            xbutton.ClickUp += (o, args) =>
            {
                var Window = xbutton.Parent.Parent;
                Window.Parent.RemoveChild(Window);
            };

            //Icon
            var icon = GeneratePanel(height - 5, height - 5);
            icon.Texture = DefaultTextures.ToolbarIcon;
            icon.X = 5;
            icon.Y = 5;

            // TODO: Add drop down menu to icon.

            toolbar.AddChild(xbutton, width - height, 5);
            toolbar.AddChild(icon, 5, 5);

            return toolbar;
        }
    }

    public class UIGenerationException : Exception
    {
        public UIGenerationException() : base()
        {

        }

        public UIGenerationException(string message) : base(message)
        {

        }
    }
}
