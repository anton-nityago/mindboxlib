using System;
using mindboxlib; 


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var Area = new mindboxlib.Area {};           

            // существующий треугольник
            Area.triangle t1 = new Area.triangle { aSide = 1,  bSide = 1,  cSide = 1};
            
            // не существующий треугольник
            Area.triangle t2 = new Area.triangle { aSide = 10, bSide = 5, cSide = 4 };

            // треугольник с нулевой высотой
            Area.triangle t3 = new Area.triangle { aSide = 9, bSide = 5, cSide = 4 };

            //Пифагоровы тройки 
            Area.triangle t_pif_1 = new Area.triangle { aSide = 4, bSide = 3, cSide = 5 };
            Area.triangle t_pif_2 = new Area.triangle { aSide = 5, bSide = 12, cSide = 13 };
            Area.triangle t_pif_3 = new Area.triangle { aSide = 8, bSide = 15, cSide = 17 };

            //Пифагоровы "не тройки" 
            Area.triangle t_pif_1_ = new Area.triangle { aSide = 4.0000000001, bSide = 3, cSide = 5 };
            Area.triangle t_pif_2_ = new Area.triangle { aSide = 5, bSide = 12.0000000001, cSide = 13 };
            Area.triangle t_pif_3_ = new Area.triangle { aSide = 8, bSide = 15, cSide = 17.0000000001 };


            //Рандомные треугольники с разной гипотенузой
            Area.triangle[] t_array_1 = new Area.triangle[15];
            for (int n = 0; n < 15; n++) t_array_1[n] = Area.randomTriangle(n * 5);

            //Рандомные треугольники с разной точностью
            Area.triangle[] t_array_2 = new Area.triangle[15];
            for (int n = 0; n < 15; n++) t_array_2[n] = Area.randomTriangle(n * 3 + 2, n);

            double[] randomRadius = new double[15]; 
            for(int n = 0; n < 15; n++) { Random rnd = new Random(); randomRadius[n] = rnd.NextDouble(); }


            Console.WriteLine("");
            Console.WriteLine(" Площадь круга с нулевым радиусом:");
            Console.WriteLine(" r : 0  = " + Area.circleArea(0)); // нулевой радиус
            Console.WriteLine("");

            Console.WriteLine(" Площадь круга с отрицательным радиусом (вывод ошибки):");
            Console.WriteLine(" r : -1  = " + Area.circleArea(1, -1)); // если радиус неверный
            Console.WriteLine("");

            Console.WriteLine(" Площадь круга с рандомными радиусами:");
            foreach (double r in randomRadius) Console.WriteLine(" r : " + (r * 10) +  " = " + Area.circleArea(r * 10));
            Console.WriteLine("");

            Console.WriteLine(" Площадь круга с рандомными радиусами и округлением:");
            for (int n = 0; n < 15; n++) Console.WriteLine(" r : " + randomRadius[n] * 10 + " = " + Area.circleArea(randomRadius[n] * 10, n));
            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine(" Площадь существующего треугольника:"); 
            Console.WriteLine(" " + t1.aSide + ":" + t1.bSide + ":" + t1.cSide + " = " + Area.triangleArea(t1));
            Console.WriteLine("");

            Console.WriteLine(" Площадь несуществующего треугольника (вывод ошибки):");
            Console.WriteLine(" " + t2.aSide + ":" + t2.bSide + ":" + t2.cSide + " = " + Area.triangleArea(t2));
            Console.WriteLine("");

            Console.WriteLine(" Площадь треугольника с нулевой высотой:");
            Console.WriteLine(" " + t3.aSide + ":" + t3.bSide + ":" + t3.cSide + " = " + Area.triangleArea(t3));
            Console.WriteLine("");

            Console.WriteLine(" Площадь Пифагоровых троек:");
            Console.WriteLine(" " + t_pif_1.aSide + ":" + t_pif_1.bSide + ":" + t_pif_1.cSide + " = " + Area.triangleArea(t_pif_1));
            Console.WriteLine(" " + t_pif_2.aSide + ":" + t_pif_2.bSide + ":" + t_pif_2.cSide + " = " + Area.triangleArea(t_pif_2));
            Console.WriteLine(" " + t_pif_3.aSide + ":" + t_pif_3.bSide + ":" + t_pif_3.cSide + " = " + Area.triangleArea(t_pif_3));
            Console.WriteLine("");


            Console.WriteLine(" Проверка прямоугольного треугольника:");
            Console.WriteLine(" " + t_pif_1.aSide + ":" + t_pif_1.bSide + ":" + t_pif_1.cSide + " = " + Area.isRigthTriangle(t_pif_1));
            Console.WriteLine(" " + t_pif_2.aSide + ":" + t_pif_2.bSide + ":" + t_pif_2.cSide + " = " + Area.isRigthTriangle(t_pif_2));
            Console.WriteLine(" " + t_pif_3.aSide + ":" + t_pif_3.bSide + ":" + t_pif_3.cSide + " = " + Area.isRigthTriangle(t_pif_3));
            Console.WriteLine(" " + t_pif_1_.aSide + ":" + t_pif_1_.bSide + ":" + t_pif_1_.cSide + " = " + Area.isRigthTriangle(t_pif_1_));
            Console.WriteLine(" " + t_pif_2_.aSide + ":" + t_pif_2_.bSide + ":" + t_pif_2_.cSide + " = " + Area.isRigthTriangle(t_pif_2_));
            Console.WriteLine(" " + t_pif_3_.aSide + ":" + t_pif_3_.bSide + ":" + t_pif_3_.cSide + " = " + Area.isRigthTriangle(t_pif_3_));
            Console.WriteLine("");

            Console.WriteLine(" Площадь рандомных треугольников t_array_1:");
            foreach (Area.triangle t in t_array_1) Console.WriteLine(" " + t.aSide + " : " + t.bSide + " : " + t.cSide + " = " + Area.triangleArea(t));
            Console.WriteLine("");

            Console.WriteLine(" Площадь рандомных треугольников t_array_2 с разной точностью:");
            foreach (Area.triangle t in t_array_2) Console.WriteLine(" " + t.aSide + " : " + t.bSide + " : " + t.cSide + " = " + Area.triangleArea(t));
            Console.WriteLine("");

            Console.WriteLine(" Площадь рандомных треугольников t_array_1 с разным округлением:");
            for (int n = 0; n < 15; n++)
            {
                Console.WriteLine(" " + t_array_1[n].aSide + " : " + t_array_1[n].bSide + " : " + t_array_1[n].cSide + " = " + Area.triangleArea(t_array_1[n], n)); 
            }
            Console.WriteLine("");

            Console.WriteLine(" Площадь рандомной фигуры t_array_1:");
            Console.WriteLine(" " + Area.anyFigureArea(t_array_1));
            Console.WriteLine("");

            Console.WriteLine(" Площадь рандомной фигуры t_array_2:");
            Console.WriteLine(" " + Area.anyFigureArea(t_array_2));
            Console.WriteLine("");

            Console.ReadLine(); 

        }
    }
}
