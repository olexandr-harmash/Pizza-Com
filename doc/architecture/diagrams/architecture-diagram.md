# Pizza-Com Use Case Diagram

### Download the PDF

You can download the PDF document from the following link:

[Download PDF](./usecase-diagram.pdf)

### Use Case Descriptions

1. **Browse Pizza Catalog**
    - **Actor:** User
    - **Goal:** Obtain a list of all available pizzas.
    - **Description:** The user selects an option to view the pizza catalog. The system displays a list of all available pizzas.

2. **View Pizza Details**
    - **Actor:** User
    - **Goal:** View detailed information about the selected pizza, including available options and ingredients, and choose the desired options.
    - **Precondition:** The user must select a pizza from the catalog.
    - **Description:** The user selects a specific pizza from the catalog. The system displays the details of the selected pizza, including possible options and ingredients. The user selects the desired options for the pizza.

3. **Create Pizza Instance**
    - **Actor:** User
    - **Goal:** Create a pizza instance with a unique identifier, cost, and weight.
    - **Precondition:** The user must select options for the pizza.
    - **Description:** The user select options through the **Select Options** use case. The system validates the combination of options through the **Validate Options** use case. If the combination of options is invalid, the system initiates the **Invalid Combination of Options** use case. If the combination of options is valid, the system creates a pizza instance with a unique identifier, cost, and weight and returns it to the user.

4. **Select Options**
    - **Actor:** User
    - **Goal:** Selected pizza options for creating pizza instance.
    - **Precondition:** The user must choose the pizza.
    - **Description:**  The user confirms the prefer options.

5. **Validate Options**
    - **Actor:** System
    - **Goal:** Check the selected pizza options for correctness.
    - **Precondition:** The user must select options for the pizza.
    - **Description:** The system checks the combination of selected options. If the combination of options is invalid, the system initiates the **Invalid Combination of Options** use case.

6. **Invalid Combination of Options**
    - **Actor:** System
    - **Goal:** Notify the user of an invalid combination of options.
    - **Description:** If the system finds that the combination of options is invalid, it notifies the user and suggests correcting the selection of options.
