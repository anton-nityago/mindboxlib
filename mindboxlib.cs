using System;
using System.Linq;

namespace mindboxlib
{
    public class Area
    {
        public struct triangle
        {
            public double aSide, bSide, cSide; 
        }

        static double[] triangleSides(triangle t)
        {
            double[] triangleSide = new double[3];
            triangleSide[0] = t.aSide; 
            triangleSide[1] = t.bSide; 
            triangleSide[2] = t.cSide;
            return triangleSide; 
        }

        public double circleArea(double r, int round = 15)
        {
            if (round == 15 & r > -1)
            {
                return Math.PI * (r * r); 
            } else
            {
                if (round > -1 & round < 15 & r > -1)
                {
                  return Math.Round(Math.PI * (r * r), round);
                } else return -1; 
            }
        }

        public double triangleArea(triangle t, int round = 15)
        {
            if (t.aSide >= 0 & t.bSide >= 0 & t.cSide >= 0 & round > -1)
            {
                double[] sides = triangleSides(t);
                
                if (isTriangle(sides))
                {
                    double p = (t.aSide + t.bSide + t.cSide) / 2;
                    double a = p - t.aSide;
                    double b = p - t.bSide;
                    double c = p - t.cSide;

                    if (round == 15) return Math.Sqrt(p * a * b * c);
                    else return Math.Round((Math.Sqrt(p * a * b * c)), round); 
                } else return -1; 

            } else return -1; 
        }

        public double anyFigureArea(triangle[] triangles, int round = 15)
        {
            double sum = 0; 
            foreach(triangle t in triangles)
            {
                if (triangleArea(t, round) > -1) sum += triangleArea(t, round); else return -1; 
            } 
            return  Math.Round(sum, round); 
        }

        static Boolean isTriangle(double[] sides)
        {
            double maxSide = sides.Max();

            double sumSide = sides.Sum();
            if ((maxSide < sumSide - maxSide) | (maxSide - (sumSide - maxSide) == 0 )) return true; else return false; 
        }        
        
        public Boolean isRigthTriangle(triangle t, int round = 15)
        {
            double[] sides = triangleSides(t); 

            if (!isTriangle(sides)) return false;
  
            double maxSide = sides.Max();
            
            double[] otherSides = new double[2];

            int index = 0; 
            foreach(double side in sides)
            {
                if (side != maxSide) { otherSides[index] = side; 
                    index++; 
                }
            }

            double a = Math.Round(Math.Pow(otherSides[0], 2), round);
            double b = Math.Round(Math.Pow(otherSides[1], 2), round);
            double c = Math.Round(Math.Pow(maxSide, 2), round);

            if (c == (a + b)) return true; else return false; 
        }

        public triangle randomTriangle(int hypotenuse = 50, int round = 15)
        {
            Random rnd = new Random();

            double x = Math.Round((rnd.NextDouble() + hypotenuse), round);
            double y = Math.Round((rnd.NextDouble() * hypotenuse), round);
            double z = 0; 

            if (y < x)
            {
                z = x - y;
                double d = (x - z) / 2;
                z += d; 
            }

            triangle t = new triangle { aSide = x, bSide = y, cSide = Math.Round(z, round) };
            return t; 
        }
    }
}