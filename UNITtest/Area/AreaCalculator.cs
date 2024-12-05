using System;

namespace Area
{
    public class AreaCalculator
    {
        // Поля для хранения размеров примитивов
        public double TriangleBase { get; set; }
        public double TriangleHeight { get; set; }
        public double CircleRadius { get; set; }
        public double RectangleWidth { get; set; }
        public double RectangleHeight { get; set; }

        // Конструктор
        public AreaCalculator(double triangleBase, double triangleHeight, double circleRadius, double rectangleWidth, double rectangleHeight)
        {
            TriangleBase = triangleBase;
            TriangleHeight = triangleHeight;
            CircleRadius = circleRadius;
            RectangleWidth = rectangleWidth;
            RectangleHeight = rectangleHeight;
        }

        // Метод для вычисления площади треугольника
        public double CalculateTriangleArea()
        {
            return 0.5 * TriangleBase * TriangleHeight;
        }

        // Метод для вычисления площади круга
        public double CalculateCircleArea()
        {
            return Math.PI * CircleRadius * CircleRadius;
        }

        // Метод для вычисления площади прямоугольника
        public double CalculateRectangleArea()
        {
            return RectangleWidth * RectangleHeight;
        }

        // Перегруженный метод для вычисления площади треугольника с разными параметрами
        public virtual double CalculateTriangleArea(double baseLength, double height)
        {
            return 0.5 * baseLength * height;
        }

        // Перегруженный метод для вычисления площади круга с разными параметрами
        public double CalculateCircleArea(double radius)
        {
            return Math.PI * radius * radius;
        }
    }
}
