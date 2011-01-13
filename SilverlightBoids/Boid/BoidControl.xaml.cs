using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightBoids.Logic;
using System.Text;

namespace SilverlightBoids
{
    public partial class BoidControl : UserControl
    {
        public int ID { get; private set; }

        private Vector2 _position;
        private Vector2 _velocity;
        private Vector2 _acceleration;
        private int _mass = (new Random()).Next(20, 80);
        private int _maxForce = 20;
        private int _maxSpeed = 10;
        public Vector2 _steerForce;

        public IBoidAction Action { get; set; }

        public Vector2 Velocity { get { return _velocity; } }
        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                if (value.X >= 0 && value.Y >= 0)
                {
                    this.SetValue(Canvas.LeftProperty, (double)value.X);
                    this.SetValue(Canvas.TopProperty, (double)value.Y);
                }
            }
        }

        public BoidControl(Vector2 startPoint,int Id)
            : this(startPoint, Id, Colors.Yellow)
        {
        }

        public BoidControl(Vector2 startPoint, int Id, Color boidColor)
        {
            _velocity = Vector2.Zero;
            _acceleration = Vector2.Zero;
            Position = startPoint;
            ID = Id;
            Action = new BoidActionWander();
            InitializeComponent();
            boidEllipse.Fill = new SolidColorBrush(boidColor);
        }

        public void Go(Vector2 dest, WorldLogic.World world)
        {
            if (this.Action != null)
            {
                _steerForce = this.Action.DoAction(dest, _position, _velocity, _maxSpeed);
                _steerForce = Vector2.Truncate(_steerForce, _maxForce);
                _acceleration = _steerForce / _mass;
                _velocity = Vector2.Truncate(_velocity + _acceleration, _maxSpeed);

                Position = CheckBoundaries(Vector2.Add(_velocity, Position), (int)world.WorldHeight, (int)world.WorldWidth);

                //Logger.Save(CreateLog());
            }
        }


        private StringBuilder CreateLog()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("Boid Id : {0}", this.ID));
            sb.AppendLine(String.Format("Steer Force : {0}", this._steerForce));
            sb.AppendLine(String.Format("Acceleration : {0}", this._acceleration));
            sb.AppendLine(String.Format("Velocity : {0}", this._velocity));
            sb.AppendLine(String.Format("Position : {0}", this.Position));
            sb.AppendLine();
            
            return sb;
        }

        public Vector2 CheckBoundaries(Vector2 newPosition,int maxX,int maxY)
        {
            if (newPosition.X > maxX)
                newPosition.X = 0;
            if (newPosition.Y > maxY)
                newPosition.Y = 0;
            if (newPosition.X < 0)
                newPosition.X = maxX;
            if (newPosition.Y < 0)
                newPosition.Y = maxY;

            return newPosition;
        }
    }
}
