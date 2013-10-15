//
// author : Pieter De Bruyne 2013
//
using System;
using System.Drawing;

namespace MMTproject1
{

    class Game
    {
        private readonly Random rand;
        private Player[] players;
        private Field field;
        private Ball ball;
        private Graphics g;

        private float maxSpeed;
        private Vector2D acceleration;
        private readonly Vector2D ballDeceleration;

        private uint playerCollisionsPerSec;

        private readonly uint timestep;
        private uint time;

        public bool AI { get; set; }
        
        public uint BlueScore { get; private set; }
        public uint RedScore { get; private set; }

        private double e = 0.8d; //restitutie
        public double Restitution
        {
            get { return e; }
            set { e = value; }
        }

        public Game(Graphics g, uint timestep, uint amountOfPlayers, bool bigplayer)
        {
            this.timestep = timestep;
            AI = true;
            players = new Player[amountOfPlayers];
            maxSpeed = 2.5f;
            acceleration = new Vector2D(3.0d, 3.0d);
            ballDeceleration = new Vector2D(-3.0d, -3.0d);
            rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < players.Length; i++)
            {
                double xRand = (rand.NextDouble() * 5.0d) - 2.5d;
                double yRand = (rand.NextDouble() * 3.5d) - 1.75d;
                players[i] = new Player(Utils.randomColor(), xRand, yRand, (rand.NextDouble() * 2) - 1, (rand.NextDouble() * 2) - 1);
            }

            players[0] = new Player(Color.Blue, -1.25, -1.00, (rand.NextDouble() * 2) - 1, (rand.NextDouble() * 2) - 1);
            players[1] = new Player(Color.Blue, -1.25, 1.00, (rand.NextDouble() * 2) - 1, (rand.NextDouble() * 2) - 1);
            players[2] = new Player(Color.Red, 1.25, -1.00, (rand.NextDouble() * 2) - 1, (rand.NextDouble() * 2) - 1);
            players[3] = new Player(Color.Red, 1.25, 1.00, (rand.NextDouble() * 2) - 1, (rand.NextDouble() * 2) - 1);
            if (bigplayer)
            {
                players[0].Mass += players[0].Mass;
                players[0].Radius += players[0].Radius;
            }

            field = new Field();
            ball = new Ball();
            this.g = g;
        }

        public void setMaxSpeed(float speed)
        {
            maxSpeed = speed;
        }

        //zowel in x als y richting
        public void setAcceleration(float dv)
        {
            acceleration = new Vector2D(dv, dv);
        }

        public double getAccelerationX()
        {
            return acceleration.X;
        }

        public float getMaxSpeed()
        {
            return maxSpeed;
        }


        private bool canStealBall(Player p1, Player p2)
        {
            return !p1.sameTeam(p2) && ball.hasOwner();
        }

        private void HandleGoal(Player p,int wall)
        {
            if (wall < 0 || wall > 1) return; //geen botsing met met één van de goals
            if (ball.hasOwner() && ball.Owner == p && p.Position.Y >= -0.35f && p.Position.Y <= 0.35f)
            {
                if (p.Color == Color.Blue)
                {
                    BlueScore++;
                }
                else
                {
                    RedScore++;
                }
                resetAfterGoal();
            }
        }

        public Player[] Players
        {
            get
            {
                return players;
            }
        }

        public void doStep()
        {
            time += timestep;
            if (time % 1000 == 0)
            {
                Console.WriteLine(playerCollisionsPerSec);
                playerCollisionsPerSec = 0;
                //AI = !AI;
            }
            doAI();
            Move();
            CheckCollisions();
            Render();
        }

        private void resetAfterGoal()
        {
            //waitAfterGoal = 3000; //3 seconden wachten alvorens opnieuw te beginnen
            players[0] = new Player(Color.Blue, -1.25, -1.00, (rand.NextDouble() * 2) - 1, (rand.NextDouble() * 2) - 1);
            players[1] = new Player(Color.Blue, -1.25, 1.00, (rand.NextDouble() * 2) - 1, (rand.NextDouble() * 2) - 1);
            players[2] = new Player(Color.Red, 1.25, -1.00, (rand.NextDouble() * 2) - 1, (rand.NextDouble() * 2) - 1);
            players[3] = new Player(Color.Red, 1.25, 1.00, (rand.NextDouble() * 2) - 1, (rand.NextDouble() * 2) - 1);
            ball = new Ball();
        }

