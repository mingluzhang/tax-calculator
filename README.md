# TaxCalculator

A small library that takes an employee's annual salary and produces a monthly
payslip (gross monthly income, monthly income tax, net monthly income), using a
progressive tax bracket model.

## Project Structure

- **TaxCalculator** — the core library. Given an employee and their annual
  salary, it calculates the progressive income tax and produces a `Payslip`.
- **TaxCalculator.Tests** — the unit test suite (xUnit).
- **TaxCalculator.ConsoleApp** — a thin runner that prints a payslip for a 
  sample employee using the TaxCalculator library. 

## Library Layout

- **Tax/** — everything about calculating tax: the bracket model
  (`TaxBracket`, `TaxBrackets`), the default bracket set (`ExampleTaxBrackets`),
  and the tax calculator (`TaxCalculator`).
- **Payroll/** — everything about turning tax calculation into a payslip:
  the `Employee` input, the `Payslip` output, the `PayslipGenerator` that
  assembles one from the other, and the `PayslipFormatter` that renders it.

## Design Thoughts

### Dependency Injection

Dependencies are passed in through constructors rather than created inside the
classes that use them. `TaxCalculator` receives its `TaxBrackets`, and
`PayslipGenerator` receives its `TaxCalculator`. This keeps the calculation 
and payslip generation independent, and makes each piece easy to test in isolation.

### Currency and tax brackets consistency

Currency and tax rates are both properties of a tax jurisdiction.
In the current design, these two live separately:
currency comes in with the salary, brackets come from a factory.
So nothing structurally prevents an amount in one currency from being
taxed with another jurisdiction's brackets.

The proper fix may be to introduce a `TaxJurisdiction` concept that bundles the
currency and the bracket together, keyed by a lightweight `JurisdictionCode`
(AU, NZ, ...) carried by the employee. 
Currency and brackets would then always be derived from the same jurisdiction.