using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Slick.ECS;
using System;
using System.Collections.Generic;

namespace Monogame.Slick
{
    public class Camera
    {
        /// <summary>
        /// X Center of Camera
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y Center of Camera
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// XSize of Camera
        /// </summary>
        public int CameraSizeX { get; set; }
        /// <summary>
        /// YSize of Camera
        /// </summary>
        public int CameraSizeY { get; set; }
        /// <summary>
        /// Displayed GameWorld
        /// </summary>
        public GameMap GameWorld { get; set; }
        /// <summary>
        /// Zoom level, uses a float 1 represents 100%
        /// </summary>
        public float Zoom {
            get { return _zoom; }
            set {
                if (value < MinimumZoom)
                {
                    _zoom = MinimumZoom;
                }
                else if (value > MaximumZoom)
                {
                    _zoom = MaximumZoom;
                }
                else
                {
                    _zoom = value;
                }
            }
        }
        private float _zoom = 1f;
        public float MinimumZoom { get; set; } = .25f;
        public float MaximumZoom { get; set; } = 3f;

        public void Draw(ref SpriteBatch spriteBatch)
        {
            //TODO: Draw Background with scroll here.

            var entities = GetVIsibleIDrawableEntity();
            foreach(var e in entities)
            {
                var ct = ToCT(e);
                ct = TranslateToCenter(ct);
                ct = TranslateZoom(ct);
                ct = TranslateToDrawScreen(ct);
                var spritesheet = e.Sprite.AnimatedSprite.SpriteSheet;
                var currentframe = e.Sprite.AnimatedSprite.SpriteMask[e.Sprite.AnimatedSprite.CurrentFrame];
                spriteBatch.Draw(e.Sprite.AnimatedSprite.SpriteSheet, new Rectangle(ct.LocationTranslation, ct.SizeTranslation), currentframe, Color.White);
                
            }
        }

        /// <summary>
        /// Get all visible IEntities
        /// </summary>
        /// <returns>List of visible entities</returns>
        private List<IDrawableEntity> GetVIsibleIDrawableEntity()
        {
            var visible = new List<IDrawableEntity>();

            foreach(var ie in GameWorld.MapEntities)
            {
                if ((ie.X + ie.Width / 2 > X - CameraSizeX / 2 && ie.X - ie.Width / 2 < CameraSizeX / 2) && 
                    (ie.Y + ie.Height / 2 > Y - CameraSizeY / 2 && ie.Y - ie.Height / 2 < Y - CameraSizeY / 2))
                    visible.Add(ie);
            }

            return visible;
        }
        /// <summary>
        /// Translate a CameraTranslation to the difference of the camera center
        /// </summary>
        /// <param name="ct">CameraTranslation you want to change</param>
        /// <returns>New CameraTranslation</returns>
        private CameraTranslation TranslateToCenter(CameraTranslation ct)
        {
            var translate = new Point(ct.LocationTranslation.X - X, ct.LocationTranslation.Y - Y);
            var newct = new CameraTranslation()
            {
                LocationTranslation = translate,
                SizeTranslation = ct.SizeTranslation
            };
            return newct;
        }
        /// <summary>
        /// Translates a CameraTranslation to the Zoom
        /// </summary>
        /// <param name="ct">CameraTranslation you wish to change</param>
        /// <returns>new CameraTranslation</returns>
        private CameraTranslation TranslateZoom(CameraTranslation ct)
        {
            var transloc = new Point((int)(ct.LocationTranslation.X * Zoom), (int)(ct.LocationTranslation.Y * Zoom));
            var transsize = new Point((int)(ct.SizeTranslation.X * Zoom), (int)(ct.SizeTranslation.Y * Zoom));
            var newct = new CameraTranslation()
            {
                LocationTranslation = transloc,
                SizeTranslation = transsize
            };
            return newct;            
        }
        /// <summary>
        /// Create CameraTranslation for an IDrawableEntity
        /// </summary>
        /// <param name="entity">IDrawableEntity to create CamereTranslation from</param>
        /// <returns>new CameraTranslation</returns>
        private CameraTranslation ToCT(IDrawableEntity entity)
        {
            var ct = new CameraTranslation
            {
                LocationTranslation = new Point(entity.X, entity.Y),
                SizeTranslation = new Point(entity.Width, entity.Height)

            };
            return ct;
        }
        /// <summary>
        /// Translate CameraTranslation to Draw screen
        /// </summary>
        /// <param name="ct">CameraTranslation to translate</param>
        /// <returns>new CameraTranslation</returns>
        private CameraTranslation TranslateToDrawScreen(CameraTranslation ct)
        {
            var transloc = new Point(ct.LocationTranslation.X + CameraSizeX / 2, ct.LocationTranslation.Y + CameraSizeY / 2);
            var newct = new CameraTranslation()
            {
                LocationTranslation = transloc,
                SizeTranslation = ct.SizeTranslation
            };
            return newct;
        }

        private struct CameraTranslation
        {
            public Point LocationTranslation { get; set; }
            public Point SizeTranslation { get; set; }
        }
    }
}