        private void doAI()
        {
            if (!AI) return;
            for (int i = 0; i < players.Length; i++)
            {
                if (!(ball.Owner == players[i] || (players[i].sameTeam(ball.Owner))))
                {
                    Vector2D direction = ball.Position - players[i].Position;
                    double speed = players[i].Speed.Length;
                    players[i].Speed = Vector2D.Normalize(direction) * speed;
                }
                if (players[i] == ball.Owner)
                {
                    Vector2D direction = field.LeftGoalMid - players[i].Position;
                    if (players[i].Color == Color.Blue)
                    {
                        direction = field.RightGoalMid - players[i].Position;
                    }
                    double speed = players[i].Speed.Length;
                    players[i].Speed = Vector2D.Normalize(direction) * speed;
                }
            }
        }

        private void Move()
        {
            for (int i = 0; i < players.Length; i++)
            {
                Vector2D dv = (acceleration * timestep) / 1000;
                double xSpeed = players[i].Speed.X;
                double ySpeed = players[i].Speed.Y;

                xSpeed += (dv.X * Utils.sign(xSpeed)); // de versnelling in de juiste richting laten werken
                ySpeed += (dv.Y * Utils.sign(ySpeed));

                players[i].Speed = new Vector2D(xSpeed, ySpeed);
                if (players[i].Speed.Length > maxSpeed) //snelheid afvlakken
                {
                    players[i].Speed = Vector2D.Normalize(players[i].Speed) * maxSpeed;
                }
                players[i].Position += (players[i].Speed * timestep) / 1000;
            }

            //ball verplaatsen
            if (ball.Speed.Length > 0.1f && !ball.hasOwner())
            {
                Vector2D dv = (ballDeceleration * timestep) / 1000;
                double xSpeed = ball.Speed.X;
                double ySpeed = ball.Speed.Y;

                xSpeed += (dv.X * Utils.sign(xSpeed)); // de versnelling in de juiste richting laten werken
                ySpeed += (dv.Y * Utils.sign(ySpeed));
                ball.Speed = new Vector2D(xSpeed, ySpeed);
                ball.Position += (ball.Speed * timestep / 1000);
            }

            //meegaan met speler
            else if (ball.hasOwner())
            {
                ball.Position = ball.Owner.Position;
                ball.Speed = ball.Owner.Speed;
            }
        }

        private bool FindAndResolveCollision(CircleParticle p1, CircleParticle p2)
        {
            Vector2D dx = p1.Position - p2.Position; //relatieve positie van de botsing
            double centerDistanceSquared = (p1.Radius + p2.Radius);
            centerDistanceSquared *= (centerDistanceSquared);
            //vergelijk kwadratisch afstand om botsing te detecteren
            if (dx.LengthSquared <= centerDistanceSquared)
            {
                Vector2D dv = p2.Speed - p1.Speed;
                double dot = Vector2D.Dot(dx, dv);

                //de spelers/bal moeten van elkaar weg bewegen
                if (dot > 0)
                {
                    Vector2D collisionNormal = Vector2D.Normalize(p2.Position - p1.Position);
                    Vector2D collisionTangent = Vector2D.Tangent(collisionNormal);

                    //snelheidsvectoren projecteren op de componenten van de
                    //botsingsvector
                    double v1n = Vector2D.Dot(collisionNormal, p1.Speed);
                    double v1t = Vector2D.Dot(collisionTangent, p1.Speed);
                    double v2n = Vector2D.Dot(collisionNormal, p2.Speed);
                    double v2t = Vector2D.Dot(collisionTangent, p2.Speed);

                    //hier verandert eigenlijk niets
                    double v1tNa = v1t;
                    double v2tNa = v2t;

                    double v1nNa = (v1n*(p1.Mass - e*p2.Mass) + (1+e)*p2.Mass*v2n)/(p1.Mass + p2.Mass);
                    double v2nNa = (v2n*(p2.Mass - e*p1.Mass) + (1+e)*p1.Mass*v1n)/(p1.Mass + p2.Mass);

                    //terug in vectoren omzetten door de componenten
                    //te vermenigvuldigen met hun snelheid per component
                    //de tangentiële component is ongewijzigd
                    Vector2D vecV1nNa = v1nNa*collisionNormal;
                    Vector2D vecV1tNa = v1tNa*collisionTangent;
                    Vector2D vecV2nNa = v2nNa*collisionNormal;
                    Vector2D vecV2tNa = v2tNa*collisionTangent;

                    //calculate final speed by adding the components
                    p1.Speed = (vecV1nNa + vecV1tNa);
                    p2.Speed = (vecV2nNa + vecV2tNa);
                    return true;
                }
            }
            return false;
        }

