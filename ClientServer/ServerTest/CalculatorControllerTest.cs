using Server;
using SharedModel;

namespace ServerTest
{
	public class CalculatorControllerTest
	{
		[Test]
		public void CorrectedGetPi()
		{
			var calculator = new CalculatorController();
			Assert.That(calculator?.GetPi(), Is.EqualTo(Math.PI));
		}

		[Test]
		public void CorrectedGetE()
		{
			var calculator = new CalculatorController();
			Assert.That(calculator?.GetE(), Is.EqualTo(Math.E));
		}

		[Test]
		public void CorrectedGetPiNoEquelsGetE()
		{
			var calculator = new CalculatorController();
			Assert.That(calculator?.GetE(), Is.Not.EqualTo(calculator?.GetPi()));
		}

		[Test]
		public void CheckResultAddWithZero()
		{
			var calculator = new CalculatorController();
			var input = new Operated()
			{
				ValueA = 5,
				ValueB = 0
			};

			var result = calculator.Add(input);

			Assert.That(input.ValueA + input.ValueB, Is.EqualTo(result));
			Assert.That(input.ValueA, Is.EqualTo(result));
		}

		[Test]
		public void CheckResultAddWithDifferentValue()
		{
			var calculator = new CalculatorController();
			var input = new Operated()
			{
				ValueA = 5,
				ValueB = 6
			};

			var result = calculator.Add(input);

			Assert.AreEqual(input.ValueA + input.ValueB, result);
			Assert.AreNotEqual(input.ValueA, result);
		}

		[Test]
		public void CheckResultAddAssociatedProperty()
		{
			var calculator = new CalculatorController();
			var input = new Operated()
			{
				ValueA = 5,
				ValueB = 6
			};

			var result = calculator.Add(input);

			Assert.AreEqual(input.ValueA + input.ValueB, result);
			Assert.AreEqual(input.ValueB + input.ValueA, result);
		}

		[Test]
		public void CheckResultDivOnZero()
		{
			var calculator = new CalculatorController();
			var input = new Operated()
			{
				ValueA = 5,
				ValueB = 0
			};

			Assert.Catch<DivideByZeroException>(() => { calculator.Div(input); });
		}
	}
}