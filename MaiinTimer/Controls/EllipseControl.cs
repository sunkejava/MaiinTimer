/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：CDecline
*命名空间：MaiinTimer.Controls
*文件名：  EllipseControl
*版本号：  V1.0.0.0
*唯一标识：6dd491a5-c9f2-4ea1-83ec-e1b1fef379fa
*当前的用户域：CDecline
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/2/18 13:19:50
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/2/18 13:19:50
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using LayeredSkin.DirectUI;

namespace MaiinTimer.Controls
{
    /// <summary>
    /// 根据三点画圆
    /// SK  2018-02-14
    /// </summary>
    public partial class EllipseControl : DuiBaseControl
    {
        private Point leftPotion = new Point(0, 0);
        private Point rightPotion = new Point(0, 0);
        private Point centerPotion = new Point(0, 0);
        private bool isShowPotion = false;
        private string strValue = "我是有底线的";
        public EllipseControl()
        {
            
        }

        [Description("左边点位置"), Category("自定义属性")]
        public Point LeftPotion
        {
            get
            {
                return leftPotion;
            }

            set
            {
                leftPotion = value;
            }
        }
        [Description("右边点位置"), Category("自定义属性")]
        public Point RightPotion
        {
            get
            {
                return rightPotion;
            }

            set
            {
                rightPotion = value;
            }
        }
        [Description("中间点位置"), Category("自定义属性")]
        public Point CenterPotion
        {
            get
            {
                return centerPotion;
            }

            set
            {
                centerPotion = value;
            }
        }
        [Description("是否显示位置点"), Category("自定义属性")]
        public bool IsShowPotion
        {
            get
            {
                return isShowPotion;
            }

            set
            {
                isShowPotion = value;
            }
        }
        [Description("提示内容"), Category("自定义属性")]
        public string StrValue
        {
            get { return strValue; }
            set { strValue = value; }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            leftPotion = new Point(0, this.Height);
            rightPotion = new Point(this.Width, this.Height);
            centerPotion = new Point(this.Width / 2, 5);
            //base.Refresh();
        }
        protected override void OnPaint(PaintEventArgs ce)
        {
            int x1, y1, x2, y2, x3, y3;
            x1 = leftPotion.X;
            y1 = leftPotion.Y;
            x2 = rightPotion.X;
            y2 = rightPotion.Y;
            x3 = centerPotion.X;
            y3 = centerPotion.Y;
            Graphics mImgGraph = ce.Graphics;
            double a = x1 - x2;

            double b = y1 - y2;

            double c = x1 - x3;

            double d = y1 - y3;

            double e = ((x1 * x1 - x2 * x2) + (y1 * y1 - y2 * y2)) / 2.0;

            double f = ((x1 * x1 - x3 * x3) + (y1 * y1 - y3 * y3)) / 2.0;
            mImgGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            mImgGraph.SmoothingMode = SmoothingMode.HighQuality;
            if (isShowPotion)
            {
                mImgGraph.FillEllipse(new SolidBrush(Color.Red), x1, y1, 4, 4);
                mImgGraph.FillEllipse(new SolidBrush(Color.Red), x2, y2, 4, 4);
                mImgGraph.FillEllipse(new SolidBrush(Color.Red), x3, y3, 4, 4);
            }
            double det = b * c - a * d;
            if (Math.Abs(det) > 0.001)
            {

                //x0,y0为计算得到的原点

                double x0 = -(d * e - b * f) / det;

                double y0 = -(a * f - c * e) / det;



                SolidBrush OriginBrush = new SolidBrush(Color.Blue);

                mImgGraph.FillEllipse(OriginBrush, (int)(x0 - 3), (int)(y0 - 3), 6, 6);

                double radius = Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));



                double angle1;

                double angle2;

                double angle3;



                double sinValue1;

                double cosValue1;

                double sinValue2;

                double cosValue2;

                double sinValue3;

                double cosValue3;



                sinValue1 = (y1 - y0) / radius;

                cosValue1 = (x1 - x0) / radius;

                if (cosValue1 >= 0.99999) cosValue1 = 0.99999;

                if (cosValue1 <= -0.99999) cosValue1 = -0.99999;

                angle1 = Math.Acos(cosValue1);

                angle1 = angle1 / 3.14 * 180;

                if (sinValue1 < -0.05) angle1 = 360 - angle1;



                sinValue2 = (y2 - y0) / radius;

                cosValue2 = (x2 - x0) / radius;

                if (cosValue2 >= 0.99999) cosValue2 = 0.99999;

                if (cosValue2 <= -0.99999) cosValue2 = -0.99999;

                angle2 = Math.Acos(cosValue2);

                angle2 = angle2 / 3.14 * 180;

                if (sinValue2 < -0.05) angle2 = 360 - angle2;



                sinValue3 = (y3 - y0) / radius;

                cosValue3 = (x3 - x0) / radius;

                if (cosValue3 >= 0.99999) cosValue3 = 0.99999;

                if (cosValue3 <= -0.99999) cosValue3 = -0.99999;

                angle3 = Math.Acos(cosValue3);

                angle3 = angle3 / 3.14 * 180;

                if (sinValue3 < -0.05) angle3 = 360 - angle3;

                Pen CurvePen = new Pen(Color.FromArgb(125, 255, 92, 138), (int)radius / 2);

                double Delta13;

                if (angle1 < angle3)

                {

                    Delta13 = angle3 - angle1;

                }

                else Delta13 = angle3 - angle1 + 360;

                double Delta12;

                if (angle1 < angle2)

                {

                    Delta12 = angle2 - angle1;
                }
                else Delta12 = angle2 - angle1 + 360;
                mImgGraph.FillEllipse(new SolidBrush(Color.FromArgb(125, 255, 92, 138)), (int)(x0 - radius), (int)(y0 - radius), (int)(2 * radius), (int)(2 * radius));

                SizeF size = mImgGraph.MeasureString(strValue, new Font("黑体", 10F, System.Drawing.FontStyle.Bold));
                mImgGraph.DrawString(strValue, new Font("华文新魏", 10F, System.Drawing.FontStyle.Bold), new SolidBrush(Color.White), new Point(this.Width / 2 - (int)size.Width / 2 - 1, ((y1 - y3) / 2 + y3) - (int)size.Height / 2 + 2));
            }
        }
    }
}