        // returns 0 upon left wall collision
        // returns 1 upon right wall collision
        // returns 2 upon top wall collision
        // returns 3 upon boottom wall collision
        private int ResolveWallCollision(CircleParticle cp)
        {
            double leftBound = field.Left;
            double rightBound = field.Right;
            double upperBound = field.Top;
            double bottomBound = field.Bottom;
            if (cp.Left < leftBound && cp.Speed.X < 0)
            {
                cp.Speed = Vector2D.FlipX(cp.Speed);
                return 0;
            }
            if (cp.Right > rightBound && cp.Speed.X > 0)
            {
                cp.Speed = Vector2D.FlipX(cp.Speed);
                return 1;
            }
            if (cp.Up > upperBound && cp.Speed.Y > 0)
            {
                cp.Speed = Vector2D.FlipY(cp.Speed);
                return 2;
            }
            if (cp.Down < bottomBound && cp.Speed.Y < 0)
            {
                cp.Speed = Vector2D.FlipY(cp.Speed);
                return 3;
            }
            return -1;
        }


        private void CheckCollisions()
        {
            ResolveWallCollision(ball);
            //check for goals
            for (int i = 0; i < players.Length; i++)
            {
                int wall = ResolveWallCollision(players[i]);
                HandleGoal(players[i],wall);
            }

            //check for player/ball collisions if ball is free
            if (!ball.hasOwner())
            {
                for (int i = 0; i < players.Length; i++)
                {
                    if (FindAndResolveCollision(players[i], ball) && AI)
                    {
                        if (rand.NextDouble() < 0.2)
                        {
                            ball.Owner = players[i];
                            break;
                        }
                    }
                }
            }

            //check for player/player collisions
            for (int i = 0; i < players.Length; i++)
            {
                for (int j = i + 1; j < players.Length; j++) //elke object 1 keer checken
                {
                    if (FindAndResolveCollision(players[i], players[j]) && AI)
                    {
                        playerCollisionsPerSec++;
                        if (canStealBall(players[i], players[j]))
                        {
                            //playerCollisionsPerSec++;
                            Player ballPlayer = players[i];
                            Player otherPlayer = players[j];
                            if (ball.Owner == players[j]) //i heeft altijd de bal anders wisselen
                            {
                                ballPlayer = players[j];
                                otherPlayer = players[i];
                            }
                            if (rand.NextDouble() < 0.10d && (playerCollisionsPerSec < 5 || playerCollisionsPerSec > 150))
                            {
                                ball.Owner = otherPlayer;
                            }
                        }
                    }
                }
            }
        }

