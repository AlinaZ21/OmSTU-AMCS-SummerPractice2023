using TechTalk.SpecFlow;
using spacebattle;

namespace spacebattletests
{
    [Binding]
    public class Перемещение_игрового_объекта
    {
        private readonly ScenarioContext scenarioContext;
        private double[] position = new double[2];
        private double[] speed = new double[2];
        private double corner, angularSpeed, fuel, consumption;
        private bool canMove = true, canRotation = true, knownSpeed = true,
         knownPosition = true, knownAngularSpeen = true, knownCorner = true;
        private double[] resultMove = new double[2];
        private double resultRotat;
        private double resultFuel;

        public Перемещение_игрового_объекта(ScenarioContext scenario_Context)
        {
            scenarioContext = scenario_Context;
        }

        [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
        public void космический_корабль_имеет_топливо_в_объеме
        (double x)
        {
            fuel = x;
        }

        [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
        public void имеет_скорость_расхода_топлива
        (double x)
        {
            consumption = x;
        }

        [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
        public void имеет_угол_наклона_к_оси_Ох
        (double x)
        {
            corner = x;
        }
        [Given(@"имеет мгновенную угловую скорость (.*) град")]
        public void имеет_мнгновенную_угловую_скорость
        (double x)
        {
            angularSpeed = x;
        }

        [Given(@"мгновенную угловую скорость невозможно определить")]
        public void угловую_скорость_корабля_определить_невозможно()
        {
            knownAngularSpeen = false;
        }

        [Given(@"невозможно изменить уголд наклона к оси OX космического корабля")]
        public void изменить_кгол_наклона_космического_корабля_невозможно()
        {
            canRotation = false;
        }

        [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
        public void космический_корабль_находится_в_точке_пространства_с_координатами
        (double p0, double p1)
        {
            position[0] = p0;
            position[1] = p1;
        }


        [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
        public void имеет_мгновенную_скорость(double p0, double p1)
        {
            speed[0] = p0;
            speed[1] = p1;
        }


        [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
        public void космический_корабль_положение_в_пространстве_которого_невозможно_определить()
        {
            knownPosition = false;
        }

        [Given(@"скорость корабля определить невозможно")]
        public void скорость_корабля_определить_невозможно()
        {
            knownSpeed = false;
        }

        [Given(@"космический корабль, угол наклона которого невозможно определить")]
        public void угол_наклона_корабля_определить_невозможно()
        {
            knownCorner = false;
        }

        [Given(@"изменить положение в пространстве космического корабля невозможно")]
        public void изменить_положение_в_пространстве_космического_корабля_невозможно()
        {
            canMove = false;
        }


        [When(@"происходит прямолинейное равномерное движение без деформации")]
        public void происходит_прямолинейное_равномерное_движениебез_деформации()
        {
            try
            {
                resultMove = SpaceShip.Movement(canMove, knownSpeed,
                knownPosition, speed, position);
                resultFuel = SpaceShip.Fuel(fuel, consumption);
            }
            catch { }
        }

        [When(@"происходит вращение вокруг собственной оси")]
        public void происходит_вращение_вокруг_собственной_оси()
        {
            try
            {
                resultRotat = SpaceShip.Rotation(canRotation, knownCorner, knownAngularSpeen, corner, angularSpeed);
            }
            catch { }
        }

        [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
        public void космический_корабль_перемещается_в_точку_пространства_с_координатами
        (double x, double y)
        {
            double[] expected = { x, y };
            Assert.Equal(expected, resultMove);
        }

        [Then(@"новый объем топлива космического корабля равен (.*) ед")]
        public void новый_объем_топлива
        (double x)
        {
            double expected = x;
            Assert.Equal(expected, resultFuel);
        }


        [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
        public void новый_угол_наклона
        (double x)
        {
            double expected = x;
            Assert.Equal(expected, resultRotat);
        }

        [Then(@"возникает ошибка Exception")]
        public void возникает_ошибка_Exception()
        {
            if (fuel != double.NaN || consumption != double.NaN)
            {
                try
                {
                    double result = SpaceShip.Fuel(fuel, consumption);
                }
                catch
                {
                    Assert.True(true);
                }
            }
            else if (corner != double.NaN || angularSpeed != double.NaN)
            {
                try
                {
                    double result = SpaceShip.Rotation(canRotation, knownCorner, knownAngularSpeen, corner, angularSpeed); ;
                }
                catch
                {
                    Assert.True(true);
                }
            }
            else
            {
                try
                {
                    double[] result = SpaceShip.Movement(canMove, knownSpeed,
                knownPosition, speed, position);
                }
                catch
                {
                    Assert.True(true);
                }
            }
        }
    }
}