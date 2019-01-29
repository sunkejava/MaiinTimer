﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using LayeredSkin.DirectUI;
using System.Windows.Forms;

namespace MaiinTimer.Utils
{
    /// <summary>
    /// DuiBaseControl动画类
    /// </summary>
    public static class AnimationDuiBaseControl
    {
        private static readonly int MoveStep = 25;
        private static Timer tmrAnim = null;
        private static DuiBaseControl control = null;
        private static AnchorStyles direction = AnchorStyles.None;
        private static Size destSize;

        private static void InitTimer()
        {
            if (tmrAnim == null)
            {
                tmrAnim = new Timer();
                tmrAnim.Interval = 25;
                tmrAnim.Tick += new System.EventHandler(tmrAnim_Tick);
            }
        }

        private static void tmrAnim_Tick(object sender, System.EventArgs e)
        {
            int newValue = 0;
            int offSet = 0;
            switch (direction)
            {
                case AnchorStyles.Left:
                case AnchorStyles.Right:
                    newValue = control.Width + MoveStep;
                    if (newValue > destSize.Width)
                    {
                        tmrAnim.Stop();
                        newValue = destSize.Width;
                    }

                    offSet = newValue - control.Width;
                    control.Width += offSet;
                    if (direction == AnchorStyles.Left)
                        control.Left -= offSet;
                    break;
                case AnchorStyles.Top:
                case AnchorStyles.Bottom:
                    newValue = control.Height + MoveStep;
                    if (newValue > destSize.Height)
                    {
                        tmrAnim.Stop();
                        newValue = destSize.Height;
                    }

                    offSet = newValue - control.Height;
                    control.Height += offSet;
                    if (direction == AnchorStyles.Top)
                        control.Top -= offSet;
                    break;
            }
        }

        public static void ShowControl(DuiBaseControl control, bool visible, AnchorStyles direction = AnchorStyles.None)
        {
            if (direction == AnchorStyles.None)
            {
                control.Visible = visible;
                return;
            }

            if (!visible)
            {
                if (tmrAnim != null)
                    tmrAnim.Stop();
                control.Visible = false;
            }
            else
            {
                InitTimer();

                if (AnimationDuiBaseControl.control != control && destSize.IsEmpty)
                {
                    destSize = new Size(control.Width, control.Height);
                }
                AnimationDuiBaseControl.control = control;
                AnimationDuiBaseControl.direction = direction;
                switch (direction)
                {
                    case AnchorStyles.Left:
                    case AnchorStyles.Right:
                        if (direction == AnchorStyles.Left)
                            control.Left += control.Width;
                        control.Width = 0;
                        break;
                    case AnchorStyles.Top:
                    case AnchorStyles.Bottom:
                        if (direction == AnchorStyles.Top)
                            control.Top += control.Height;
                        control.Height = 0;
                        break;
                }
                control.Visible = true;
                tmrAnim.Start();
            }
        }
    }
}
