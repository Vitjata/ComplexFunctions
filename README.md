# Complex Functions Visualizations

This repository contains visualizations of various complex functions using C#. The images illustrate the behavior of these functions in the complex plane over the interval:

$$\{z \in \mathbb{C} : -2 \leq \text{Re}(z) \leq 2, -2 \leq \text{Im}(z) \leq 2\}$$

## Function Visualizations

### Function 1
$$F(z) = \left(\frac{z^5-1}{z^{10}-512}\right)^2$$

![Function 1 Visualization](./images/Untitled1.jpg)

### Function 2
$$F(z) = \left(\frac{z^5-1}{z^{10}-512}\right)^{-2i}$$

![Function 2 Visualization](./images/Untitled2.jpg)

### Function 3
$$F(z) = \left(\frac{z^5-1}{z^{10}-512}\right)^{2-2i}$$

![Function 3 Visualization](./images/Untitled3.jpg)

### Function 4
$$F(z) = \frac{\sin(2\pi z)}{z^3}$$

![Function 4 Visualization](./images/Untitled4.jpg)

### Function 5
$$F(z) = \frac{(z+i+1)^3 \cdot (z^2+1) \cdot e^{3/z}}{(z-1)^2 \cdot (z+1)}$$

![Function 5 Visualization](./images/Untitled5.jpg)

## Julia Sets

### Julia Set (Standard)
![Julia Set Standard](./images/Untitled6.jpg)

### Julia Set (8x Magnification)
![Julia Set 8x Magnification](./images/Untitled7.jpg)

## Technical Details

- **Language**: C#
- **Domain**: Complex plane region [-2, 2] × [-2i, 2i]
- **Visualization**: Color mapping based on function behavior
- **Architecture**: 
  - `ComplexFramelessForm` class inherits from `FramelessForm` class
  - `ComplexPlotter` class handles the mathematical computations and rendering of complex functions
