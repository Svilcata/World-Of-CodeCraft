using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.Controls
{
    public abstract class Control
    {
        #region Field
        protected string name;
        protected string text;
        protected Vector2 size;
        protected Vector2 position;
        protected object value;
        protected bool hasFocus;
        protected bool enabled;
        protected bool visible;
        protected bool tabStop;
        protected SpriteFont spriteFont;
        protected Color color;
        protected string type;
        #endregion

        #region Event

        public event EventHandler Selected;

        #endregion

        #region Property
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public Vector2 Size
        {
            get { return size; }
            set { size = value; }
        }
        public Vector2 Position
        {
            get { return position; }
            set
            {
                position = value;
                position.Y = (int)position.Y;
            }
        }
        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public bool HasFocus
        {
            get { return hasFocus; }
            set { hasFocus = value; }
        }
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
        public bool TabStop
        {
            get { return tabStop; }
            set { tabStop = value; }
        }
        public SpriteFont SpriteFont
        {
            get { return spriteFont; }
            set { spriteFont = value; }
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        #endregion

        #region Constructor

        public Control()
        {
            Color = Color.White;
            Enabled = true;
            Visible = true;
            SpriteFont = ControlManager.SpriteFont;
        }

        #endregion

        //for controls (Controls have a name,a text,a position also a size and etc.)
        #region AbstractMethods
        //allows the control to be updated
        public abstract void Update(GameTime gameTime);
        //allows the control to be drawn
        public abstract void Draw(SpriteBatch spriteBatch);
        //used to handle the input for the control
        public abstract void HandleInput(PlayerIndex playerIndex);
        #endregion

        #region VirutalMethods

        protected virtual void OnSelected(EventArgs e)
        {
            if(Selected != null)
            {
                Selected(this, e);
            }
        }
        #endregion
    }
}
