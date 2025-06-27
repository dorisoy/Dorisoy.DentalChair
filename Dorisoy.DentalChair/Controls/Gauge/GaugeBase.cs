using Microsoft.Maui.Graphics;

namespace Dorisoy.DentalChair.Controls
{
    /// <summary>
    /// 表示一个基本仪表
    /// </summary>
    internal abstract class GaugeBase : IDrawable
    {
        /// <summary>
        /// 仪表最小值
        /// </summary>
        public double GaugeMinimum { get; set; }
        /// <summary>
        /// 仪表最大值
        /// </summary>
        public double GaugeMaximum { get; set; }
        /// <summary>
        /// 仪表当前值
        /// </summary>
        public double GaugeValue { get; set; }

        public double Width { get; set; }
        public double Height { get; set; }
        public float GaugeStrokeSize { get; set; }
        public string GaugeUnit { get; set; }
        public string CountdownLabel { get; set; }

        protected double ConstrainedValue => (GaugeValue < GaugeMinimum) ? GaugeMinimum : (GaugeValue > GaugeMaximum) ? GaugeMaximum : GaugeValue;
        public Color GaugeColor { get; set; }
        public Color LabelColor { get; set; }
        public Color BackgroundColor { get; set; }
        public bool IsLabelShown { get; set; }
        public int LabelSize { get; set; }

        public double AnimatedStart { get; set; }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            InternalDraw(canvas, dirtyRect);
        }

        /// <summary>
        /// 获取总秒数
        /// </summary>
        /// <returns></returns>
        public int TotalSeconds() => Minutes * 60 + Seconds;
        /// <summary>
        /// 分钟
        /// </summary>
        public int Minutes { get; set; }
        /// <summary>
        /// 秒数
        /// </summary>
        public int Seconds { get; set; }
        /// <summary>
        /// 倒计时
        /// </summary>
        public DateTime Countdown { get; set; }
        /// <summary>
        /// 剩余时间
        /// </summary>
        public string RemainingTime { get; set; }

        /*
        属性：

        X：矩形左上角的X坐标。
        Y：矩形左上角的Y坐标。
        Width：矩形的宽度。
        Height：矩形的高度。

        Left、Top、Right、Bottom：分别表示矩形的各个边的坐标。

        方法：

        Contains(float x,float y)：检查一个点是否在矩形内。
        Intersects(RectF rect)：检查是否与另一个矩形相交。
        Inflate(float width,float height)：扩大或缩小矩形的尺寸。
        Offset(float dx,float dy)：按照指定偏移量移动矩形。
         */

        /// <summary>
        /// 内部绘图
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="dirtyRect">表示一个二维的矩形区域</param>
        protected abstract void InternalDraw(ICanvas canvas, RectF dirtyRect);


        #region  粒子效果


        protected List<Particle> particles = new();

        /// <summary>
        /// 根据当前进度添加新粒子
        /// </summary>
        protected abstract void UpdateParticles(double cx, double cy);

        /// <summary>
        /// 绘制粒子
        /// </summary>
        protected abstract void DrawParticles(ICanvas canvas);

        /// <summary>
        /// 粒子结构
        /// </summary>
        internal class Particle
        {
            public Point Position { get; set; }
            public double Opacity { get; set; }
            public double Size { get; set; }
            public Point Velocity { get; set; }
            public Color Color { get; set; }
        }

        #endregion
    }
}
