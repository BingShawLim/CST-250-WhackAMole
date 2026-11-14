/*
 * Bing Shaw Lim
 * CST-250
 * 11/14/2026
 * Whack-A-Mole
 * Activity 5
 * Resources: CST-250 Activity 5 Guide (Grand Canyon University, 2025)
 */

using System.Drawing.Drawing2D;

namespace WhackAMole.PresentationLayer
{
    /// <summary>
    /// Custom graphics for the game, drawn in code with GDI+ so no image files are needed:
    /// the mole target, the bomb decoy, and the grass background.
    /// </summary>
    internal static class GameGraphics
    {
        /// <summary>
        /// Draw a cartoon mole popping out of a dirt mound
        /// </summary>
        /// <param name="size">Width and height of the image in pixels</param>
        /// <returns>A transparent bitmap of the mole</returns>
        public static Bitmap CreateMoleImage(int size)
        {
            Bitmap bitmap = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                float s = size;
                // Body and belly
                using (SolidBrush body = new SolidBrush(Color.FromArgb(139, 90, 43)))
                using (SolidBrush belly = new SolidBrush(Color.FromArgb(196, 145, 92)))
                {
                    g.FillEllipse(body, s * 0.16f, s * 0.10f, s * 0.68f, s * 0.86f);
                    g.FillEllipse(belly, s * 0.30f, s * 0.48f, s * 0.40f, s * 0.40f);
                }
                // Eyes with white shine
                using (SolidBrush black = new SolidBrush(Color.Black))
                using (SolidBrush white = new SolidBrush(Color.White))
                {
                    g.FillEllipse(black, s * 0.33f, s * 0.30f, s * 0.11f, s * 0.11f);
                    g.FillEllipse(black, s * 0.56f, s * 0.30f, s * 0.11f, s * 0.11f);
                    g.FillEllipse(white, s * 0.36f, s * 0.32f, s * 0.04f, s * 0.04f);
                    g.FillEllipse(white, s * 0.59f, s * 0.32f, s * 0.04f, s * 0.04f);
                }
                // Nose, teeth, and whiskers
                using (SolidBrush pink = new SolidBrush(Color.FromArgb(240, 128, 150)))
                using (SolidBrush teeth = new SolidBrush(Color.Ivory))
                using (Pen whisker = new Pen(Color.FromArgb(70, 40, 20), Math.Max(1f, s / 60f)))
                {
                    g.FillEllipse(pink, s * 0.42f, s * 0.42f, s * 0.16f, s * 0.11f);
                    g.FillRectangle(teeth, s * 0.455f, s * 0.53f, s * 0.04f, s * 0.07f);
                    g.FillRectangle(teeth, s * 0.505f, s * 0.53f, s * 0.04f, s * 0.07f);
                    g.DrawLine(whisker, s * 0.40f, s * 0.48f, s * 0.22f, s * 0.44f);
                    g.DrawLine(whisker, s * 0.40f, s * 0.50f, s * 0.22f, s * 0.52f);
                    g.DrawLine(whisker, s * 0.60f, s * 0.48f, s * 0.78f, s * 0.44f);
                    g.DrawLine(whisker, s * 0.60f, s * 0.50f, s * 0.78f, s * 0.52f);
                }
                // Dirt mound in front of the mole
                using (SolidBrush dirt = new SolidBrush(Color.FromArgb(101, 67, 33)))
                using (SolidBrush dirtTop = new SolidBrush(Color.FromArgb(125, 85, 45)))
                {
                    g.FillEllipse(dirt, s * 0.02f, s * 0.74f, s * 0.96f, s * 0.26f);
                    g.FillEllipse(dirtTop, s * 0.12f, s * 0.76f, s * 0.76f, s * 0.12f);
                }
            }
            return bitmap;
        } // End of CreateMoleImage method

        /// <summary>
        /// Draw a cartoon bomb with a lit fuse for the decoy
        /// </summary>
        /// <param name="size">Width and height of the image in pixels</param>
        /// <returns>A transparent bitmap of the bomb</returns>
        public static Bitmap CreateBombImage(int size)
        {
            Bitmap bitmap = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                float s = size;
                using (SolidBrush black = new SolidBrush(Color.FromArgb(30, 30, 30)))
                using (SolidBrush shine = new SolidBrush(Color.FromArgb(110, 110, 110)))
                using (SolidBrush cap = new SolidBrush(Color.FromArgb(80, 80, 80)))
                using (Pen fuse = new Pen(Color.FromArgb(150, 110, 60), Math.Max(2f, s / 25f)))
                using (SolidBrush sparkOuter = new SolidBrush(Color.Orange))
                using (SolidBrush sparkInner = new SolidBrush(Color.Yellow))
                {
                    g.FillEllipse(black, s * 0.14f, s * 0.24f, s * 0.70f, s * 0.70f);
                    g.FillEllipse(shine, s * 0.28f, s * 0.36f, s * 0.14f, s * 0.10f);
                    g.FillRectangle(cap, s * 0.42f, s * 0.18f, s * 0.16f, s * 0.10f);
                    g.DrawBezier(fuse, s * 0.50f, s * 0.18f, s * 0.55f, s * 0.04f, s * 0.70f, s * 0.12f, s * 0.76f, s * 0.08f);
                    g.FillEllipse(sparkOuter, s * 0.68f, s * 0.00f, s * 0.16f, s * 0.16f);
                    g.FillEllipse(sparkInner, s * 0.72f, s * 0.04f, s * 0.08f, s * 0.08f);
                }
            }
            return bitmap;
        } // End of CreateBombImage method

        /// <summary>
        /// Draw one tile of grass that repeats across the form background
        /// </summary>
        /// <returns>A 64 x 64 grass tile</returns>
        public static Bitmap CreateGrassTile()
        {
            const int TileSize = 64;
            Bitmap bitmap = new Bitmap(TileSize, TileSize);
            // A fixed seed draws the same tile every time so the tiles line up
            Random random = new Random(250);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.FromArgb(96, 160, 64));
                for (int i = 0; i < 60; i++)
                {
                    int x = random.Next(0, TileSize);
                    int y = random.Next(0, TileSize);
                    int shade = random.Next(-30, 30);
                    using (Pen blade = new Pen(Color.FromArgb(70 + shade / 2, 140 + shade, 50 + shade / 2)))
                    {
                        g.DrawLine(blade, x, y, x + random.Next(-2, 3), y - random.Next(3, 7));
                    }
                }
            }
            return bitmap;
        } // End of CreateGrassTile method
    }
}
