using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace DeskNote
{
    public enum ArrangeModes : int
    {
        none,
        TopFromLeft,
        TopFromRight,
        RightFromTop,
        RightFromBottom,
        BottomFromRight,
        BottomFromLeft,
        LeftFromBottom,
        LeftFromTop
    }

    public class Displacer
    {
        public Rectangle PrevNoteRectangle;
        public DeskNote DeskNote;
        public Size Margin;
        public ArrangeModes Mode;
        public int FixedWidth;
        public int FixedHeight;

        private int MaxEdgeLength;
        private int LineOffset;
        private Rectangle ViewPort;

        public Displacer()
        {
            PrevNoteRectangle = new Rectangle();
            PrevNoteRectangle.Location = new Point();
            Margin = new Size(5, 5);
            MaxEdgeLength = 0;
            LineOffset = 0;
            Mode = ArrangeModes.TopFromLeft;
            FixedWidth = 0;
        }

        private bool IsInTheViewport(Rectangle rectangle)
        {
            return
                rectangle.X >= 0 &&
                rectangle.Y >= 0 &&
                rectangle.X + rectangle.Width <= ViewPort.Width &&
                rectangle.Y + rectangle.Height <= ViewPort.Height;
        }

        public void Displace(DeskNote deskNote = null, ArrangeModes mode = ArrangeModes.none, int fixedW = 0, int fixedH = 0)
        {
            deskNote.SaveForUndo();
            if (deskNote != null) DeskNote = deskNote;
            if (mode != ArrangeModes.none) Mode = mode;
            if (fixedW > 0) FixedWidth = fixedW;
            if (fixedH > 0) FixedHeight = fixedH;

            if (FixedWidth > 0 || FixedHeight > 0) Resize();
            ViewPort = Screen.FromControl(deskNote).WorkingArea;

            Rectangle newNoteRectangle = new Rectangle();
            newNoteRectangle = PrevNoteRectangle;
            newNoteRectangle.Size = deskNote.Size;

            newNoteRectangle = NextLocation(newNoteRectangle);

            if (!IsInTheViewport(newNoteRectangle))
            {
                newNoteRectangle = NextLine(newNoteRectangle);
            }
            PrevNoteRectangle = newNoteRectangle;
            deskNote.Location = newNoteRectangle.Location;
            UpdateMaxValue(newNoteRectangle);
        }

        private Rectangle NextLocation(Rectangle rectangle)
        {
            int X; 
            switch (Mode)
            {
                case ArrangeModes.TopFromLeft:
                case ArrangeModes.BottomFromLeft:
                    X = Margin.Width + PrevNoteRectangle.X + PrevNoteRectangle.Width;
                    break;
                case ArrangeModes.TopFromRight:
                case ArrangeModes.BottomFromRight:
                    X = (PrevNoteRectangle.X == 0 ? ViewPort.Width : PrevNoteRectangle.X) - rectangle.Width - Margin.Width;
                    break;
                case ArrangeModes.RightFromTop:
                case ArrangeModes.RightFromBottom:
                    X = PrevNoteRectangle.X == 0 ? ViewPort.Width - rectangle.Width - Margin.Width : PrevNoteRectangle.X + PrevNoteRectangle.Width - rectangle.Width;
                    break;
                default:
                    X = Margin.Width + LineOffset;
                    break;
            }
            int Y;
            switch (Mode)
            {
                case ArrangeModes.LeftFromTop:
                case ArrangeModes.RightFromTop:
                    Y = Margin.Height + PrevNoteRectangle.Y + PrevNoteRectangle.Height;
                    break;
                case ArrangeModes.LeftFromBottom:
                case ArrangeModes.RightFromBottom:
                    Y = (PrevNoteRectangle.Y == 0 ? ViewPort.Height : PrevNoteRectangle.Y) - rectangle.Height - Margin.Height;
                    break;
                case ArrangeModes.BottomFromLeft:
                case ArrangeModes.BottomFromRight:
                    Y = PrevNoteRectangle.Y == 0 ? ViewPort.Height - rectangle.Height - Margin.Height : PrevNoteRectangle.Y + PrevNoteRectangle.Height - rectangle.Height;
                    break;
                default:
                    Y = Margin.Height + LineOffset;
                    break;
            }

            return new Rectangle( new Point (X, Y), rectangle.Size);
        }

        private Rectangle NextLine(Rectangle rectangle)
        {
            LineOffset += MaxEdgeLength;
            MaxEdgeLength = 0;

            int X = rectangle.X;
            switch (Mode)
            {
                case ArrangeModes.TopFromLeft:
                case ArrangeModes.BottomFromLeft:
                    X = Margin.Width;
                    break;
                case ArrangeModes.TopFromRight:
                case ArrangeModes.BottomFromRight:
                    X = ViewPort.Width - rectangle.Width - Margin.Width;
                    break;
                case ArrangeModes.LeftFromTop:
                case ArrangeModes.LeftFromBottom:
                    X = Margin.Width + LineOffset;
                    break;
                case ArrangeModes.RightFromTop:
                case ArrangeModes.RightFromBottom:
                    X = ViewPort.Width - rectangle.Width - LineOffset - Margin.Width;
                    break;
            }
            int Y = rectangle.Y;
            switch (Mode)
            {
                case ArrangeModes.TopFromLeft:
                case ArrangeModes.TopFromRight:
                    Y = Margin.Height + LineOffset;
                    break;
                case ArrangeModes.BottomFromLeft:
                case ArrangeModes.BottomFromRight:
                    Y = ViewPort.Height - rectangle.Height - LineOffset - Margin.Height;
                    break;
                case ArrangeModes.LeftFromTop:
                case ArrangeModes.RightFromTop:
                    Y = Margin.Height;
                    break;
                case ArrangeModes.LeftFromBottom:
                case ArrangeModes.RightFromBottom:
                    Y = ViewPort.Height - rectangle.Height - Margin.Height;
                    break;
            }
            return new Rectangle(new Point(X, Y), rectangle.Size);
        }

        private void UpdateMaxValue(Rectangle rectangle)
        {
            switch (Mode)
            {
                case ArrangeModes.TopFromLeft:
                case ArrangeModes.TopFromRight:
                case ArrangeModes.BottomFromLeft:
                case ArrangeModes.BottomFromRight:
                    if (rectangle.Height > MaxEdgeLength) MaxEdgeLength = rectangle.Height + Margin.Height; 
                    break;
                default:
                    if (rectangle.Width > MaxEdgeLength) MaxEdgeLength = rectangle.Width + Margin.Width;
                    break;
            }
        }

        private void Resize ()
        {
            Size textsize = TextRenderer.MeasureText(DeskNote.NoteBox.Text, DeskNote.NoteBox.Font);
            int textarea = textsize.Width * textsize.Height;
            int notearea = DeskNote.Width * DeskNote.Height;
            switch (Mode)
            {
                case ArrangeModes.TopFromLeft:
                case ArrangeModes.TopFromRight:
                case ArrangeModes.BottomFromLeft:
                case ArrangeModes.BottomFromRight:
                    DeskNote.Height = FixedHeight;
                    int width = notearea < textarea ? (int)Math.Round(notearea / (double)FixedHeight) : (int)Math.Round(textarea / (double)FixedHeight);
                    DeskNote.Width = width > textsize.Width ? width : textsize.Width;
                    break;
                default:
                    int height = notearea < textarea ? (int)Math.Round(notearea / (double)FixedWidth) : DeskNote.TitleBar.Height * 4 + (int)Math.Round(textarea / (double)FixedWidth);
                    DeskNote.Height = height > textsize.Height ? height : textsize.Height;
                    DeskNote.Width = FixedWidth;
                    break;
            }
        }
    }
}
