using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using Blotch;
using Entities;
using Entities.TwoD;
using System.Diagnostics;

namespace BlotchExample
{
	/// <summary>
	/// The 3D window. This must inherit from BlWindow3D. See BlWindow3D for details.
	/// </summary>
	public class Blotch3dGraphics : BlWindow3D
	{
		/// <summary>
		/// This will be the torus model we draw in the window
		/// </summary>
		private List<BlSprite> _spheres;
		private List<Ball<TwoDimensionVector>> _balls;
		private int _frameCount = 0;
		private double _step;
		private Stopwatch _timer = new Stopwatch();
		/// <summary>
		/// This will be the font for the help menu we draw in the window
		/// </summary>
		SpriteFont Font;

		public void Adapt(List<Ball<TwoDimensionVector>> balls)
        {
			_balls = balls;
			_frameCount++;
			if (_spheres != null)
				_spheres.ForEach(s=>s.Dispose());

			_spheres = new List<BlSprite>();

			var MyContent = new ContentManager(Services, "Content");

			// The model of the toroid
			var TorusModel = MyContent.Load<Model>("uv_sphere_192x96");

			foreach (var ball in balls)
            {
				if (ball.IsGone)
					continue;
				var sphere = new BlSprite(Graphics, "Torus");
				sphere.LODs.Add(TorusModel);
				sphere.Matrix = Matrix.CreateScale(1f * (float)ball.Radius);
				sphere.Matrix = Matrix.Multiply(sphere.Matrix, Matrix.CreateTranslation((float)ball.Position.X, (float)ball.Position.Y, 0f));				
				_spheres.Add(sphere);
            }
        }

        public void SetStep(double step)
        {
			_step = step;

		}

        /// <summary>
        /// See BlWindow3D for details.
        /// </summary>
        protected override void Setup()
		{
			// Any type of content (3D models, fonts, images, etc.) can be converted to an XNB file by downloading and
			// using the mgcb-editor (see Blotch3D.chm for details). XNB files are then normally added to the project
			// and loaded as shown here. 'Content', here, is the folder that contains the XNB files or subfolders with
			// XNB files. We need to create one ContentManager object for each top-level content folder we'll be loading
			// XNB files from. You can create multiple content managers if content is spread over diverse folders. Some
			// content can also be loaded in its native format using platform specific code (may not be portable) or
			// certain Blotch3D/Monogame methods, like BlGraphicsDeviceManager.LoadFromImageFile.
			var MyContent = new ContentManager(Services, "Content");

			// The font we will use to draw the menu on the screen.
			// "Arial14" is the pathname to the font file
			Font = MyContent.Load<SpriteFont>("arial14");


			Graphics.TargetEye = new Vector3(0, -1, 173);

			_timer.Start();

		}

		public Action AdaptDelegate { get; set; }


		/// <summary>
		/// See BlWindow3D for details.
		/// </summary>
		/// <param name="timeInfo">Provides a snapshot of timing values.</param>
		protected override void FrameDraw(GameTime timeInfo)
		{
			Stopwatch framesw = new Stopwatch();
			framesw.Start();
			// Handle the standard mouse and keystroke functions. (This is very configurable)
			Graphics.DoDefaultGui();
			Stopwatch logicsw = new Stopwatch();
			logicsw.Start();
			AdaptDelegate();
			logicsw.Stop();
			//
			// Draw things here using BlSprite.Draw(), graphics.DrawText(), etc.
			//
			if (_spheres != null)
			{
				_spheres.ForEach(s => s.Draw());				
			}

			framesw.Stop();

            #region
            try
            {
                var MyHud = $@"
Eye: {Graphics.Eye}
GoneBalls: {_balls.Count(c=>c.IsGone)}
Frame: {_frameCount}
Time, s: {_frameCount * _step}
Frametime: {framesw.ElapsedMilliseconds}
LogicFrametime: {logicsw.ElapsedMilliseconds}
Total time: {_timer.Elapsed}
fps: {_frameCount / _timer.Elapsed.TotalSeconds}
max v: 
{_balls.Max(m=>m.Velocity.X)} 
{_balls.Max(m => m.Velocity.Y)}
max f: 
{_balls.Max(m => m.Force.X)}
{_balls.Max(m => m.Force.Y)}
";

                Graphics.DrawText(MyHud, Font, new Vector2(50, 50));
            }
            catch { }
            #endregion
        }
    }
}