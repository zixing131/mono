//
// ScrollableControlTest.cs: Test cases for ScrollableControl.
//
// Author:
//   Gert Driesen (drieseng@users.sourceforge.net)
//
// (C) 2006 Gert Driesen
//

using System;
using System.Drawing;
using System.Windows.Forms;

using NUnit.Framework;

namespace MonoTests.System.Windows.Forms
{
	[TestFixture]
	public class ScrollableControlTest : TestHelper
	{
		[Test]
		public void AutoScrollPositionTest ()
		{
			ScrollableControl sc;

			sc = new ScrollableControl ();
			sc.AutoScroll = true;
			
			sc.AutoScrollPosition = new Point (-25, -50);
			Assert.AreEqual (Point.Empty, sc.AutoScrollPosition, "#01");

			sc.AutoScrollPosition = new Point (2500, 5000);
			Assert.AreEqual (Point.Empty, sc.AutoScrollPosition, "#02");
			
			sc.AutoScrollPosition = new Point (25, 50);
			Assert.AreEqual (Point.Empty, sc.AutoScrollPosition, "#03");
			
			object o = sc.Handle;

			sc.AutoScrollPosition = new Point (-25, -50);
			Assert.AreEqual (Point.Empty, sc.AutoScrollPosition, "#04");

			sc.AutoScrollPosition = new Point (2500, 5000);
			Assert.AreEqual (Point.Empty, sc.AutoScrollPosition, "#05");

			sc.AutoScrollPosition = new Point (25, 50);
			Assert.AreEqual (Point.Empty, sc.AutoScrollPosition, "#06");
			
			sc.Size = new Size (200, 400);
			sc.Location = new Point (20, 40);

			sc.AutoScrollPosition = new Point (-25, -50);
			Assert.AreEqual (Point.Empty, sc.AutoScrollPosition, "#07");

			sc.AutoScrollPosition = new Point (2500, 5000);
			Assert.AreEqual (Point.Empty, sc.AutoScrollPosition, "#08");

			sc.AutoScrollPosition = new Point (25, 50);
			Assert.AreEqual (Point.Empty, sc.AutoScrollPosition, "#09");
			
			
			Control c1, c2;
			c1 = new Control ();
			c1.Location = new Point (-100, -200);
			c1.Size = new Size (10, 10);
			sc.Controls.Add (c1);

			c2 = new Control ();
			c2.Location = new Point (400, 800);
			c2.Size = new Size (10, 10);
			sc.Controls.Add (c2);

			Assert.AreEqual (new Rectangle (0, 0, 410, 810), sc.DisplayRectangle, "#10");
			
			sc.ScrollControlIntoView (c2);

			Assert.AreEqual (new Point (-226, -426), sc.AutoScrollPosition, "#11");
			Assert.AreEqual (new Rectangle (-226, -426, 410, 810), sc.DisplayRectangle, "#12");
			Assert.AreEqual (new Point (-326, -626), c1.Location, "#13");
			Assert.AreEqual (new Point (174, 374), c2.Location, "#14");
			
			sc.AutoScrollPosition = new Point (-25, -50);
			Assert.AreEqual (Point.Empty, sc.AutoScrollPosition, "#01");
			Assert.AreEqual (new Rectangle (0, 0, 410, 810), sc.DisplayRectangle, "#15");
			Assert.AreEqual (new Point (-100, -200), c1.Location, "#16");
			Assert.AreEqual (new Point (400, 800), c2.Location, "#17");

			sc.AutoScrollPosition = new Point (2500, 5000);
			Assert.AreEqual (new Point (-226, -426), sc.AutoScrollPosition, "#18");
			Assert.AreEqual (new Rectangle (-226, -426, 410, 810), sc.DisplayRectangle, "#19");
			Assert.AreEqual (new Point (-326, -626), c1.Location, "#20");
			Assert.AreEqual (new Point (174, 374), c2.Location, "#21");

			sc.AutoScrollPosition = new Point (25, 50);
			Assert.AreEqual (new Point (-25, -50), sc.AutoScrollPosition, "#22");
			Assert.AreEqual (new Rectangle (-25, -50, 410, 810), sc.DisplayRectangle, "#23");
			Assert.AreEqual (new Point (-125, -250), c1.Location, "#24");
			Assert.AreEqual (new Point (375, 750), c2.Location, "#25");
			
			sc.ScrollControlIntoView (c1);


			Assert.AreEqual (Point.Empty, sc.AutoScrollPosition, "#26");
			Assert.AreEqual (new Rectangle (0, 0, 410, 810), sc.DisplayRectangle, "#27");
			Assert.AreEqual (new Point (-100, -200), c1.Location, "#28");
			Assert.AreEqual (new Point (400, 800), c2.Location, "#29");

			sc.AutoScrollPosition = new Point (2500, 5000);
			Assert.AreEqual (new Point (-226, -426), sc.AutoScrollPosition, "#30");
			Assert.AreEqual (new Rectangle (-226, -426, 410, 810), sc.DisplayRectangle, "#31");
			Assert.AreEqual (new Point (-326, -626), c1.Location, "#32");
			Assert.AreEqual (new Point (174, 374), c2.Location, "#33");

			sc.AutoScrollPosition = new Point (25, 50);
			Assert.AreEqual (new Point (-25, -50), sc.AutoScrollPosition, "#34");
			Assert.AreEqual (new Rectangle (-25, -50, 410, 810), sc.DisplayRectangle, "#35");
			Assert.AreEqual (new Point (-125, -250), c1.Location, "#36");
			Assert.AreEqual (new Point (375, 750), c2.Location, "#37");
			
			sc.ScrollControlIntoView (c2);

			Assert.AreEqual (new Point (-226, -426), sc.AutoScrollPosition, "#38");
			Assert.AreEqual (new Rectangle (-226, -426, 410, 810), sc.DisplayRectangle, "#39");
			Assert.AreEqual (new Point (-326, -626), c1.Location, "#40");
			Assert.AreEqual (new Point (174, 374), c2.Location, "#41");

			sc.AutoScrollPosition = new Point (-25, -50);
			Assert.AreEqual (Point.Empty, sc.AutoScrollPosition, "#42");
			Assert.AreEqual (new Rectangle (0, 0, 410, 810), sc.DisplayRectangle, "#43");
			Assert.AreEqual (new Point (-100, -200), c1.Location, "#44");
			Assert.AreEqual (new Point (400, 800), c2.Location, "#45");

			sc.AutoScrollPosition = new Point (2500, 5000);
			Assert.AreEqual (new Point (-226, -426), sc.AutoScrollPosition, "#46");
			Assert.AreEqual (new Rectangle (-226, -426, 410, 810), sc.DisplayRectangle, "#47");
			Assert.AreEqual (new Point (-326, -626), c1.Location, "#48");
			Assert.AreEqual (new Point (174, 374), c2.Location, "#49");

			sc.AutoScrollPosition = new Point (25, 50);
			Assert.AreEqual (new Point (-25, -50), sc.AutoScrollPosition, "#50");
			Assert.AreEqual (new Rectangle (-25, -50, 410, 810), sc.DisplayRectangle, "#51");
			Assert.AreEqual (new Point (-125, -250), c1.Location, "#52");
			Assert.AreEqual (new Point (375, 750), c2.Location, "#53");
			
			
		}
		
