using System.Drawing.Drawing2D;

namespace GymMSWF
{
    internal class DonutChart : Control
    {
        private float _fraction;

        public DonutChart()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.FromArgb(47, 61, 71);
        }

        public Color Accent { get; set; } = Color.Teal;

        public float Fraction
        {
            get => _fraction;
            set
            {
                _fraction = Math.Clamp(value, 0f, 1f);
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int pad = 10;
            var rect = new Rectangle(pad, pad, Math.Max(1, Width - pad * 2 - 1), Math.Max(1, Height - pad * 2 - 1));
            using var track = new Pen(Color.FromArgb(86, 104, 116), 12);
            using var arc = new Pen(Accent, 12)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round
            };

            e.Graphics.DrawArc(track, rect, 0, 359.9f);
            if (Fraction > 0.01f)
            {
                float sweep = Math.Min(359.9f, 360f * Fraction);
                e.Graphics.DrawArc(arc, rect, -90, sweep);
            }
        }
    }
}
