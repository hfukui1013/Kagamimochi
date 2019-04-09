using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Drawing;

namespace Kagamimochi
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DrawNewYearsCard();
		}

		private void DrawNewYearsCard()
		{
			// 奥から順番に描画
			DrawText();
			DrawStand();
			DrawMochi2();
			DrawMochi1();
			DrawOrange();
			DrawOrangeLeaf();
		}

		#region 挨拶文

		private void DrawText()
		{
			var text = new TextBlock
			{
				Text = "あけまして\nおめでとうございます",
				FontSize = 48
			};
			Canvas.SetLeft(text, 10);
			MyCanvas.Children.Add(text);
		}
		#endregion

		#region 橙
		private void DrawOrange()
		{
			Ellipse ellipse = new Ellipse();
			ellipse.Fill = Brushes.Orange;
			ellipse.Width = 90;
			ellipse.Height = 80;
			ellipse.Stroke = Brushes.Black;
			ellipse.StrokeThickness = 3;

			MyCanvas.SetX(ellipse, 213);
			MyCanvas.SetY(ellipse, 240);
			MyCanvas.Children.Add(ellipse);
		}
		#endregion

		#region 橙の葉っぱ

		private void DrawOrangeLeaf()
		{
			Line line = new Line();
			//line.Fill = Brushes.Green;
			line.Stroke = Brushes.Green;
			line.StrokeThickness = 4;
			line.X1 = 210;
			line.Y1 = 210;
			line.X2 = 218;
			line.Y2 = 185;
		
			MyCanvas.Children.Add(line);

			Path leaf = new Path();
			leaf.Fill = Brushes.Green;
			leaf.Stroke = Brushes.Black;
			leaf.StrokeThickness = 2;

			PathGeometry pathGeometry = new PathGeometry();

			PathFigure pathFigure = new PathFigure();

			double radius = 15.0;
			double angle = 180.0;

			pathFigure.StartPoint = new Point(radius, 0);
			pathFigure.IsClosed = true;

			ArcSegment arcSegment1 = new ArcSegment();
			arcSegment1.IsLargeArc = true;
			arcSegment1.Point = new Point(-radius, 0);
			arcSegment1.SweepDirection = SweepDirection.Clockwise;
			arcSegment1.Size = new Size(radius, radius / 3.0);
			pathFigure.Segments.Add(arcSegment1);

			ArcSegment arcSegment2 = new ArcSegment();
			arcSegment2.IsLargeArc = angle >= 180.0;
			arcSegment2.Point = new Point(radius, 0);

			arcSegment2.Size = new Size(radius, radius / 3.0);

			arcSegment2.SweepDirection = SweepDirection.Clockwise;

			pathFigure.Segments.Add(arcSegment1);
			pathFigure.Segments.Add(arcSegment2);

			pathGeometry.Figures.Add(pathFigure);

			leaf.Data = pathGeometry;

			
			TransformGroup trans = new TransformGroup();

			trans.Children.Add( new RotateTransform(55, 0, 0) );
			trans.Children.Add( new TranslateTransform(225, 205) );
			leaf.RenderTransform = trans;
			MyCanvas.Children.Add(leaf);

		}
		#endregion

		#region 上のお餅
		private void DrawMochi1()
		{
			Path mochi = new Path();
			mochi.Fill = Brushes.White;
			mochi.Stroke = Brushes.Black;
			mochi.StrokeThickness = 5;

			PathGeometry pathGeometry = new PathGeometry();

			PathFigure pathFigure = new PathFigure();

			double radius = 130.0;
			double angle = 180.0;

			pathFigure.StartPoint = new Point(radius, 0);
			pathFigure.IsClosed = true;

			ArcSegment arcSegment1 = new ArcSegment();
			arcSegment1.IsLargeArc = true;
			arcSegment1.Point = new Point(-radius, 0);
			arcSegment1.SweepDirection = SweepDirection.Clockwise;
			arcSegment1.Size = new Size(radius, radius / 20);
			pathFigure.Segments.Add(arcSegment1);

			ArcSegment arcSegment2 = new ArcSegment();
			arcSegment2.IsLargeArc = angle >= 180.0;
			arcSegment2.Point = new Point(radius, 0);

			arcSegment2.Size = new Size(radius, radius / 1.5);

			arcSegment2.SweepDirection = SweepDirection.Clockwise;

			pathFigure.Segments.Add(arcSegment1);
			pathFigure.Segments.Add(arcSegment2);

			pathGeometry.Figures.Add(pathFigure);

			mochi.Data = pathGeometry;

			mochi.RenderTransform = new TranslateTransform(213, 345); ;

			MyCanvas.Children.Add(mochi);
		}
		#endregion

		#region 下のお餅
		private void DrawMochi2()
		{
			Path mochi = new Path();
			mochi.Fill = Brushes.White;
			mochi.Stroke = Brushes.Black;
			mochi.StrokeThickness = 5;

			PathGeometry pathGeometry = new PathGeometry();

			PathFigure pathFigure = new PathFigure();

			double radius = 170.0;
			double angle = 180.0;

			pathFigure.StartPoint = new Point(radius, 0);
			pathFigure.IsClosed = true;

			LineSegment lineSegment = new LineSegment(new Point(-radius, 0), true);
			
			ArcSegment arcSegment = new ArcSegment();
			arcSegment.IsLargeArc = angle >= 180.0;
			arcSegment.Point = new Point(radius, 0);

			arcSegment.Size = new Size(radius, radius/1.5);

			arcSegment.SweepDirection = SweepDirection.Clockwise;

			pathFigure.Segments.Add(lineSegment);
			pathFigure.Segments.Add(arcSegment);

			pathGeometry.Figures.Add(pathFigure);

			mochi.Data = pathGeometry;

			mochi.RenderTransform = new TranslateTransform(213, 418); ;

			MyCanvas.Children.Add(mochi);

		}
		#endregion

		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);

			Pen pen = new Pen(Brushes.Black, 10);
			Point pt1 = new Point(10, 10);
			Point pt2 = new Point(200, 200);
			drawingContext.DrawLine(pen, pt1, pt2);
		}


		#region 台座の描画
		private void DrawStand()
		{
			var stand = new Rectangle()
			{
				Width = 420,
				Height = 80,
				Fill = Brushes.BurlyWood,
				Stroke = Brushes.Black,
				StrokeThickness = 5
			};
			MyCanvas.SetX(stand, 220);
			MyCanvas.SetY(stand, 460);
			MyCanvas.Children.Add(stand);

			stand = new Rectangle()
			{
				Width = 240,
				Height = 120,
				Fill = Brushes.BurlyWood,
				Stroke = Brushes.Black,
				StrokeThickness = 5
			};
			MyCanvas.SetX(stand, 220);
			MyCanvas.SetY(stand, 555);
			MyCanvas.Children.Add(stand);

			var elp = new Ellipse
			{
				Width = 60,
				Height = 60,
				Fill = Brushes.White,
				Stroke = Brushes.Black,
				StrokeThickness = 5
			};
			MyCanvas.Children.Add(elp);
			MyCanvas.SetX(elp, 220);
			MyCanvas.SetY(elp, 555);
		}
		#endregion
	}

	#region 座標変換
	public static class CanvasExtension
	{
		public static void SetX(this Canvas canvas, Shape shape, double x)
		{
			Canvas.SetLeft(shape, x - ((shape.Width + shape.StrokeThickness * 2) / 2.0));
		}
		public static void SetY(this Canvas canvas, Shape shape, double y)
		{
			Canvas.SetTop(shape, y - ((shape.Height + shape.StrokeThickness * 2) / 2.0));
		}
	}
	#endregion
}
