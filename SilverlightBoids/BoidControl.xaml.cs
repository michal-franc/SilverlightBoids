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

namespace SilverlightBoids
{
    public partial class BoidControl : UserControl
    {

        public int ID { get; private set; }

        private Vector2 _position;
        private Vector2 _velocity;
        private Vector2 _acceleration;
        private int _mass = 1;
        private int _maxForce = 1;
        private int _maxSpeed = 1;
        private Vector2 _steerForce;


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
        {
            _velocity = Vector2.Zero;
            _acceleration = Vector2.Zero;
            Position = startPoint;
            ID = Id;
            InitializeComponent();
        }

        public void Go(IBoidAction action,Vector2 dest)
        {
            _steerForce = action.DoAction(dest, _position, _velocity,_maxSpeed);
            _steerForce = Vector2.Truncate(_steerForce, _maxForce);
            _acceleration = _steerForce / _mass;
            _velocity = Vector2.Truncate(_velocity + _acceleration, _maxSpeed);
            Position = Vector2.Add(_velocity, Position);
        }
    }
}
