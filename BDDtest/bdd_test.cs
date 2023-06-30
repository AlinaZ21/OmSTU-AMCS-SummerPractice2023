using SquareEquationLib;
using TechTalk.SpecFlow;
namespace XUnit.Tests
{
    [Binding]
    public class Нахождение_корней
    {
        private readonly ScenarioContext scenarioContext;
        private double a, b, c;
        private double[] roots = new double[2];
        public Нахождение_корней(ScenarioContext scenario_Context)
        {
            scenarioContext = scenario_Context;
        }

        [When(@"вычисляются корни квадратного уравнения")]
        public void вычисляются_корни_квадратного_уравнения()
        {
            try
            {
                roots = SquareEquation.Solve(a, b, c);
            }
            catch { }
        }
        [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
        public void квадратное_уравнение_имеет_два_корня_кратности_один(double x1, double x2)
        {
            double[] supposed = { x1, x2 };
            Array.Sort(supposed);
            Array.Sort(roots);
            Assert.Equal(supposed, roots);
        }

        [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
        public void квадратное_уравнение_имеет_один_корень_кратности_два(double x1)
        {
            double[] supposed = { x1 };
            Assert.Equal(supposed, roots);
        }

        [Then(@"множество корней квадратного уравнения пустое")]
        public void множество_корней_квадратного_уравнения_пустое()
        {
            double[] supposed = { };
            Assert.Equal(supposed, roots);
        }


        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
        public void квадратное_уравнение_с_норм_коэффициентами(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
        }

        [Given(@"Квадратное уравнение с коэффициентами \(NaN, (.*), (.*)\)")]
        public void квадратное_уравнение_с_неопределенностью_А(double B, double C)
        {
            a = double.NaN;
            b = B;
            c = C;
        }

        [Given(@"Квадратное уравнение с коэффициентами \((.*), NaN, (.*)\)")]
        public void квадратное_уравнение_с_неопределенностью_Б(double A, double C)
        {
            a = A;
            b = double.NaN;
            c = C;
        }

        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), NaN\)")]
        public void квадратное_уравнение_с_неопределенностью_С(double A, double B)
        {
            a = A;
            b = B;
            c = double.NaN;
        }

        [Given(@"Квадратное уравнение с коэффициентами \(Double\.NegativeInfinity, (.*), (.*)\)")]
        public void квадратное_уравнение_с_отриц_беск_А(int B, int C)
        {
            a = double.NegativeInfinity;
            b = B;
            c = C;
        }

        [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.NegativeInfinity, (.*)\)")]
        public void квадратное_уравнение_с_отриц_беск_Б(int A, int C)
        {
            a = A;
            b = double.NegativeInfinity;
            c = C;
        }

        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.NegativeInfinity\)")]
        public void квадратное_уравнение_с_отриц_беск_С(int A, int B)
        {
            a = A;
            b = B;
            c = double.NegativeInfinity;
        }

        [Given(@"Квадратное уравнение с коэффициентами \(Double\.PositiveInfinity, (.*), (.*)\)")]
        public void квадратное_уравнение_с_полож_беск_А(int B, int C)
        {
            a = double.PositiveInfinity;
            b = B;
            c = C;
        }

        [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.PositiveInfinity, (.*)\)")]
        public void квадратное_уравнение_с_полож_беск_Б(int A, int C)
        {
            a = A;
            b = double.PositiveInfinity;
            c = C;
        }

        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.PositiveInfinity\)")]
        public void квадратное_уравнение_с_полож_беск_С(int A, int B)
        {
            a = A;
            b = B;
            c = double.PositiveInfinity;
        }

        [Then(@"выбрасывается исключение ArgumentException")]
        public void выбрасывается_исключение_ArgumentException()
        {
            var argExc = new ArgumentException();
            try
            {
                var roots = SquareEquation.Solve(a, b, c);
            }
            catch (Exception exc)
            {
                Assert.Equal(exc.GetType(), argExc.GetType());
            }
        }
    }
}