        private void Render()
        {
            field.Render(g);
            for (int i = 0; i < players.Length; i++)
            {
                players[i].Render(g);
            }
            ball.Render(g);
        }

    }

    //upper class for player and ball
    class CircleParticle
    {

        public double Radius { get; set; }
        public double Mass { get; set; }
        public Vector2D Position { get; set; }
        public Vector2D Speed { get; set; }

        //bounding box of this ball
        public RectangleF Bbox
        {
            get
            {
                return new RectangleF((float)(Position.X - Radius), (float)(Position.Y - Radius), (float)(2 * Radius), (float)(2 * Radius));
            }
        }

        public double Left
        {
            get
            {
                return Position.X - Radius;
            }
        }

        public double Right
        {
            get
            {
                return Position.X + Radius;
            }
        }

        public double Up
        {
            get
            {
                return Position.Y + Radius;
            }
        }

        public double Down
        {
            get
            {
                return Position.Y - Radius;
            }
        }
    }
    
    //represents a player
    class Player : CircleParticle
    {
        public Color Color { get; set; }

        public Player(Color color, double X, double Y, double vx, double vy)
        {
            Color = color;
            Radius = 0.14d;
            Mass = 1.0d;
            Position = new Vector2D(X, Y);
            Speed = new Vector2D(vx, vy);
        }

        public bool sameTeam(Player p)
        {
            if (p == null) return false;
            return p.Color.Equals(Color);
        }

        public void Render(Graphics g)
        {
            Pen p = new Pen(Color);
            g.FillEllipse(p.Brush, Bbox);
        }
    }

    //represents a ball
    class Ball : CircleParticle
    {
        public Color Color { get; set; }
        public Player Owner { get; set; }

        public Ball()
        {
            Position = new Vector2D(0.0, 0.0);
            Speed = new Vector2D(0.0, 0.0);
            Radius = 0.05f;
            Color = Color.Orange;
            Mass = 0.1f;
            Owner = null;
        }

        public bool hasOwner()
        {
            return Owner != null;
        }

        public void Render(Graphics g)
        {
            Pen p = new Pen(Color);
            g.FillEllipse(p.Brush, Bbox);
        }
    }

    //represents the entire football field
    class Field
    {
        private LineF leftGoal;
        private LineF rightGoal;
        public Vector2D LeftGoalMid { get; private set; }
        public Vector2D RightGoalMid { get; private set; }
        private RectangleF outerBox;
        private RectangleF innerbox;
        private PointF midLineTop;
        private PointF midLineBottom;
        private float centerRadius;

        public Field()
        {
            leftGoal = new LineF(-2.5f, -0.35f, -2.5f, 0.35f);
            rightGoal = new LineF(2.5f, -0.35f, 2.5f, 0.35f);
            outerBox = new RectangleF(0f, 0f, 5.5f, 4.0f);
            innerbox = new RectangleF(-2.5f, -1.75f, 5.0f, 3.5f);
            midLineTop = new PointF(0, 1.750f);
            midLineBottom = new PointF(0, -1.750f);
            centerRadius = 0.5f;
            LeftGoalMid = leftGoal.Mid;
            RightGoalMid = rightGoal.Mid;
        }

        public float Bottom
        {
            get
            {
                return innerbox.Top;
            }
        }

        public float Top
        {
            get
            {
                return innerbox.Bottom;
            }
        }

        public float Left
        {
            get
            {
                return innerbox.Left;
            }
        }

        public float Right
        {
            get
            {
                return innerbox.Right;
            }
        }

        public void Render(Graphics g)
        {
            Pen p = new Pen(Color.White, 0.01f);
            g.DrawRectangle(p, -2.5f, -1.75f, 5.0f, 3.5f);
            g.DrawLine(p, midLineBottom, midLineTop);
            g.DrawEllipse(p, -centerRadius, -centerRadius, 2 * centerRadius, 2 * centerRadius);
            g.DrawArc(p, -2.75f, -0.250f, 0.5f, 0.5f, 90f, -180f);
            g.DrawArc(p, 2.25f, -0.250f, 0.5f, 0.5f, 90f, 180f);
            p.Color = Color.Yellow;
            p.Width = 0.03f;
            g.DrawLine(p, leftGoal.p1.X, leftGoal.p1.Y, leftGoal.p2.X, leftGoal.p2.Y);
            g.DrawLine(p, rightGoal.p1.X, rightGoal.p1.Y, rightGoal.p2.X, rightGoal.p2.Y);
        }
    }

}