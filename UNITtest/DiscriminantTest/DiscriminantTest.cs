using Xunit;
using Discriminant;

namespace DiscriminantTest
{
    public class DiscriminantCalculatorTests
    {
        [Fact] // Тест для проверки корректного расчёта дискриминанта
        public void CalculateDiscriminant_ValidInput_ReturnsCorrectDiscriminant()
        {
            var calculator = new DiscriminantCalculator(1, 5, 6);
            double result = calculator.DiscriminantResult;
            Assert.Equal(1, result);
        }

        [Fact] // Тест для проверки перегруженного метода
        public void CalculateDiscriminant_OverloadedMethod_ReturnsCorrectDiscriminant()
        {
            var calculator = new DiscriminantCalculator(1, 4, 4);
            double result = calculator.CalculateDiscriminant(1, 4, 4);
            Assert.Equal(0, result);
        }

        [Fact] // Тест для проверки перегруженного метода с параметром verbose
        public void CalculateDiscriminant_OverloadedMethodVerbose_ReturnsCorrectDiscriminant()
        {
            var calculator = new DiscriminantCalculator(1, 2, 1);
            double result = calculator.CalculateDiscriminant(1, 2, 1, true);
            Assert.Equal(0, result);
        }
    }
}
