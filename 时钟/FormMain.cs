﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 时钟
{
    public partial class FormMain : Form
    {
        private BufferedGraphics bGrp;//新建图形的双缓冲区
        public FormMain()
        {
            InitializeComponent();
        }
        private void tmControl_Tick(object sender, EventArgs e)
        {
            lalTime.Text = DateTime.Now.ToLongTimeString().ToString();

            Graphics grp = bGrp.Graphics;//将Graphics输入到缓冲区

            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//获得高质量的的绘图面板，使图像更加清晰
            grp.Clear(this.panDrawTimer.BackColor);
            //画时钟中心圆点
            PointF centerPoint = new PointF();
            centerPoint.X = this.panDrawTimer.Width / 2f;
            centerPoint.Y = this.panDrawTimer.Height / 2f;
            
            float smallRadius = 10f;
            RectangleF smallRect = new RectangleF();
            smallRect.X = (float)(centerPoint.X - smallRadius);
            smallRect.Y = (float)(centerPoint.Y - smallRadius);
            smallRect.Width = smallRect.Height = 2*smallRadius;
            grp.FillEllipse(Brushes.Red,smallRect);


            //画表盘
            //float largerRadius = (this.panDrawTimer.Width >= this.panDrawTimer.Height)?
              //                    this.panDrawTimer.Height / 2f:
               //                  this.panDrawTimer.Width / 2f;
            float largerRadius = 0f;
            if (this.panDrawTimer.Width >= this.panDrawTimer.Height)
                largerRadius = this.panDrawTimer.Height / 2f;
            else
                largerRadius = this.panDrawTimer.Width / 2f;
            
            largerRadius -= 10f;

            RectangleF largerRect = new RectangleF();
            largerRect.X = (float)(centerPoint.X - largerRadius);
            largerRect.Y = (float)(centerPoint.Y - largerRadius);
            largerRect.Width = largerRect.Height = 2 * largerRadius;

            Pen pen = new Pen(Color.Black);
            grp.DrawEllipse(pen,largerRect);

            //为时钟添加背景图片
            Image image = Image.FromFile("aa.jpg");
            Brush brush = new TextureBrush(image);
            grp.FillEllipse(brush,largerRect);

            //在表盘上画时针刻度
            Pen penSmall = new Pen(Color.Blue);
            float hAnglePer = (float)(2 * Math.PI / 12);

            for (int index = 0; index < 12; index++)
            {
                PointF startPoint = new PointF();
                startPoint.X = (float)(centerPoint.X + largerRadius * 0.95f * Math.Cos(hAnglePer * index));
                startPoint.Y = (float)(centerPoint.Y + largerRadius * 0.95f * Math.Sin(hAnglePer * index));
                PointF endPoint = new PointF();
                endPoint.X = (float)(centerPoint.X + largerRadius * Math.Cos(hAnglePer * index));
                endPoint.Y = (float)(centerPoint.Y + largerRadius * Math.Sin(hAnglePer * index));

                grp.DrawLine(penSmall,startPoint,endPoint);
            }

            //画分针刻度
            float mAnglePer = (float)(2*Math.PI / 60);
            Pen penLarger = new Pen(Color.Green);
            for (int index = 0; index < 60; index++)
			{
                PointF startPoint = new PointF();
                startPoint.X = centerPoint.X + (float)(largerRadius * 0.97f * Math.Cos(mAnglePer * index));
                startPoint.Y = centerPoint.Y + (float)(largerRadius * 0.97f * Math.Sin(mAnglePer * index));

                PointF endPoint = new PointF();
                endPoint.X = centerPoint.X + (float)(largerRadius * Math.Cos(mAnglePer * index));
                endPoint.Y = centerPoint.Y + (float)(largerRadius * Math.Sin(mAnglePer * index));
                grp.DrawLine(penLarger,startPoint,endPoint);
            }

            //在表盘上画指针
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;

            float hAngle = (float)(2 * Math.PI / 12 * hour + 2 * Math.PI / 12 * minute / 60 +2 * Math.PI / 12 * second / (60 * 60));
            float mAngle = (float)(2 * Math.PI / 60 * minute + 2 * Math.PI / 60 * minute / 60);
            float sAngle = (float)(2 * Math.PI / 60 * second);

            PointF pointArrow = new PointF();
            pointArrow.X = (float)(centerPoint.X + largerRadius * 0.6f * Math.Cos(hAngle));
            pointArrow.Y = (float)(centerPoint.Y + largerRadius * 0.6f * Math.Sin(hAngle));

            Pen penArrow = new Pen(Color.Red);
            penArrow.Width = 5f;
            grp.DrawLine(penArrow, centerPoint,pointArrow);


            pointArrow = new PointF();
            pointArrow.X = centerPoint.X + (float)(largerRadius * 0.75f * Math.Cos(mAngle));
            pointArrow.Y = centerPoint.Y + (float)(largerRadius * 0.75f * Math.Sin(mAngle));

            penArrow = new Pen(Color.LightBlue);
            penArrow.Width = 2f;
            grp.DrawLine(penArrow, centerPoint, pointArrow);


            pointArrow = new PointF();
            pointArrow.X = centerPoint.X + (float)(largerRadius * 0.85f * Math.Cos(sAngle));
            pointArrow.Y = centerPoint.Y + (float)(largerRadius * 0.85f * Math.Sin(sAngle));

            penArrow = new Pen(Color.Pink);
            grp.DrawLine(penArrow, centerPoint, pointArrow);

            this.bGrp.Render();//输出缓冲区的内容
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Graphics grp = this.panDrawTimer.CreateGraphics();
            this.bGrp = BufferedGraphicsManager.Current.Allocate(grp,this.panDrawTimer.ClientRectangle);

        }

        private void panDrawTimer_SizeChanged(object sender, EventArgs e)
        {
            Graphics grp = this.panDrawTimer.CreateGraphics();
            this.bGrp = BufferedGraphicsManager.Current.Allocate(grp, this.panDrawTimer.ClientRectangle);
        }
    }
}
