namespace Dorisoy.DentalChair.Controls
{
    /// <summary>
    /// 表示一个倒计时闹钟仪表盘
    /// </summary>
    internal class CurvedGauge : GaugeBase
    {
        private Random random = new();
        //private bool shouldDrawParticles = true;

        /*
        protected void InternalHelfDraw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeLineCap = LineCap.Round;
            canvas.StrokeSize = GaugeStrokeSize;

            canvas.StrokeColor = BackgroundColor;
            canvas.DrawArc(10, 10, 200, 200, 0, 180, false, false);

            double range = GaugeMaximum - GaugeMinimum;
            double angle = (ConstrainedValue - GaugeMinimum) / range * 180;

            canvas.StrokeColor = GaugeColor;
            canvas.DrawArc(10, 10, 200, 200, 180 - (float)angle, 180, false, false);

            if (IsLabelShown)
            {
                canvas.FontColor = LabelColor;
                canvas.FontSize = 36;

                var format = $"{ConstrainedValue} {GaugeUnit}";

                canvas.DrawString(format, 110, 100, HorizontalAlignment.Center);
            }
        }
        */

        /// <summary>
        /// 绘制进度条
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="dirtyRect"></param>
        protected override void InternalDraw(ICanvas canvas, RectF dirtyRect)
        {
            float strokeWidth = GaugeStrokeSize;

            canvas.StrokeLineCap = LineCap.Square;
            canvas.StrokeSize = strokeWidth;

            float padding = 5f;

            float centerX = dirtyRect.Center.X;
            float centerY = dirtyRect.Center.Y;

            float availableDiameter = Math.Min(dirtyRect.Width - padding, dirtyRect.Height - padding) - 2;

            float halfStroke = strokeWidth / 2;
            float radius = availableDiameter / 2;

            float x = centerX - radius + halfStroke;
            float y = centerY - radius + halfStroke;

            float w = availableDiameter - strokeWidth;
            float h = availableDiameter - strokeWidth;


            // 阴影的偏移值
            SizeF shadowOffset = new(1f, 1f);
            // 模糊半径
            float shadowBlur = 6f;
            // 半透明黑色
            Color shadowColor = new(0, 0, 0, 0.5f);
            // 在canvas上设置阴影
            canvas.SetShadow(shadowOffset, shadowBlur, shadowColor);

            // 背景色，从-90度（12点方向）绘制整个圆
            canvas.StrokeColor = BackgroundColor;
            canvas.DrawArc(x, y, w, h, 0, 359.999f, false, false);

            // 重置阴影以避免影响其他绘制
            canvas.SetShadow(new SizeF(0, 0), 0, new(0, 0, 0, 0));

            // 进度
            // double range = GaugeMaximum - GaugeMinimum;
            // double angle = (ConstrainedValue - GaugeMinimum) / range * 359.999f;
            // float start = 359.999f - (float)angle;

            // 使用 _gaugeView.animatedStart 而不是直接的角度
            float start = (float)AnimatedStart;
            // 通过绘制线条前景色
            canvas.StrokeColor = GaugeColor;
            canvas.StrokeSize = strokeWidth;
            canvas.DrawArc(x, y, w, h, start, 359.999f, false, false);

            // 起始位
            canvas.StrokeColor = Color.Parse("#000000");
            canvas.StrokeSize = 2;
            canvas.DrawLine(w + 5, centerY - 6, w + 18f, centerY - 6);

            if (IsLabelShown)
            {
                canvas.FontColor = LabelColor;
                canvas.FontSize = LabelSize;
                var format = $"{ConstrainedValue} {GaugeUnit}";
                canvas.DrawString(format, centerX, centerY, HorizontalAlignment.Center);
            }

            // 更新和绘制粒子
            if (start > 0)
            {
                UpdateParticles(centerX, centerY);
                DrawParticles(canvas);
            }
        }

        /// <summary>
        /// 通过路径和裁剪实现渐变弧线填充, 绘制一个封闭的路径,将封闭路径作为目标区域，并应用渐变
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="thickness"></param>
        public void DrawGradientArc(ICanvas canvas, 
            float x, 
            float y, 
            float width, 
            float height, 
            float startAngle, 
            float sweepAngle, 
            float thickness)
        { 
            // 定义径向渐变色刷
            var gradientPaint = new LinearGradientPaint
            {
                StartColor = GaugeColor,
                EndColor = BackgroundColor,
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1)
            };

            // 保存当前的绘图状态
            canvas.SaveState();

            // 创建一个路径用于弧线区域
            var path = new PathF();
            path.AddArc(x, y, width, height, startAngle, sweepAngle,false);

            // 将弧形路径转为封闭路径
            path.LineTo(x + width / 2, y + height / 2);
            path.Close();

            // 使用剪裁裁剪路径，限定渐变效果
            canvas.ClipPath(path);

            // 应用填充
            canvas.SetFillPaint(gradientPaint, new RectF(x, y, width, height));
            canvas.FillPath(path);

            // 恢复绘图状态
            canvas.RestoreState();
        }

        /// <summary>
        /// 粒子随机颜色
        /// </summary>
        private readonly Color[] particleColors = [Color.FromArgb("#5CCFEA"), Color.FromArgb("#F2E4D1"), Color.FromArgb("#9CE2F2")];

        /// <summary>
        /// 根据当前测量仪进度添加新粒子
        /// </summary>
        protected override void UpdateParticles(double cx, double cy)
        {
            float start = (float)AnimatedStart;
            // 让粒子在不再更新时慢慢隐藏而不是立即清除
            if (start < 300)
            {
                // 自定义粒子数
                for (int i = 0; i < 5; i++)
                {
                    particles.Add(new Particle
                    {
                        // 随机粒子位置
                        Position = new Point(cx + random.NextDouble() * 100 - 50, cy + random.NextDouble() * 100 - 50),

                        Opacity = 1.0,
                        Size = 4 + random.NextDouble() * 4,

                        Velocity = new Point(random.NextDouble() * 4 - 2, random.NextDouble() * 4 - 2),

                        // 自定义粒子颜色
                        Color = particleColors[random.Next(particleColors.Length)]
                    });
                }
            }

            // 更新现有粒子
            particles = particles.Where(p =>
            {
                p.Position = new Point(p.Position.X + p.Velocity.X, p.Position.Y + p.Velocity.Y);
                // 随着时间的推移逐渐消失
                p.Opacity -= 0.01;

                // 随着时间的推移而收缩
                p.Size *= 0.95;

                // 移除不可见的粒子
                return p.Opacity > 0;
            }).ToList();
        }

        /// <summary>
        /// 绘制粒子
        /// </summary>
        /// <param name="canvas"></param>
        protected override void DrawParticles(ICanvas canvas)
        {
            if (particles != null && particles.Any())
            {
                foreach (var particle in particles)
                {
                    canvas.Alpha = (float)particle.Opacity;
                    canvas.FillColor = particle.Color;
                    canvas.FillCircle((float)particle.Position.X, (float)particle.Position.Y, (float)particle.Size);
                }
            }

            // 重置alpha
            canvas.Alpha = 1.0f;
        }
    }
}
