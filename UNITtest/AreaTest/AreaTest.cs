using Xunit;
using Area;

namespace AreaTest
{
    public class AreaCalculatorTests
    {
        [Fact] // Тест для проверки площади треугольника
        public void CalculateTriangleArea_ValidInput_ReturnsCorrectArea()
        {
            var calculator = new AreaCalculator(10, 5, 0, 0, 0);
            double area = calculator.CalculateTriangleArea();
            Assert.Equal(25, area);
        }

        [Fact] // Тест для проверки площади круга
        public void CalculateCircleArea_ValidInput_ReturnsCorrectArea()
        {
            var calculator = new AreaCalculator(0, 0, 3, 0, 0);
            double area = calculator.CalculateCircleArea();
            Assert.Equal(Math.PI * 9, area, 5); // Сравнение с точностью до 5 знаков после запятой
        }

        [Fact] // Тест для проверки площади прямоугольника
        public void CalculateRectangleArea_ValidInput_ReturnsCorrectArea()
        {
            var calculator = new AreaCalculator(0, 0, 0, 4, 5);
            double area = calculator.CalculateRectangleArea();
            Assert.Equal(20, area);
        }

        [Fact] // Тест для проверки перегруженного метода для площади треугольника
        public void CalculateTriangleArea_OverloadedMethod_ReturnsCorrectArea()
        {
            var calculator = new AreaCalculator(0, 0, 0, 0, 0);
            double area = calculator.CalculateTriangleArea(6, 4);
            Assert.Equal(12, area);
        }

        [Fact] // Тест для проверки перегруженного метода для площади круга
        public void CalculateCircleArea_OverloadedMethod_ReturnsCorrectArea()
        {
            var calculator = new AreaCalculator(0, 0, 0, 0, 0);
            double area = calculator.CalculateCircleArea(5);
            Assert.Equal(Math.PI * 25, area, 5); // Сравнение с точностью до 5 знаков после запятой
        }
    }
}