		[Test]
		public void ResizeAnchoredTest ()
		{
			ScrollableControl sc = new ScrollableControl ();
			object h = sc.Handle;
			sc.Size = new Size (23, 45);
			Label lbl = new Label ();
			lbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			lbl.Size = sc.ClientSize;
			sc.Controls.Add (lbl);
			sc.Height *= 2;
			sc.Height *= 2;
			Assert.AreEqual (lbl.Location, Point.Empty, "#1");
			Assert.AreEqual (lbl.Size, sc.ClientSize, "#2");
			
			TestHelper.RemoveWarning (h);
		}
		[Test]
		public void AutoScroll ()
		{
			ScrollableControl sc = new ScrollableControl ();
			Assert.IsFalse (sc.AutoScroll, "#A1");
			Assert.AreEqual (0, sc.Controls.Count, "#A2");

			sc.AutoScroll = true;
			Assert.IsTrue(sc.AutoScroll, "#B1");
			Assert.AreEqual (0, sc.Controls.Count, "#B2");

			sc.AutoScroll = false;
			Assert.IsFalse (sc.AutoScroll, "#C1");
			Assert.AreEqual (0, sc.Controls.Count, "#C2");
		}

		[Test]
		public void AutoScrollMinSize ()
		{
			ScrollableControl sc = new ScrollableControl ();
			Assert.AreEqual (Size.Empty, sc.AutoScrollMinSize, "#A1");
			Assert.IsFalse (sc.AutoScroll, "#A2");

			sc.AutoScrollMinSize = Size.Empty;
			Assert.AreEqual (Size.Empty, sc.AutoScrollMinSize, "#B1");
			Assert.IsFalse (sc.AutoScroll, "#B2");

			sc.AutoScrollMinSize = new Size (10, 20);
			Assert.AreEqual (new Size (10, 20), sc.AutoScrollMinSize, "#C1");
			Assert.IsTrue (sc.AutoScroll, "#C2");

			sc.AutoScroll = false;
			Assert.AreEqual (new Size (10, 20), sc.AutoScrollMinSize, "#D1");
			Assert.IsFalse (sc.AutoScroll, "#D2");

			sc.AutoScrollMinSize = new Size (10, 20);
			Assert.AreEqual (new Size (10, 20), sc.AutoScrollMinSize, "#E1");
			Assert.IsFalse (sc.AutoScroll, "#E2");

			sc.AutoScrollMinSize = new Size (20, 20);
			Assert.AreEqual (new Size (20, 20), sc.AutoScrollMinSize, "#F1");
			Assert.IsTrue (sc.AutoScroll, "#F2");

			sc.AutoScroll = false;
			Assert.AreEqual (new Size (20, 20), sc.AutoScrollMinSize, "#G1");
			Assert.IsFalse (sc.AutoScroll, "#G2");

			sc.AutoScrollMinSize = Size.Empty;
			Assert.AreEqual (Size.Empty, sc.AutoScrollMinSize, "#H1");
			Assert.IsTrue (sc.AutoScroll, "#H2");

			sc.AutoScrollMinSize = new Size (10, 20);
			Assert.AreEqual (new Size (10, 20), sc.AutoScrollMinSize, "#I1");
			Assert.IsTrue (sc.AutoScroll, "#I2");

			sc.AutoScrollMinSize = Size.Empty;
			Assert.AreEqual (Size.Empty, sc.AutoScrollMinSize, "#J1");
			Assert.IsTrue (sc.AutoScroll, "#J2");
		}

#if NET_2_0
		[Test]
		public void MethodScrollToControl ()
		{
			if (TestHelper.RunningOnUnix)
				Assert.Ignore ("Depends of scrollbar width, values are for Windows");

			Form f = new Form ();
			f.ShowInTaskbar = false;
			f.Show ();
			
			PublicScrollableControl sc = new PublicScrollableControl ();
			sc.Size = new Size (200, 200);
			sc.AutoScroll = true;
			
			f.Controls.Add (sc);
			
			Button b = new Button ();
			b.Top = 15;
			sc.Controls.Add (b);
			
			Button b2 = new Button ();
			b2.Top = 340;
			sc.Controls.Add (b2);
			
			Button b3 = new Button ();
			b3.Left = 280;
			sc.Controls.Add (b3);

			Assert.AreEqual (new Point (0, 0), sc.PublicScrollToControl (b), "A1");
			Assert.AreEqual (new Point (0, -180), sc.PublicScrollToControl (b2), "A2");
			Assert.AreEqual (new Point (-172, 0), sc.PublicScrollToControl (b3), "A3");

			sc.AutoScrollPosition = new Point (50, 70);

			Assert.AreEqual (new Point (0, -15), sc.PublicScrollToControl (b), "A4");
			Assert.AreEqual (new Point (0, -180), sc.PublicScrollToControl (b2), "A5");
			Assert.AreEqual (new Point (-172, 0), sc.PublicScrollToControl (b3), "A6");

			sc.AutoScrollPosition = new Point (150, 150);

			Assert.AreEqual (new Point (0, -15), sc.PublicScrollToControl (b), "A7");
			Assert.AreEqual (new Point (0, -180), sc.PublicScrollToControl (b2), "A8");
			Assert.AreEqual (new Point (-172, 0), sc.PublicScrollToControl (b3), "A9");
			
			f.Dispose ();
		}
		
		private class PublicScrollableControl : ScrollableControl
		{
			public Point PublicScrollToControl (Control activeControl)
			{
				return base.ScrollToControl (activeControl);
			}
		}
		
		[Test]
		public void Padding ()
		{
			ScrollableControl c = new ScrollableControl ();
			c.Dock = DockStyle.Fill;
			c.Padding = new Padding (40);

			Assert.AreEqual (40, c.Padding.All, "A1");
			Assert.AreEqual (40, c.DockPadding.All, "A2");
			
			c.DockPadding.Right = 20;

			Assert.AreEqual (20, c.Padding.Right, "A3");
			Assert.AreEqual (20, c.DockPadding.Right, "A4");
			
			c.Padding = new Padding (40, 40, 40, 40);

			Assert.AreEqual (40, c.Padding.Right, "A5");
			Assert.AreEqual (40, c.DockPadding.Right, "A6");
			
			Form f = new Form ();
			f.Controls.Add (c);
			
			Button b = new Button ();
			c.Controls.Add (b);
			
			f.Show ();
			
			// Padding does not affect laying out the controls
			Assert.AreEqual (new Point (0, 0), b.Location, "A7");
			
			f.Close ();
			f.Dispose ();
		}
#endif
	}
}
