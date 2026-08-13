using TaxCalculator;

var brackets = DefaultTaxBrackets.Brackets();
var calculator = new TaxCalculator.TaxCalculator(brackets);
var generator = new PayslipGenerator(calculator);

var employee = new Employee("Mary Song", new Money(60000m, Currency.NZD));

var payslip = generator.Generate(employee);
Console.WriteLine(PayslipFormatter.Format(payslip));