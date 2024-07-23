# Pizza-Com UML Diagram

### Download the PDF

You can download the PDF document from the following link:

[Download PDF](./uml-diagram.pdf)

## UML Diagram Description

Here is a textual description of a UML diagram representing the described scenario:

### Interfaces and Classes:

- **PizzaCalculation (Interface)**: This interface declares methods for calculating the cost and weight of a pizza.
- **BasePizza (Class)**: This class implements the PizzaCalculation interface, representing a basic pizza with its own cost and weight calculations.
- **BasePizzaDecorator (Abstract Class)**: This abstract class implements the PizzaCalculation interface and contains a reference to an object of type PizzaCalculation. It serves as the base class for various pizza decorators.
- **DoubleMeatDecorator (Class)**: This class inherits from BasePizzaDecorator and adds functionality for double meat to the pizza.
- **CheeseCrustDecorator (Class)**: This class inherits from BasePizzaDecorator and adds functionality for cheese crust to the pizza.

### Builder and Factory:

- **PizzaBuilder (Class)**: This class contains a PizzaCalculation object and methods to wrap the pizza object with various decorators. It returns a PizzaCalculation interface.
- **PizzaFactory (Class)**: This class has a method to build a pizza object using the PizzaBuilder based on a configuration of preferences.

### UML Diagram Components

#### Interfaces and Methods:

- **PizzaCalculation Interface**:
  - `+CalculateCost(): decimal`
  - `+CalculateWeight(): double`

#### Classes and Relationships:

- **BasePizza Class**:
  - `+CalculateCost(): decimal`
  - `+CalculateWeight(): double`
  - Implements: PizzaCalculation

- **BasePizzaDecorator Abstract Class**:
  - `-pizza: PizzaCalculation`
  - `+BasePizzaDecorator(pizza: PizzaCalculation)`
  - `+CalculateCost(): decimal`
  - `+CalculateWeight(): double`
  - Implements: PizzaCalculation

- **DoubleMeatDecorator Class**:
  - Inherits: BasePizzaDecorator
  - `+CalculateCost(): decimal`
  - `+CalculateWeight(): double`

- **CheeseCrustDecorator Class**:
  - Inherits: BasePizzaDecorator
  - `+CalculateCost(): decimal`
  - `+CalculateWeight(): double`

#### Builder and Factory:

- **PizzaBuilder Class**:
  - `-pizza: PizzaCalculation`
  - `+SetBasePizza(pizza: PizzaCalculation): PizzaBuilder`
  - `+AddDoubleMeat(): PizzaBuilder`
  - `+AddCheeseCrust(): PizzaBuilder`
  - `+Build(): PizzaCalculation`

- **PizzaFactory Class**:
  - `+CreatePizza(preferences: Preferences): PizzaCalculation`
  - Uses: PizzaBuilder
